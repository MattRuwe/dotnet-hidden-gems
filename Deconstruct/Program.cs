using Deconstruct;


#region stuff
////User Defined Deconstructing
//var car = new Car(new Tire() { Width = 235, AspectRatio = 65, Diameter = 17 }) { Make = "Tesla", Model = "Model 3" };

//(int width, int aspectRatio, int diameter) = car;
//(string make, string model) = car;


//Console.WriteLine(width); // 235
//Console.WriteLine(aspectRatio); // 65
//Console.WriteLine(diameter); // 17
//Console.WriteLine(make); // Tesla
//Console.WriteLine(model); // Model 3

////Record deconstructing
//(int tireWidth, int tireAspectRatio, int tireDiameter) = car.Tire;

//Console.WriteLine(tireWidth);
//Console.WriteLine(tireAspectRatio);
//Console.WriteLine(tireDiameter);


////Extension method for system types
//var dictionary = new Dictionary<string, string>() { { "key1", "value1" }, { "key1", "value2" } };
//foreach (var (key, value) in dictionary)
//{
//    Console.WriteLine(key);
//    Console.WriteLine(value);
//}
#endregion


namespace Deconstruct
{

    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public Car(Tire tire)
        {
            Tire = tire;
        }

        public Tire Tire { get; set; }

        #region Stuff
        //public void Deconstruct(out int width, out int aspectRation, out int diameter)
        //{
        //    width = Tire.Width;
        //    aspectRation = Tire.AspectRatio;
        //    diameter = Tire.Diameter;
        //}

        //public void Deconstruct(out string make, out string model)
        //{
        //    make = Make;
        //    model = Model;
        //}
        #endregion
    }

    public record Tire(int Width, int AspectRatio, int Diameter);
}