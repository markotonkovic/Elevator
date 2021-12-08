using Elevators.Core;

namespace Elevators.Factories
{
    internal static class FloorFactory
    {
        public static Floor Build(int floors)
        {
            Floor floor = null;

            for (int i = 0; i < floors; i++)
            {
                floor = new Floor(i, floor); 
            }

            return floor.First();
        }
    }
}
