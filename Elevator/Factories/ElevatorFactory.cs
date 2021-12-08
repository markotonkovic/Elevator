using Elevators.Interfaces;
using Elevators.Components;

namespace Elevators.Factories
{
    internal static class ElevatorFactory
    {
        public static List<IElevator> Build(int numberOfFloors, int numberOfElevators)
        {
            var elevators = new List<IElevator>();
            
            for (int i = 0; i < numberOfElevators; i++)
            {
                elevators.Add(new Elevator(i, numberOfFloors));
            }

            return elevators;
        }
    }
}
