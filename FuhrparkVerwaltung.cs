using System.Runtime.CompilerServices;

namespace fuhrpark;

public class FuhrparkVerwaltung
{
    public static void Main(string[] args)
    {
        Fuhrpark.instance.fahrzeugListe = JSONLoader.Load();
        while(true)
        {
          Console.WriteLine("Welcome to Fuhrpark verwaltung");
          Console.WriteLine("Was wollen sie machen: \n 1. Fahrzeug Hinzufügen \n 2. Fahrzeug Anzeigen lassen \n 3. Fahrzeug nach kennzeichen Löschen \n 0. Fuhrpark schließen ");
          Console.WriteLine("Nummer eingeben:");
          String number = Console.ReadLine();
          switch (number)
          {
              case "1":
                  Console.WriteLine("Fahrzeug Hinzufügen");
                  Fuhrpark.instance.AddFahrzeug();
                  break;
              case "2":
                  Console.WriteLine("Fahrzeuge Anzeigen");
                  Fuhrpark.instance.FahrzeugeAnzeigen();
                  break;
              case "3":
                  Console.Clear();
                  Console.WriteLine("Fahrzeug nach Kennzeichen Löschen ");
                  Fuhrpark.instance.FahzeugNachKennzeichenLöschen(Helper_functions.ReadStringWrite("Kennzeichen zum Löschen Angeben:"));
                  break;

                case "0":
                    return;
              default:
                  Console.WriteLine("Fahrzeug verwaltung 5");
                  break;
          }
          Console.Clear();
        }
    }
}

public class Fuhrpark
{
    public List<Fahrzeuge> fahrzeugListe = new List<Fahrzeuge>();
    public static Fuhrpark instance;

    static Fuhrpark()
    {
        instance = new Fuhrpark();
    }
    public void AddFahrzeug()
    {
        Console.Clear();
        string fahrzeugType = Helper_functions.ReadStringWrite("Nummer des FahrzeugTypes: \n 1.PKW \n 2.LKW");
        Console.Clear();
        switch (fahrzeugType)
        {
            case "1":
                PKW newPKW = new PKW();
                newPKW.Init();
                fahrzeugListe.Add(newPKW);
                break;
            case "2":
                LKW newLKW = new LKW();
                newLKW.Init();
                fahrzeugListe.Add(newLKW);
                break;
            default:
                Console.WriteLine("Ungültiger Fahrzeugtype");
                break;
        }
        Console.WriteLine($"FahrzeugCount {fahrzeugListe.Count}");
        JSONLoader.Save(fahrzeugListe);
    }

    public void FahrzeugeAnzeigen()
    {
        Console.Clear();
        Helper_functions.Write($"Anzahl der Fahrzeuge. {fahrzeugListe.Count}");
        foreach (Fahrzeuge Fahrzeug in fahrzeugListe)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Fahrzeugtype: {Fahrzeug.GetType().ToString().Replace("fuhrpark.", "")}");
            Console.WriteLine($"Model: {Fahrzeug.modell}");
            Console.WriteLine($"Hersteller: {Fahrzeug.hersteller}");
            Console.WriteLine($"FahrzeugNummer: {Fahrzeug.fahrzeugNummer}");
            Console.WriteLine($"Kennzeichen: {Fahrzeug.kennzeichen}");
            Console.WriteLine($"Baujahr: {Fahrzeug.baujahr}");
            Fahrzeug.SpecialInfosAusgeben();
        }
        Console.WriteLine("-------------------------");
        Helper_functions.ReadStringWrite("press enter to exit");
    }

    public void FahzeugNachKennzeichenLöschen(string kennzeichen)
    {
        Console.Clear();
        bool removed = false;
        
        foreach (var fahrzeug in fahrzeugListe)
        {
            if (kennzeichen == fahrzeug.kennzeichen)
            {
                removed = true;
                Console.WriteLine($"{fahrzeug} mit dem kennzeichen {fahrzeug.kennzeichen} wurde Entfernt");
                fahrzeugListe.Remove(fahrzeug);
                break;
            }
        }

        if (!removed)
        {
            Console.WriteLine($"Es wurde kein Fahrzeug mit dem Kennzeichen {kennzeichen} gefunden");
        }

        JSONLoader.Save(fahrzeugListe);
        Helper_functions.ReadStringWrite("press enter to exit");
    }
}