namespace State;

class Program
{
    static void Main(string[] args)
    {
        Water water = new Water(new SolidWaterState());
        water.Heat();
        water.Heat();
        water.Frost();
        water.Frost();

        Console.WriteLine(water.CurrentState());
    }
}
class Water
{
    public IWaterState State { get; set; }

    public Water(IWaterState waterState)
    {
        State = waterState;
    }

    public void Heat()
    {
        State.Heat(this);
    }
    public void Frost()
    {
        State.Frost(this);
    }
    public string CurrentState()
    {
        return State.Name;
    }
}

interface IWaterState
{
    public string Name { get; }
    void Heat(Water water);
    void Frost(Water water);
}

class SolidWaterState : IWaterState
{
    public string Name => "Твёрдый";

    public void Heat(Water water)
    {
        Console.WriteLine("Превращаем лед в жидкость");
        water.State = new LiquidWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Продолжаем заморозку льда");
    }
}
class LiquidWaterState : IWaterState
{
    public string Name => "Жидкий";

    public void Heat(Water water)
    {
        Console.WriteLine("Превращаем жидкость в пар");
        water.State = new GasWaterState();
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Превращаем жидкость в лед");
        water.State = new SolidWaterState();
    }
}
class GasWaterState : IWaterState
{
    public string Name => "Газ";

    public void Heat(Water water)
    {
        Console.WriteLine("Повышаем температуру водяного пара");
    }

    public void Frost(Water water)
    {
        Console.WriteLine("Превращаем водяной пар в жидкость");
        water.State = new LiquidWaterState();
    }
}



