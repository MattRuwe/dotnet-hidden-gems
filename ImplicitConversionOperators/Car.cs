using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitConversionOperators
{
    public abstract class Car
    {
        public abstract int TopSpeed { get; }

        public static implicit operator Car(string typeOfCar)
        {
            switch (typeOfCar.ToLower())
            {
                case "bmw":
                    return new Bmw();
                case "4series":
                    return new FourSeries();
                case "honda":
                    return new Honda();
                case "prologue":
                    return new Prologue();
                default:
                    throw new ArgumentException("Invalid car type");
            }
        }
    }

    public class Bmw : Car
    {
        public override int TopSpeed => 200;

        public virtual int NumberOfDoors => 4;
    }

    public class FourSeries : Bmw
    {
        public override int NumberOfDoors => 2;
    }

    public class Honda : Car
    {
        public override int TopSpeed => 100;

        public virtual bool IsElectric => false;
    }

    public class Prologue : Honda
    {
        public override bool IsElectric => true;
    }
}
