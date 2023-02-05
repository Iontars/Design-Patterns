using System;
namespace Polymorphism;

// проектированеи на уровне абстракций, без использования интерфейсов
public class Item
{
    public virtual void GetForm()
    {
        Console.WriteLine("has no form");
    }
}

public class Box : Item
{
    private float A { get; set; }
    private float B { get; set; }
    public Box(float a, float b)
    {
        A = a; B = b;
    }
    public override void GetForm()
    {
        Console.WriteLine("Box form");
        GetBoxArea();
    }
    public void GetBoxArea()
    {
        Console.WriteLine("Box area is: " + A * B);
    }
}

public class Sphere : Item
{
    private float Radius { get; set; }

    public Sphere(float radius)
    {
        Radius = radius;
    }
    public override void GetForm()
    {
        Console.WriteLine("Sphere form");
        GetSphereArea();
    }
    public void GetSphereArea()
    {
        Console.WriteLine("Sphere area is: " + (Radius * Radius * (float)Math.PI));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Item item = new();
        Item box = new Box(2,4);
        Item sphere = new Sphere(4);
        box.GetForm();
        sphere.GetForm();
        
    }
}

