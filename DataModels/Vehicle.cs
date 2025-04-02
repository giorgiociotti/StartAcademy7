using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy7.DataModels
{
    public abstract class Vehicle
    {
        public string Brand {  get; set; }
        public string Model { get; set; }
        public decimal BasePrice { get; set; }
        public abstract MainEnumerators.CarEngine CarEngine { get; set; }
        public abstract decimal FinalPrice();
    }

    public class CarAuto : Vehicle
    {
        public override MainEnumerators.CarEngine CarEngine { get; set; }

        public override decimal FinalPrice()
        {
            return BasePrice * 1.2m;
        }
    }

    public class CarBenzina : Vehicle, IThermicEngine
    {
        public override MainEnumerators.CarEngine CarEngine { get; set; }
        public decimal EngineVol { get; set; }
        public string EngineFuel { get; set; }

        public override decimal FinalPrice()
        {
            return BasePrice * 1.15m;
        }
    }

    public class CarElettrica : Vehicle, IElectricEngine
    {
        public override MainEnumerators.CarEngine CarEngine { get; set; }
        public int BatteryPower { get; set; }
        public int AutonomyKm { get; set; }

        public override decimal FinalPrice()
        {
            return BasePrice * 1.3m;
        }
    }

    public interface IThermicEngine
    {
        decimal EngineVol { get; set; }
        string EngineFuel { get; set; }
    }

    public interface IElectricEngine
    {
        int BatteryPower { get; set; }
        int AutonomyKm { get; set; }
    }
    //*******************************************
    public class Animale
    {
        public virtual void Movimento()
        {
            Console.WriteLine("L'animale si muove");
        }
    }

    public class Cane : Animale
    {
        public override void Movimento()
        {
            Console.WriteLine("Il cane abbaia e corre");
        }
    }

    public class Aquila: Animale
    {
        public override void Movimento()
        {
            base.Movimento();
            Console.WriteLine("MA l'aquila vola");
        }
    }



    public class LeggiFileGenerico
    {
        public virtual void ReadTxtFile()
        {
            // CI sarà il codice più o meno standard per leggere un file txt
        }
    }

    public class LeggiFileCSV : LeggiFileGenerico
    {
        public override void ReadTxtFile()
        {
            base.ReadTxtFile();
            // Codice specifico, ad esempio, per la separazione dei dati tramite carattere separatore
        }
    }
}
