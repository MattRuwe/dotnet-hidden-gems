namespace ImplicitConversionOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region stuff

            MyClass myClass1 = ClassConfiguration.ConfigOne; // Enum -> MyClass
            Console.WriteLine(myClass1.ClassConfig);

            Console.WriteLine("----");

            MyClass myClass2 = "Two"; // string -> MyClass
            ClassConfiguration classConfiguration2 = myClass2; // MyClass -> ClassConfiguration
            Console.WriteLine(classConfiguration2);

            Console.WriteLine("----");

            MyClass myClass3 = 3; // int -> MyClass
            Console.WriteLine(myClass3.ClassConfig);

            Console.WriteLine("----");

            Car honda = "Honda"; // string -> Honda
            Console.WriteLine($"Type of car: {honda.GetType().Name}");
            Console.WriteLine($"Top speed:   {honda.TopSpeed}");
            Console.WriteLine($"Is Electric: {((Honda)honda).IsElectric}");

            Console.WriteLine("----");

            Car prologue = "prologue"; // string -> Prologue
            Console.WriteLine($"Type of car: {prologue.GetType().Name}");
            Console.WriteLine($"Top speed:   {prologue.TopSpeed}");
            Console.WriteLine($"Is Electric: {((Prologue)prologue).IsElectric}");
            #endregion
        }
    }




}