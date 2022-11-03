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
        case "2":
            DeleteProduct();
            Console.Clear();
            break;
        case "3":
            PrintProduct();
            Console.Clear();
            break;
        case "0":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Väärä valinta!");
            Console.Clear();
            StartMenu();
            break;
    }
}

static void AddProduct()
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
            Tuotenimi = newProductName?.ToLower(),
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
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tuote lisätty onnistuneesti.");
        Console.ResetColor();
        StartMenu();
        return;
    }

}

static void DeleteProduct()
{
    string productName;

    Console.Write("Anna tuotteen nimi: ");
    productName = Console.ReadLine();

    using (StorageControl varastonhallinta = new())
    {
        Varasto productDelete = varastonhallinta.Tuotteet?.Find(productName?.ToLower());
        if (productDelete is null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Tuotetta ({productName}) ei löytynyt!");
            Console.ResetColor();
            return;
        }
        else
        {
            varastonhallinta.Remove(productDelete);
            int affected = varastonhallinta.SaveChanges();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Tuote ({productName}) poistettu onnistuneesti.");
            Console.ResetColor();
            StartMenu();
            return;
        }
    }
}

static void PrintProduct()
{
    using (StorageControl varastonhallinta = new())
    {
        var products = varastonhallinta.Tuotteet?.ToList();
        Console.Clear();
        Console.WriteLine("Tuotteet:");
        foreach (var product in products)
        {
            Console.WriteLine($"Tuotenimi: {product.Tuotenimi}, Hinta: {product.Tuotehinta}, Saldo: {product.Saldo}");
            Console.WriteLine();
        }
        StartMenu();
        return;
    }
}
