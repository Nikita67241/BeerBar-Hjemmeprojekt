namespace BeerBar_Hjemmeprojekt
{
    public class Beer
    {
        //private string name;

        //private BeerType type;
        //private double price; 
        //private int volume;

        public string Name { get; set; }
        public BeerType Type { get; set; }
        public double Price { get; set; }
        public int Volume { get; set; }


        public Beer(string name, BeerType type)
        {
            Name = name;
            Type = type;
            Price = type.GetPrice();
            Volume = type.GetVolume();
        }
        public static double GetPrice(BeerType type)
        {
            return BeerTypeEtentsions.GetPrice(type);
        }

        public static int GetVolume(BeerType type)
        {
            return BeerTypeEtentsions.GetVolume(type);
        }


    }
}

