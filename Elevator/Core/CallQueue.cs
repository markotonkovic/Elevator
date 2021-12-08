using System.Collections.Concurrent;

namespace Elevators.Core
{
    internal class CallQueue
    {
        private readonly ConcurrentDictionary<int, byte> _queue = new ConcurrentDictionary<int, byte>();

        internal void Enqueue(int floorNumber)
        {
            _queue.TryAdd(floorNumber, 0);
        }

        internal void Dequeue(int florNumber)
        {
            _queue.TryRemove(florNumber, out byte _);
        }

        internal int NextFloor(int currentFloor, ElevatorState state)
        {
            if(!_queue.Any()) 
                return currentFloor;

            int nextFloor;

            switch (state)
            {
                case ElevatorState.Ascending:
                    nextFloor = _queue.Keys.OrderBy(x => x).FirstOrDefault(x => x > currentFloor, currentFloor);
                    break;
                case ElevatorState.Descending:
                    nextFloor = _queue.Keys.OrderByDescending(x => x).FirstOrDefault(x => x > currentFloor, currentFloor);
                    break;
                default:
                    return _queue.Keys.OrderBy(x => x).FirstOrDefault(currentFloor);
            }

            return nextFloor == currentFloor ? _queue.Keys.OrderBy(x => x).FirstOrDefault(currentFloor) : nextFloor;
        }
    }
}
