namespace fuhrpark;

public class Helper_functions
{
    public static void Write(string text)
    {
        Console.WriteLine(text);
    }

    public static String ReadString()
    {
        string text = Console.ReadLine();
        while (text is not string)
        {
            Console.Write($"{text} is not a string");
            text = Console.ReadLine();
        }

        return text;
    }
    public static int ReadInteger()
    {
        int intInput = 0;
        while (intInput == 0)
        {
            try
            {
                intInput = Int32.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Write("Kek das wahr kein Int \n Versuchs nochmal:");
            } ;
        }

        return intInput;
    }

    public static double ReadDouble()
    {
        double doubleInput = 0;
        while (doubleInput == 0)
        {
            try
            {
                doubleInput = double.Parse(Console.ReadLine()!);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                Write("Kek das wahr keine Double \n Versuchs nochmal:");
            } ;
        }

        return doubleInput;
    }
    /// <summary>
    /// Schreibt was in die Konsole und nimmt anschließend einen Input über die Konsole
    /// </summary>
    /// <param name="text">der Text der in der Konsoe Geschrieben werden soll</param>
    /// <returns>Returns eine Double aus dem Input der Konsole</returns>
    public static double ReadDoubleWrite(string text)
    {
        Write(text);
        return ReadDouble();
    }
    public static string ReadStringWrite(string text)
    {
        Write(text);
        return ReadString();
    }
    
}