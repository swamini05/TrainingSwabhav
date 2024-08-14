namespace DogDoorApp.Models
{
    internal class DogDoor
    {
        private bool open;

        public DogDoor()
        {
            this.open = false;
        }

        public void Open()
        {
            Console.WriteLine("The dog door opens.");
            open = true;
        }

        public void Close()
        {
            Console.WriteLine("The dog door closes.");
            open = false;
        }

        public bool IsOpen()
        {
            return open;
        }
    }
}
