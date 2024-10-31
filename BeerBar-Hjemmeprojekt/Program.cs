namespace BeerBar_Hjemmeprojekt
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "beerMenu.txt";
            BeerRepository beerRepository = new BeerRepository();
            BeerController beerController = new BeerController(beerRepository);
            BeerExistsChecker beerExistsChecker = new BeerExistsChecker(beerController);

            bool running = true;
            int menuChoise;
            while (running == true)
            {
                Console.Clear();
                Console.WriteLine("press 1 to add new beer");
                Console.WriteLine("press 2 to see all beers");

                menuChoise = int.Parse(Console.ReadLine());
                if (menuChoise == 1)
                {
                    Console.Clear();
                    try
                    {
                        Console.WriteLine("to create a new beer in you menu type the beer name");
                        string beerName = Console.ReadLine();

                        beerName = beerName.ToLower();

                        Console.WriteLine("are you selling the beer in Bottle, on Tap or in Tin. enter Tap,Bottle or Tin");
                        string beerType = Console.ReadLine();

                        beerType.ToLower();

                        string resultMessage = beerExistsChecker.CheckAndCreateBeer(filePath, beerName, beerType);
                        Console.WriteLine(resultMessage);

                    }

                    catch (Exception incorrectBeerType) { Console.WriteLine("Error: Please enter a valid beer type."); }



                    // skriver nye øl ind i filen
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        foreach (var beer in beerController.GetAllBeers())
                        {
                            writer.WriteLine($"{beer.Name} - {beer.Type} - Price: {beer.Price} DKK - Volume in cl {beer.Volume}");
                            Console.WriteLine($"{beer.Name} - {beer.Type} - Price: {beer.Price} DKK - Volume in cl {beer.Volume}");

                        }
                    }
                    Console.ReadLine();
                }
                else if (menuChoise == 2)
                {
                    Console.Clear();
                    string textFromFile;
                    StreamReader sr = null;
                    sr = new StreamReader(filePath);
                    textFromFile = sr.ReadLine();

                    try
                    {

                        while (textFromFile != null)
                        {

                            Console.WriteLine(textFromFile);
                            textFromFile = sr.ReadLine();
                        }
                    }
                    catch (FileNotFoundException fNF) { Console.WriteLine($"File not found: {fNF.Message}"); }

                    catch (DirectoryNotFoundException dNF)
                    {
                        Console.WriteLine($"Directory not found: {dNF.Message}");
                    }

                    catch (Exception ex)
                    { Console.WriteLine($"there was an error: {ex.Message}"); }
                    finally
                    {
                        sr.Close();
                        Console.ReadLine();
                    }

                }
            }



            //make a writer.read all lines in the file to show all beers or/and make a funktion to lookup a beer by name or all beers by tap...");

            //i want to make it so i cant add a beer that already exists or that if i add a beer that already exists it will overide it not create a new  done!! men spørg underviser om extra forklaring. eller venner.





        }
    }
}
