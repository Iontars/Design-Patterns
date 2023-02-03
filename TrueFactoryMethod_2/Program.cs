namespace TrueFactoryMethod_2;

public abstract class Picture : IPaintingStyle
{
    public string? Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string ToolName { get; set; }

    public Picture() 
    {

    }
    public Picture(string name, int width, int height) : this()
    {
        Name = name;
        Width = width;
        Height = height;
    }
    public string DrawBy() => ToolName;
    public void Draw()
    {
        Console.WriteLine($" {Name}: {Width}x{Height} использована {DrawBy()}");
    }
}

public interface IPaintingStyle
{
    public string ToolName { get;}
    public string DrawBy();
    public void Draw();
}

public class WebPicture : Picture, IPaintingStyle
{
    new string ToolName => "Пиксельная графика";
    public WebPicture() { }
    public WebPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    public new string DrawBy() => ToolName;
    
}

public class DesktopPicture : Picture, IPaintingStyle
{
    new string ToolName => "Пиксельная графика";
    public DesktopPicture() { }
    public DesktopPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    public new string DrawBy() => ToolName;
    
}

public class SeniorDesigner : IDesignerToolBox
{
    public string Name { get; set;}
    public string ShowToolBox() => "Использует все инструменты";
    public SeniorDesigner(string name) => Name = name;

    public IPaintingStyle DrawPicture(IPaintingStyle paintingStyle) => paintingStyle; // статический полиморфизм
}

public class PixelDesigner : SeniorDesigner, IDesignerToolBox
{
    public new string Name { get; set; }
    public new string ShowToolBox() => "Использует Photoshop";
    public PixelDesigner(string name) : base(name) => Name = name;

    public DesktopPicture DrawPicture(string name, int width, int height) => new DesktopPicture(name, width, height);
    
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

        Picture picture1 = new DesktopPicture();

    }
}

