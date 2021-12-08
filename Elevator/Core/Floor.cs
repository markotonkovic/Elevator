namespace Elevators.Core
{
    internal class Floor
    {
        private readonly Floor _previous;
        private Floor _next;

        internal int Number { get; private set; }

        public Floor(int number, Floor prev)
        {
            Number = number;
            _previous = prev;

            if(_previous != null)
                _previous.SetNext(this);
        }

        public Floor Move(int floorNumber)
        {
            if (floorNumber > Number)
                return _next ?? this;
            if (floorNumber < Number)
                return _previous ?? this;
            else
                return this;
        }

        public Floor First() 
            => _previous == null ? this : _previous.First();

        public void SetNext(Floor floor) 
            => _next = floor;
    }
}
