namespace Elevators.Interfaces
{
    internal interface IElevator : IDisposable
    {
        void Call(int flor);
        void GoTo(int flor);
    }
}
