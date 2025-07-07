using Deconstruct;


#region stuff
//User Defined Deconstruction
var car = new Car(new Tire(235,65, 17)) { Make = "Tesla", Model = "Model 3" };

(int width, int aspectRatio, int diameter) = car;
(string make, string model) = car;

Console.WriteLine("** User Defined Deconstruction:");
Console.WriteLine($" width:       {width}"); // 235
Console.WriteLine($" aspectRatio: {aspectRatio}"); // 65
Console.WriteLine($" diameter:    {diameter}"); // 17
Console.WriteLine($" make:        {make}"); // Tesla
Console.WriteLine($" model:       {model}"); // Model 3
Console.WriteLine();


//Record deconstruction
(int tireWidth, int tireAspectRatio, int tireDiameter) = car.Tire;
Console.WriteLine("** Record Deconstruction:");
Console.WriteLine($" tireWidth:       {tireWidth}");
Console.WriteLine($" tireAspectRatio: {tireAspectRatio}");
Console.WriteLine($" tireDiameter:    {tireDiameter}");
Console.WriteLine();


//System type deconstruction
Console.WriteLine("** System Type Deconstruction");
var dictionary = new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } };
foreach (var (key, value) in dictionary)
{
    Console.WriteLine($" {key} = {value}");
}
Console.WriteLine();
#endregion


namespace Deconstruct
{

    public class Car(Tire tire)
    {
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public Tire Tire { get; set; } = tire;

        #region Deconstruct methods
        public void Deconstruct(out int width, out int aspectRatio, out int diameter)
        {
            width = Tire.Width;
            aspectRatio = Tire.AspectRatio;
            diameter = Tire.Diameter;
        }

        public void Deconstruct(out string make, out string model)
        {
            make = Make;
            model = Model;
        }

        public void Deconstruct(out string make, out string model, out int width, out int aspectRatio, out int diameter)
        {
            make = Make;
            model = Model;
            width = Tire.Width;
            aspectRatio = Tire.AspectRatio;
            diameter = Tire.Diameter;
        }
        #endregion
    }

    public record Tire(int Width, int AspectRatio, int Diameter);
}