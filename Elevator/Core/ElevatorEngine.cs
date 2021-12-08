using Elevators.Factories;

namespace Elevators.Core
{
    internal class ElevatorEngine
    {
        private readonly int _elevatorNumber;
        private readonly CancellationTokenSource _cts;
        private readonly CancellationToken _token;
        private readonly CallQueue _calls = new();
        private Task _worker;
        private Floor _currentFloor;
        private ElevatorState _state;


        public ElevatorEngine(int elevatorNumber, int floors)
        {
            _elevatorNumber = elevatorNumber;
            _cts = new CancellationTokenSource();
            _token = _cts.Token;
            _currentFloor = FloorFactory.Build(floors);
        }

        public void Start() 
        {
            _worker = Task.Run(() =>
            {
                while (!_token.IsCancellationRequested)
                {
                    Move();
                    Thread.Sleep(2000);
                }
            }, _token);
        }

        public void Stop()
        {
            _cts.Cancel();
            _worker.Wait();
        }

        public void Call(int floor) => 
            _calls.Enqueue(floor);

        private void Move()
        {
            _calls.Dequeue(_currentFloor.Number);
            var nextFloor = NextFloor();

            if (nextFloor > _currentFloor.Number)
            {
                _state = ElevatorState.Ascending;
                Console.WriteLine($"Elevator {_elevatorNumber} {_state} from floor {_currentFloor.Number} to floor {nextFloor}");
            }
            else if (nextFloor < _currentFloor.Number)
            {
                _state = ElevatorState.Descending;
                Console.WriteLine($"Elevator {_elevatorNumber} {_state} from floor {_currentFloor.Number} to floor {nextFloor}");
            }
            else
            {
                _state = ElevatorState.Halt;
                Console.WriteLine($"Elevator {_elevatorNumber} is at {_state} on floor {nextFloor}");
            }

            _currentFloor = _currentFloor.Move(nextFloor);
        }

        private int NextFloor() =>
          _calls.NextFloor(_currentFloor.Number, _state);
    }
}
