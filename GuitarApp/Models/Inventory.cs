namespace GuitarApp.Models
{
    internal class Inventory
    {
        public List<Guitar> Guitars { get; set; } = new List<Guitar>();

        public void AddGuitar(Guitar guitar)
        {
            Guitars.Add(guitar);
        }
        public Guitar GetGuitar(string serialNumber)
        {
            return Guitars.Find(g => g.SerialNumber == serialNumber);
        }
        public List<Guitar> Search(GuitarSpecs searchSpecs)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();

            foreach (var guitar in Guitars)
            {
                if (guitar.GuitarSpecs.Matches(searchSpecs))
                {
                    matchingGuitars.Add(guitar);
                }
            }

            return matchingGuitars;
        }
    }
}
