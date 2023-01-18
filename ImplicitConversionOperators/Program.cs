namespace ImplicitConversionOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass1 = ClassConfiguration.ConfigOne;
            Console.WriteLine(myClass1.ClassConfig);

            Console.WriteLine("----");

            MyClass myClass2 = "Two"; // string -> MyClass
            ClassConfiguration classConfiguration2 = myClass2; // MyClass -> ClassConfiguration
            Console.WriteLine(classConfiguration2);

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
        }

        public static bool Try()
        {
            Console.WriteLine(1);
            return true;
        }
    }



    public class MyClass
    {
        public static implicit operator ClassConfiguration(MyClass myClass)
        {
            switch (myClass.ClassConfig)
            {
                case "One":
                    return ClassConfiguration.ConfigOne;
                case "Two":
                    return ClassConfiguration.ConfigTwo;
                default:
                    throw new InvalidOperationException("Invalid class configuration");
            }
        }

        public static implicit operator MyClass(ClassConfiguration classConfig)
        {
            switch (classConfig)
            {
                case ClassConfiguration.ConfigOne:
                    return new MyClass() { ClassConfig = "One" };
                case ClassConfiguration.ConfigTwo:
                    return new MyClass() { ClassConfig = "Two" };
                default:
                    return new MyClass() { ClassConfig = "Unknown" };
            }
        }

        public static implicit operator MyClass(string classConfig)
        {
            return new MyClass() { ClassConfig = classConfig };
        }

        public string ClassConfig { get; private set; }
    }

    public enum ClassConfiguration
    {
        ConfigOne,
        ConfigTwo
    }
}