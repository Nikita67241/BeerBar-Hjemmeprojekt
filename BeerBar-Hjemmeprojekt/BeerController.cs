namespace BeerBar_Hjemmeprojekt
{
    public class BeerController
    {
        private BeerRepository beerRepository;

        public BeerController(BeerRepository beerRepository)
        {
            this.beerRepository = beerRepository;
        }
        public void CreateBeer(string name, BeerType type)
        {
            Beer beer = new Beer(name, type);
            beerRepository.AddBeer(beer);
        }
        public void UpdateBeer(string name, BeerType type)
        {
            Beer beer = beerRepository.GetBeerByName(name);
            if (beer != null)
            {
                beer.Type = type;
                beer.Price = type.GetPrice();
                beer.Volume = type.GetVolume();
                beerRepository.UpdateBeer(beer);
            }

        }
        public Beer GetBeer(string name)
        {
            return beerRepository.GetBeerByName(name);
        }

        public List<Beer> GetAllBeers()
        {
            return beerRepository.GetAllBeers();
        }

    }
}
