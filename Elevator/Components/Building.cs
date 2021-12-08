using Elevators.Factories;
using Elevators.Interfaces;

namespace Elevators.Components
{
    internal class Building : IBuilding 
    {
        private readonly List<IElevator> _elevators = new();

        public Building(int floors, int elevators)
        {
            _elevators = ElevatorFactory.Build(floors, elevators);
        }
        
        public void Call(int elevator, int floor)
        {
            var e = _elevators[elevator];
            if (e != null)
            {
                Console.WriteLine($"Calling elevator {elevator} to {floor} floor.");
                e.Call(floor);
            }
   
        }

        public void GoTo(int elevator, int floor)
        {
            var e = _elevators[elevator];
            if (e != null)
            {
                Console.WriteLine($"Going to floor {floor} with elevator {elevator}.");
                e.GoTo(floor);
            }
        }

        public void Dispose()
        {
            _elevators.ForEach(x => x.Dispose());
        }
    }
}
