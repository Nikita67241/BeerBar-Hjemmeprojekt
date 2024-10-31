namespace BeerBar_Hjemmeprojekt
{
    public class BeerExistsChecker
    {
        private BeerController _beerController;
        public BeerExistsChecker(BeerController beerController)
        {
            _beerController = beerController;
        }
        public bool DoesBeerExist(string filePath, string beerName, string beerType)
        {
            if (File.Exists(filePath))
            {
                string[] existingBeers = File.ReadAllLines(filePath);
                return existingBeers.Any(line =>
                {
                    string[] parts = line.Split(" - ");
                    return parts.Length > 1 && parts[0].Equals(beerName, StringComparison.OrdinalIgnoreCase) && parts[1].Equals(beerType, StringComparison.OrdinalIgnoreCase);
                });
            }
            return false;
        }

        public string CheckAndCreateBeer(string filePath, string beerName, string beerType)
        {
            bool beerExists = DoesBeerExist(filePath, beerName, beerType);

            if (beerExists)
            {
                return "Beer already exists and won't be added again.";
            }
            else
            {
                switch (beerType.ToLower())
                {
                    case "bottle":
                        _beerController.CreateBeer(beerName, BeerType.Bottle);
                        return "Beer added successfully!";
                        break;
                    case "tap":
                        _beerController.CreateBeer(beerName, BeerType.Tap);
                        return "Beer added successfully!";
                        break;
                    case "tin":
                        _beerController.CreateBeer(beerName, BeerType.Tin);
                        return "Beer added successfully!";
                        break;
                    default:
                        return "Error: Please enter a valid beer type.";
                        break;
                }
            }
        }
    }
}
