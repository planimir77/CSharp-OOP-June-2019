using System.Runtime.CompilerServices;

namespace _03.Ferrari
{
    public interface ICar
    {
        string Model { get; set; }

        string Driver { get; set; }

        string Brakes();

        string Gas();
        
    }
}
