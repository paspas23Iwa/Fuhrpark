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
          Console.WriteLine("Was wollen sie machen: \n 1. Fahrzeug Hinzufügen \n 2. Fahrzeug Anzeigen lassen \n 3. Fahrzeug nach Kennzeichen Löschen \n 0. Fuhrpark schließen ");
          Console.WriteLine("Nummer eingeben:");
            ConsoleKey key = Console.ReadKey().Key;
          switch (key)
          {
                case ConsoleKey.D1:
                  Console.WriteLine("Fahrzeug Hinzufügen");
                  Fuhrpark.instance.AddFahrzeug();
                  break;
                case ConsoleKey.D2:
                  Console.WriteLine("Fahrzeuge Anzeigen");
                  Fuhrpark.instance.FahrzeugeAnzeigen();
                  break;
                case ConsoleKey.D3:
                  Console.Clear();
                  Console.WriteLine("Fahrzeug nach Kennzeichen Löschen ");
                  Fuhrpark.instance.FahzeugNachKennzeichenLöschen(Helper_functions.ReadStringWrite("Kennzeichen zum Löschen Angeben:"));
                  break;

                case ConsoleKey.D0:
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
        Console.WriteLine("Nummer des FahrzeugTypes: \n 1.PKW \n 2.LKW");
        ConsoleKey key = Console.ReadKey(true).Key;
        string fahrzeugType;
        switch (key)
        {
            case ConsoleKey.D1:
                fahrzeugType = "PKW";
                break;
            case ConsoleKey.D2:
                fahrzeugType = "LKW";
                break;
            default:
                fahrzeugType = "PKW";
                break;
        }
        Console.Clear();
        switch (fahrzeugType)
        {
            case "PKW":
                PKW newPKW = new PKW();
                newPKW.fahrzeugTyp = "PKW";
                newPKW.Init();
                fahrzeugListe.Add(newPKW);
                break;
            case "LKW":
                LKW newLKW = new LKW();
                newLKW.fahrzeugTyp = "LKW";
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
        foreach (Fahrzeuge fahrzeug in fahrzeugListe)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Fahrzeugtype: {fahrzeug.fahrzeugTyp}");
            Console.WriteLine($"Model: {fahrzeug.modell}");
            Console.WriteLine($"Hersteller: {fahrzeug.hersteller}");
            Console.WriteLine($"FahrzeugNummer: {fahrzeug.fahrzeugNummer}");
            Console.WriteLine($"Kennzeichen: {fahrzeug.kennzeichen}");
            Console.WriteLine($"Baujahr: {fahrzeug.baujahr}");
            fahrzeug.SpecialInfosAusgeben();
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