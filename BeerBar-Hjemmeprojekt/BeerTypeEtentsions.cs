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
    }
}
