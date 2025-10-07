using System.ComponentModel.Design;
using System.Runtime.InteropServices.JavaScript;

namespace fuhrpark;

public class Fahrzeuge
{
    public int fahrzeugNummer { get; set; }
    public String kennzeichen { get; set; }
    public String hersteller { get; set; }
    public String modell { get; set; }
    public int baujahr { get; set; }

    public Fahrzeuge()
    {
    }
    public void Init()
    {
        Console.WriteLine("Fahrzeugnummer:");
        fahrzeugNummer = Helper_functions.ReadInteger();

        bool existsAlready = true;
        while (existsAlready)
        {
            Console.WriteLine("ok");
            kennzeichen = Helper_functions.ReadStringWrite("Kennzeichen:");

            if (Fuhrpark.instance.fahrzeugListe.Where(x => x.kennzeichen == kennzeichen).ToList().Count > 0)
            {
                existsAlready = true;
                Console.WriteLine("Das Kennzeichen existiert schon.");
            }
            else
            {
                existsAlready = false;
            }
        }
        hersteller = Helper_functions.ReadStringWrite("Hersteller:");
        modell = Helper_functions.ReadStringWrite("Modell:");
        Helper_functions.Write("Baujahr");
        baujahr = Helper_functions.ReadInteger();

    }
    public virtual void SpecialInfosAusgeben()
    {
        Console.WriteLine("Special");
    }
}

public class PKW : Fahrzeuge
{
    public int türenanzahl { get; set; }

    public PKW()
    {
    }

    public void Init()
    {
        base.Init();
        Helper_functions.Write("Anzahl der PKW Türen");
        türenanzahl = Helper_functions.ReadInteger();
    }

    public override void SpecialInfosAusgeben()
    {
        Console.WriteLine($"Türenanzahl: {türenanzahl}");
    }
}

public class LKW : Fahrzeuge
{
    public int ladeLast { get; set; }
    public int achsen { get; set; }

    public LKW()
    {

    }

    public void Init()
    {
        base.Init();
        Helper_functions.Write("LKW Lade last in Tonnen");
        ladeLast = Helper_functions.ReadInteger();
        Helper_functions.Write("LKW Achsen");
        while (true)
        {
            int achsenTemp = Helper_functions.ReadInteger();
            if (achsenTemp >= 2)
            {
                achsen = achsenTemp;
                break;
            }
            Helper_functions.Write("LKW Achsen Ungültig bittde Gültige Anzahl angeben (>= 2)");
        }
    }
    public override void SpecialInfosAusgeben()
    {
        Console.WriteLine($"Lade last: {ladeLast} Tonnen");
        Console.WriteLine($"Achsen: {achsen}");
    }
}