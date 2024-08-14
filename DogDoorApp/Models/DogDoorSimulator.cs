namespace DogDoorApp.Models
{
    internal class DogDoorSimulator
    {
        public static void Run()
        {
            DogDoor door = new DogDoor();
            Remote remote = new Remote(door);

            Console.WriteLine("Fido barks to go outside...");
            remote.PressButton();

            Console.WriteLine("\nFido has gone outside...");

            try
            {
                System.Threading.Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("...but he's stuck outside!");
            Console.WriteLine("\nFido starts barking...");
            Console.WriteLine("...so Gina grabs the remote control.");

            remote.PressButton();

            Console.WriteLine("\nFido's back inside...");

            Console.ReadLine();
        }
    }
}
