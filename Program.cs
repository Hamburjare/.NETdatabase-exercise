using Varastonhallinta;

StartMenu();

static void StartMenu()
{
    Console.WriteLine("1 - Lisää tuote");
    Console.WriteLine("2 - Poista tuote");
    Console.WriteLine("3 - Tulosta eri tuotteiden saldo");
    Console.WriteLine("4 - Muokkaa tuotenimeä");
    Console.WriteLine("0 - Lopeta");
    Console.Write("Valitse vaihtoehto: ");
    string vastaus = Console.ReadLine();
    switch (vastaus)
    {
        case "1":
            AddProduct();
            Console.Clear();
            break;
    }
}

static bool AddProduct()
{
    string newProductName;
    int newProductPrice;
    int newProductAmount;

    Console.Write("Anna tuotteelle nimi: ");
    newProductName = Console.ReadLine();

    Console.Write("Anna tuotteen hinta: ");
    newProductPrice = Convert.ToInt32(Console.ReadLine());

    Console.Write("Anna tuotteen saldo: ");
    newProductAmount = Convert.ToInt32(Console.ReadLine());

    using (StorageControl varastonhallinta = new())
    {
        Varasto storage = new()
        {
            Tuotenimi = newProductName,
            Tuotehinta = newProductPrice,
            Saldo = newProductAmount
        };
        varastonhallinta.Tuotteet?.Add(storage);
        int affected = varastonhallinta.SaveChanges();
        Console.Clear();

        if (affected != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Tuotteen lisääminen ei onnistunut.");
            Console.ResetColor();
            StartMenu();
            return false;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tuote lisätty onnistuneesti.");
        Console.ResetColor();
        StartMenu();
        return (affected == 1);
    }

}