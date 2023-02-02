namespace TrueFactoryMethod_2;

public abstract class Picture : IPaintingStyle
{
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Picture(string name, int width, int height)
    {
        Name = name;
        Width = width;
        Height = height;
    }

    public abstract void Draw();
}

public interface IPaintingStyle
{
    //public string DrawBy();
    public void Draw();
}

public class WebPicture : Picture, IPaintingStyle
{
    public WebPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    //public string DrawBy() => "Векторная графика";
    public override void Draw()
    {
        Console.WriteLine(Name + " " + Width + "x" + Height);
    }
}

public class DesktopPicture : Picture, IPaintingStyle
{
    public DesktopPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    //public string DrawBy() => "Пиксельная графика";
    public override void Draw()
    {
        Console.WriteLine(Name + " " + Width +"x" + Height);
    }
}

public class SeniorDesigner : IDesignerToolBox
{
    public string Name { get; set;}
    public string ShowToolBox() => "Использует все инструменты";
    public SeniorDesigner(string name)
    {
        Name = name;
    }

    public IPaintingStyle DrawPicture(IPaintingStyle paintingStyle)
    {
        return paintingStyle;
    }
}

public class PixelDesigner : SeniorDesigner, IDesignerToolBox
{
    public new string Name { get; set; }
    public new string ShowToolBox() => "Использует Photoshop";
    public PixelDesigner(string name) : base(name)
    {
        Name = name;
    }

    public DesktopPicture DrawPicture(string name, int width, int height)
    {
        return new DesktopPicture(name, width, height);
    }
}

interface IDesignerToolBox
{
    public string ShowToolBox();
}

class Program
{
    static void Main(string[] args)
    {
        // сеньёру необходимо дать точное ТЗ
        SeniorDesigner seniorDesigner = new("Victor");
        Picture picture = (DesktopPicture)seniorDesigner.DrawPicture(new DesktopPicture("Sun", 600, 800));

        // профильный работник и так знает что делать
        PixelDesigner pixelDesigner = new("Mark");
        Picture pixelPicture = pixelDesigner.DrawPicture("Cloud", 1080, 1920);
    }
}

