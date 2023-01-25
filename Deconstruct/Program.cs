var car = new Car(new Tire() { Width = 235, AspectRatio = 65, Diameter = 17 }) { Make = "Tesla", Model = "Model 3" };

(int width, int aspectRatio, int diameter) = car;
(string make, string model) = car;


Console.WriteLine(width); // 235
Console.WriteLine(aspectRatio); // 65
Console.WriteLine(diameter); // 17
Console.WriteLine(make); // Tesla
Console.WriteLine(model); // Model 3

(int tireWidth, int tireAspectRatio, int tireDiameter) = car.Tire;

Console.WriteLine(tireWidth);




public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public Car(Tire tire)
    {
        Tire = tire;
    }

    public Tire Tire { get; set; }

    public void Deconstruct(out int width, out int aspectRation, out int diameter)
    {
        width = Tire.Width;
        aspectRation = Tire.AspectRatio;
        diameter = Tire.Diameter;
    }

    public void Deconstruct(out string make, out string model)
    {
        make = Make;
        model = Model;
    }
}

public record Tire(int Width, int AspectRatio, int Diameter);