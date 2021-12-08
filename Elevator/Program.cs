// See https://aka.ms/new-console-template for more information


using Elevators.Components;
using Elevators.Interfaces;

using (IBuilding building = new Building(10, 2))
{

    building.Call(0, 3);
    building.Call(1, 4);

    Thread.Sleep(2000);
    building.Call(1, 1);

    Thread.Sleep(3000);
    building.Call(0, 8);

    Thread.Sleep(2000);
    building.GoTo(0, 0);

    Console.ReadLine();
}

