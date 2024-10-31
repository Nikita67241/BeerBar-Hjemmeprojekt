namespace BeerBar_Hjemmeprojekt
{
    public class BeerRepository
    {
        private List<Beer> beers = new List<Beer>();
        public void AddBeer(Beer beer)
        {
            beers.Add(beer);
        }

        public void UpdateBeer(Beer beer)
        {
            Beer existingBeer = beers.FirstOrDefault(b => b.Name == beer.Name);
            if (existingBeer != null)
            {
                existingBeer.Type = beer.Type;
                existingBeer.Price = beer.Price;
                existingBeer.Volume = beer.Volume;
            }
        }

        public Beer GetBeerByName(string name)
        {
            return beers.FirstOrDefault(b => b.Name == name);

        }
        public List<Beer> GetAllBeers()
        {
            return beers;
        }


    }
}
