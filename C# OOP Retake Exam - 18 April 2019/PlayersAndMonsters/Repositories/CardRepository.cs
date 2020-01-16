

namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using Contracts;

    public class CardRepository:ICardRepository
    {
        private readonly List<ICard> _cards;

        public CardRepository()
        {
            _cards = new List<ICard>();
        }

        public int Count 
            => Cards.Count;

        public IReadOnlyCollection<ICard> Cards 
            => _cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            
            if (_cards.Any(c=>c.Name == card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            _cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }

            var removed = _cards.Remove(card);

            return removed;
        }

        public ICard Find(string name)
        {
            ICard card = _cards.FirstOrDefault(x => x.Name == name);

            return card;
        }
    }
}
