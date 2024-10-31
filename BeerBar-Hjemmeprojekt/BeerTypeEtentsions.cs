namespace BeerBar_Hjemmeprojekt
{
    public static class BeerTypeEtentsions
    {
        public static double GetPrice(this BeerType type)
        {
            return type switch
            {
                BeerType.Bottle => 25.0,
                BeerType.Tin => 20.0,
                BeerType.Tap => 25.0,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        public static int GetVolume(this BeerType type)
        {
            return type switch
            {
                BeerType.Bottle => 33,
                BeerType.Tin => 33,
                BeerType.Tap => 50,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        public static bool DoesBeerExists(string filePath, string beerName, BeerType beerType)
        {

            if (File.Exists(filePath))
            {
                string[] existingBeers = File.ReadAllLines(filePath);
                return existingBeers.Any(line =>
                {
                    string[] parts = line.Split(" - ");
                    return parts.Length > 1 &&
                    parts[0].Equals(beerName, StringComparison.OrdinalIgnoreCase) &&
                    parts[1].Equals(beerType.ToString(), StringComparison.OrdinalIgnoreCase);
                });
            }
            return false;
        }
    }

}
