namespace TrueFactoryMethod_2;

public abstract class Picture : IPaintingStyle
{
    SeniorDesigner designer = new();

    public string? Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public Picture(string name, int width, int height)
    {
        Name = name;
        Width = width;
        Height = height;
    }
    public abstract string DrawedBy();
    public void Draw()
    {
        Console.WriteLine($" {Name}: {Width}x{Height} использована {DrawedBy()}");
    }
}

public interface IPaintingStyle 
{
    // в данной примере методы интерфейса можно безболезненно удалить,
    // так как реализации прописаны в абстрактнном классе Picture
    // данном примере интефейс выполняет функцию котнракта, обязывающего абстрактный класс иметь в себе реализации методов интерфейса
    // однако удалив методы из данного интерфейса мы не сможем вызвать эти методы, через объект интерфейса Например:
    // IPaintingStyle desktopPicture = new DesktopPicture("Star", 480, 640); desktopPicture.DrawedBy();
    // картина всё равно будет нарисована благодаря абстрактному классу но узнать инструмент используимый для рисования, не выйдет, метод DrawedBy(); не будет доступен
    public abstract string DrawedBy();
    public void Draw();
}

public class WebPicture : Picture, IPaintingStyle
{
    public WebPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    public override string DrawedBy() => "Векторная графика";
}

public class DesktopPicture : Picture, IPaintingStyle
{
    public DesktopPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Draw();
    }
    public override string DrawedBy() => "Пиксельная графика";  
}

public class SeniorDesigner : IDesignerInfo
{
    public string Name { get; set;}
    public string ShowToolBox() => "Использует все инструменты";
    public SeniorDesigner(string name) => Name = name;
    public IPaintingStyle DrawPicture(IPaintingStyle paintingStyle) => paintingStyle; // статический полиморфизм
}

public class PixelDesigner : SeniorDesigner, IDesignerInfo
{
    public new string Name { get; set; }
    public new string ShowToolBox() => "Использует Photoshop";
    public PixelDesigner(string name) : base(name) => Name = name;
    public WebPicture DrawPicture(string name, int width, int height) => new WebPicture(name, width, height);  
}

public class VectorDesigner : SeniorDesigner, IDesignerInfo
{
    public new string Name { get; set; }
    public new string ShowToolBox() => "Использует Illustrator";
    public VectorDesigner(string name) : base(name) => Name = name;
    public DesktopPicture DrawPicture(string name, int width, int height) => new DesktopPicture(name, width, height);
}

interface IDesignerInfo
{
    public string ShowToolBox();
}

class Program
{
    static void Main(string[] args)
    {
        // сеньёру необходимо дать точное ТЗ
        SeniorDesigner seniorDesigner = new("Victor");
        Picture pixelPicture = (DesktopPicture)seniorDesigner.DrawPicture(new DesktopPicture("Sun", 600, 800));
        SeniorDesigner seniorDesignerV2 = new("Marry");
        Picture vectorPicture = (WebPicture)seniorDesignerV2.DrawPicture(new WebPicture("Moon", 256, 256)); 

        // профильный работник и так знает что делать
        PixelDesigner pixelDesigner = new("Mark");
        Picture samePixelPicture = pixelDesigner.DrawPicture("Cloud", 1080, 1920);

    }
}

