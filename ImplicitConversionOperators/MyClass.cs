using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitConversionOperators
{
    public class MyClass(string classConfig)
    {
        public string ClassConfig { get; private init; } = classConfig;

        #region Implicit

        public static implicit operator ClassConfiguration(MyClass myClass)
        {
            switch (myClass.ClassConfig)
            {
                case "One":
                    return ClassConfiguration.ConfigOne;
                case "Two":
                    return ClassConfiguration.ConfigTwo;
                case "Three":
                    return ClassConfiguration.ConfigThree;
                default:
                    throw new InvalidOperationException("Invalid class configuration");
            }
        }

        public static implicit operator MyClass(ClassConfiguration classConfig)
        {
            switch (classConfig)
            {
                case ClassConfiguration.ConfigOne:
                    return new MyClass("One");
                case ClassConfiguration.ConfigTwo:
                    return new MyClass("Two");
                case ClassConfiguration.ConfigThree:
                    return new MyClass("Three");
                default:
                    return new MyClass("Unknown");
            }
        }

        public static implicit operator MyClass(string classConfig) => new MyClass(classConfig);

        public static implicit operator MyClass(int classConfig)
        {
            switch (classConfig)
            {
                case 1:
                    return new MyClass("One");
                case 2:
                    return new MyClass("Two");
                case 3:
                    return new MyClass("Three");
                default:
                    throw new InvalidOperationException("Invalid class configuration number");
            }
        }
        #endregion


    }

    public enum ClassConfiguration
    {
        ConfigOne,
        ConfigTwo,
        ConfigThree
    }
}
