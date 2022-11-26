
interface IImage
{
    void Display();
}

public class RealImage : IImage
{

    private string _fileName;

    public RealImage(string fileName)
    {
        _fileName = fileName;
        loadFromDisk(fileName);
    }

    public void Display()
    {
        Console.WriteLine($"Displaying {_fileName}");
    }

    private void loadFromDisk(string fileName)
    {
        Console.WriteLine($"Loading {fileName}");
    }
}

public class ProxyImage : IImage
{

    private RealImage? realImage;
    private string _fileName;

    public ProxyImage(string fileName)
    {
        _fileName = fileName;
    }

    public void Display()
    {
        if (realImage == null)
        {
            realImage = new RealImage(_fileName);
        }
        realImage.Display();
    }
}


class Program
{
    static void Main()
    {
        IImage image = new ProxyImage("test_10mb.jpg");

        //image will be loaded from disk
        image.Display();
        Console.WriteLine("\n");

        //image will not be loaded from disk
        image.Display();
    }
}