using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Rover
    {
        public Location Location { get; set; }
        private int _coordinatLimitX;
        private int _coordinatLimitY;

        public Rover(int coordinatLimitX, int coordinatLimitY)
        {
            _coordinatLimitX = coordinatLimitX;
            _coordinatLimitY = coordinatLimitY;
        }

        public void SetInitialCoordinate(Location location)
        {
            Location = location;

            if (location.XPoint > _coordinatLimitX || location.YPoint > _coordinatLimitY)
            {
                Location.XPoint = null;
                Location.YPoint = null;

                throw new Exception("Error Limit Exceeded");
            }
        }

        private void RotateLeft()
        {
            switch (Location.Direction)
            {
                case Directions.E:
                    Location.Direction = Directions.N;
                    break;
                case Directions.W:
                    Location.Direction = Directions.S;
                    break;
                case Directions.N:
                    Location.Direction = Directions.W;
                    break;
                case Directions.S:
                    Location.Direction = Directions.E;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void RotateRight()
        {
            switch (Location.Direction)
            {
                case Directions.E:
                    Location.Direction = Directions.S;
                    break;
                case Directions.W:
                    Location.Direction = Directions.N;
                    break;
                case Directions.N:
                    Location.Direction = Directions.E;
                    break;
                case Directions.S:
                    Location.Direction = Directions.W;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        private void StepForward()
        {
            switch (Location.Direction)
            {
                case Directions.E:
                    Location.XPoint++;
                    break;
                case Directions.W:
                    Location.XPoint--;
                    break;
                case Directions.N:
                    Location.YPoint++;
                    break;
                case Directions.S:
                    Location.YPoint--;
                    break;
                default:
                    throw new ArgumentException();
            }

            if (Location.XPoint > _coordinatLimitX || Location.YPoint > _coordinatLimitY)
            {
                Location.XPoint = null;
                Location.YPoint = null;

                throw new Exception("Error Limit Exceeded");
            }
        }

        public void Move(string command)
        {
            char[] commandArray = command.ToCharArray();

            if (Location.XPoint != null && Location.YPoint != null)
            {
                foreach (var item in commandArray)
                {
                    switch (item)
                    {
                        case 'L':
                            RotateLeft();
                            break;
                        case 'R':
                            RotateRight();
                            break;
                        case 'M':
                            try
                            {
                                StepForward();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                return;
                            }
                            break;
                        default:
                            throw new ArgumentException();
                    }
                }
            }

            else
            {
                throw new Exception("The start coordinates are entered incorrectly!");
            }
        }
    }
}
