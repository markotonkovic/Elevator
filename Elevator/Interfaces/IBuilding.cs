namespace Elevators.Interfaces
{
    internal interface IBuilding : IDisposable
    {
        void Call(int elevator, int floor);
        void GoTo(int elevator, int floor);
    }
}
