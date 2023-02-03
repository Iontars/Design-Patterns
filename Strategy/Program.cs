namespace Strategy;

class Program
{
    static void Main(string[] args)
    {
        IMoveable moveable = new Car();
        Navigator navigator = new(moveable, 1000);
        navigator.Move();

        navigator.Moveable = new Foot();
        navigator.Move();

        navigator.Moveable = new Bicycle();
        navigator.Move();
    }
}

interface IMoveable
{
    void WayBy(int km);
}
class Car : IMoveable
{
    int speed = 60;
    public void WayBy(int distance)
        => Console.WriteLine($"На машине к точке назначения осталось {(double)distance / speed} часов");
}
class Foot : IMoveable
{
    int speed = 5;
    public void WayBy(int distance)
        => Console.WriteLine($"Пешком к точке назначения осталось {(double)distance / speed} часов");
}
class Bicycle : IMoveable
{
    int speed = 15;
    public void WayBy(int distance)
        => Console.WriteLine($"На велосипеде к точке назначения осталось {(double)distance / speed} часов");
}

class Navigator
{
    public IMoveable Moveable { private get; set; }
    public int Distance { get; init; }
    public Navigator(IMoveable moveable, int distance) => (Moveable, Distance) = (moveable, distance);

    public void Move() => Moveable?.WayBy(Distance);
}

