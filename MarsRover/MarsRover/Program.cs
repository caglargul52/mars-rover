using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover rover = new Rover(5, 5);

            rover.SetInitialCoordinate(new Location { XPoint = 1, YPoint = 2, Direction = Directions.N });
            rover.Move("LMLMLMLMM");
            Console.WriteLine("X Point: " + rover.Location.XPoint + "  Y Point: " + rover.Location.YPoint + "  Direction: " + rover.Location.Direction);

            rover.SetInitialCoordinate(new Location { XPoint = 3, YPoint = 3, Direction = Directions.E });
            rover.Move("MMRMMRMRRM");
            Console.WriteLine("X Point: " + rover.Location.XPoint + "  Y Point: " + rover.Location.YPoint + "  Direction: " + rover.Location.Direction);

            Console.Read();
        }
    }
}
