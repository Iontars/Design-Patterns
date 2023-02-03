using System.Numerics;

namespace TrueFactoryMethod_2;

public class EmployeeData
{
    public static List<Employee> pixelDesignerList= new List<Employee>();
    public static List<Employee> VectorDesignerList= new List<Employee>();
    public static List<Employee> TeamLeads = new List<Employee>();

    public void FillDataList()
    {
        pixelDesignerList.Add(new(1, "Mark"));
        pixelDesignerList.Add(new(2, "Frank"));

        VectorDesignerList.Add(new(3, "Marry"));
        VectorDesignerList.Add(new(4, "Ann"));

        TeamLeads.Add(new(5, "Denis"));
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public abstract class Picture : IPaintingStyle
{
    public IDesignerInfo? Designer { get; set; }
    public string Name { get; set; }
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
        Console.WriteLine($" {Name}: {Width}x{Height} использована {DrawedBy()}, нарисовано {Designer?.Name}, {Designer?.ToolName}");
    }
}

public interface IPaintingStyle 
{
    // в данной примере методы интерфейса можно безболезненно удалить,
    // так как реализации прописаны в абстрактнном классе Picture
    // в данном примере интефейс выполняет функцию котнракта, обязывающего абстрактный класс иметь в себе реализации методов интерфейса
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
        Designer = new VectorDesigner();
        //Draw();
    }
    public override string DrawedBy() => "Векторная графика";
}

public class DesktopPicture : Picture, IPaintingStyle
{
    public DesktopPicture(string name, int width, int height) : base(name, width, height)
    {
        Name = name; Width = width; Height = height;
        Designer = new PixelDesigner();
        //Draw();
    }
    public override string DrawedBy() => "Пиксельная графика";  
}

abstract public class Designer // может быть и не абстрактным если надо сделать более широкую логику
{
    public virtual string? Name { get; set;}
    public string? ToolName { get; set; }
    public Designer(string name) => Name = name;
    public Designer() { }
    public IPaintingStyle DrawPicture(IPaintingStyle paintingStyle) => paintingStyle; 
}

public class PixelDesigner : Designer, IDesignerInfo
{
    public string ShowToolBox() => "Использует Photoshop";
    public PixelDesigner(string name) : base(name) => Name = name;
    public PixelDesigner()
    {
        ToolName = ShowToolBox();
        Name = EmployeeData.pixelDesignerList[new Random().Next(0,2)].Name;
    }
    public WebPicture DrawPicture(string name, int width, int height) => new WebPicture(name, width, height);  
}

public class VectorDesigner : Designer, IDesignerInfo
{
    public string ShowToolBox() => "Использует Illustrator";
    public VectorDesigner(string name) : base(name) => Name = name;
    public VectorDesigner()
    {
        ToolName = ShowToolBox();
        Name = EmployeeData.VectorDesignerList[new Random().Next(0, 2)].Name; ;
    }
    public DesktopPicture DrawPicture(string name, int width, int height) => new DesktopPicture(name, width, height);
}

public interface IDesignerInfo
{
    public string? Name { get; set;}
    public string? ToolName { get; set; }
    public string ShowToolBox();
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeData employeeData = new();
        employeeData.FillDataList();

        PixelDesigner pixelDesigner = new();
        IPaintingStyle samePixelPicture = pixelDesigner.DrawPicture("Sun", 600, 800);
        VectorDesigner vectorlDesigner = new();
        IPaintingStyle vectorPicture = vectorlDesigner.DrawPicture("Moon", 256, 256);
        samePixelPicture.Draw();
        vectorPicture.Draw();


    }
}

