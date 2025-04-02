using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.BLogic
{
    public class Oop
    {
        public abstract class Person
        {
            public abstract string Name { get; set; }
        }

        public abstract class GeometricObject
        {
            public abstract double ComputeArea();
            public abstract double ComputePerimeter();
            public void Show() => Console.WriteLine("Display this Geometric Object");
        }

        public interface IGeometricName
        {
            void ExplainComputeArea(string objectName);
        }

        public interface IPerimeterFunction
        {
            double GetPerimeter();
        }
        public class SquareArea : GeometricObject
        {
            public override double ComputeArea()
            {
                Console.WriteLine($"L'area di un quadrato, è dato dal prodotto dei due lati, o lato elevato al quadrato, es, quadrato di lato 4: {4 * 4}");
                return 4 * 4;
            }

            public override double ComputePerimeter()
            {
                return 0.0;
            }
        }

        public class CircleArea : GeometricObject, IGeometricName, IPerimeterFunction
        {
            private string name = string.Empty;
            public override double ComputeArea()
            {
                Console.WriteLine($"L'area di un cerchio, r al quadrato x pigreco, es 4*4*pigreco: {(4 * 4) * Math.PI}");
                return (4 * 4) * Math.PI;
            }

            public override double ComputePerimeter()
            {
                throw new NotImplementedException();
            }

            public void ExplainComputeArea(string objectName)
            {
                throw new NotImplementedException();
            }

            public double GetPerimeter()
            {
                throw new NotImplementedException();
            }
        }


        public class Circle : CircleArea
        {
            public Circle()
            {
            }

            public double GetRadius(double circleValue)
            {
                return 0.0;
            }

            public override double ComputeArea()
            {
                base.ComputeArea();
                // aggiungo il mio codice specifico dopo che ho eseguito il metodo della classe base

                return 1.0;
            }
        }
    }
}
