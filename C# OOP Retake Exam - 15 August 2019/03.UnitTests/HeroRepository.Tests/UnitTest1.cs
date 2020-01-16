using System;
using NUnit.Framework;

//namespace HeroRepository.Tests
//{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_Not_Existing_Hero()
        {
            var repository = new HeroRepository();

            Assert.Throws<ArgumentNullException>(()=>repository.Create(null));
        }

        [Test]
        public void Create_Already_Existing_Hero()
        {
            var repository = new HeroRepository();

            var hero = new Hero("Kiro", 5);
            repository.Create(hero);

            Assert.Throws<InvalidOperationException>(() => repository.Create(hero));
        }

        [Test]
        public void HeroCreated()
        {
            var repository = new HeroRepository();

            var hero = new Hero("Kiro", 5);
            var result = repository.Create(hero);

            Assert.AreEqual($"Successfully added hero {hero.Name} with level {hero.Level}",result);
        }

        [Test]
        public void Remove_Not_Existing_Hero()
        {
            var repository = new HeroRepository();

            var hero = new Hero("Kiro", 5);
            repository.Create(hero);
            var exception = repository.Remove("Pesho");

            Assert.AreEqual(false,false);
        }

        [Test]
        public void Remove_Existing_Hero_Works()
        {
            var repository = new HeroRepository();

            var hero1 = new Hero("Gosho", 5);
            repository.Create(hero1);
            var hero2 = new Hero("Kiro", 5);
            repository.Create(hero2);
            var hero3 = new Hero("Pesho", 5);
            repository.Create(hero3);

            var result = repository.Remove("Pesho");

            Assert.AreEqual(true, result);
        }

        [Test]
        public void Get_Hero_With_Highest_Levels_Works()
        {
            var repository = new HeroRepository();

            var hero1 = new Hero("Gosho", 5);
            repository.Create(hero1);
            var hero2 = new Hero("Kiro", 10);
            repository.Create(hero2);
            var hero3 = new Hero("Pesho", 7);
            repository.Create(hero3);

            var result = repository.GetHeroWithHighestLevel();

            Assert.AreEqual(hero2, result);
        }

        [Test]
        public void Get_Hero_With_Name_Works()
        {
            var repository = new HeroRepository();

            var hero1 = new Hero("Gosho", 5);
            repository.Create(hero1);
            var hero2 = new Hero("Kiro", 10);
            repository.Create(hero2);
            var hero3 = new Hero("Pesho", 7);
            repository.Create(hero3);

            var result = repository.GetHero("Pesho");

            Assert.AreEqual(hero3, result);
        }
        [Test]

        public void Heroes_With_Name_Works()
        {
            var repository = new HeroRepository();

            var hero1 = new Hero("Gosho", 5);
            repository.Create(hero1);
            var hero2 = new Hero("Kiro", 10);
            repository.Create(hero2);
            var hero3 = new Hero("Pesho", 7);
            repository.Create(hero3);
            
            var count = repository.Heroes.Count;

            Assert.AreEqual(3, count);
        }
    }
//}