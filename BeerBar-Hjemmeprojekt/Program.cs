namespace BeerBar_Hjemmeprojekt
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "beerMenu.txt";
            BeerRepository beerRepository = new BeerRepository();
            BeerController beerController = new BeerController(beerRepository);
            Console.WriteLine("to create a new beer in you menu type the beer name");
            string beerName = Console.ReadLine();
            try
            {
                Console.WriteLine("are you selling the beer in Bottle, on Tap or in Tin. enter Tap,Bottle or Tin");
                string beerType = Console.ReadLine();
                beerType = beerType.ToLower();

                bool beerExists = false;
                if (File.Exists(filePath))
                {
                    string[] existingBeers = File.ReadAllLines(filePath);
                    beerExists = existingBeers.Any(line =>
                    {
                        string[] parts = line.Split(" - ");
                        return parts.Length > 1 && parts[0].Equals(beerName, StringComparison.OrdinalIgnoreCase) && parts[1].Equals(beerType, StringComparison.OrdinalIgnoreCase);
                    });
                }


                if (beerExists)
                { Console.WriteLine("Beer already exists and wont be added again"); }

                else
                {
                    if (beerType == "bottle")
                    {
                        beerController.CreateBeer(beerName, BeerType.Bottle);
                        Console.WriteLine("Beer added successfully!");
                    }
                    else if (beerType == "tap")
                    {
                        beerController.CreateBeer(beerName, BeerType.Tap);
                        Console.WriteLine("Beer added successfully!");
                    }
                    else if (beerType == "tin")
                    {
                        beerController.CreateBeer(beerName, BeerType.Tin);
                        Console.WriteLine("Beer added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid beer type.");
                    }
                }
            }
            catch (Exception incorrectBeerType) { Console.WriteLine("Error: Please enter a valid beer type."); }





            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                foreach (var beer in beerController.GetAllBeers())
                {
                    writer.WriteLine($"{beer.Name} - {beer.Type} - Price: {beer.Price} DKK - Volume in cl {beer.Volume}");
                    Console.WriteLine($"{beer.Name} - {beer.Type} - Price: {beer.Price} DKK - Volume in cl {beer.Volume}");
                }
            }




            //Console.WriteLine("to view all beers in menu...
            //make a writer.read all lines in the file to show all beers or/and make a funktion to lookup a beer by name or all beers by tap...");

            //i want to make it so i cant add a beer that already exists or that if i add a beer that already exists it will overide it not create a new  done!! men spørg underviser om extra forklaring. eller venner.





        }
    }
}
