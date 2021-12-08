using Elevators.Core;
using Elevators.Interfaces;

namespace Elevators.Components
{
    internal class Elevator : IElevator
    {
        private readonly ElevatorEngine _engine;

        public Elevator(int elevatorNumber, int floors)
        {
            _engine = new(elevatorNumber, floors);
            _engine.Start();
        }

        public void Call(int floorNumber)
        {
            _engine.Call(floorNumber);
        }

        public void GoTo(int floorNumber)
        {
            _engine.Call(floorNumber);
        }

        public void Dispose()
        {
            _engine.Stop();
        }
    }
}
