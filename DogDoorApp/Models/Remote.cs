using System.Timers;
using Timer = System.Timers.Timer;

namespace DogDoorApp.Models
{
    internal class Remote
    {
        private DogDoor door;
        private Timer timer;

        public Remote(DogDoor door)
        {
            this.door = door;
        }

        public void PressButton()
        {
            Console.WriteLine("Pressing the remote control button...");
            if (door.IsOpen())
            {
                door.Close();
            }
            else
            {
                door.Open();
                StartCloseTimer();
            }
        }

        private void StartCloseTimer()
        {
            timer = new Timer(5000); // Set up the timer for 5000 milliseconds (5 seconds)
            timer.Elapsed += OnTimerElapsed; // Attach the event handler
            timer.AutoReset = false; // Make sure the timer only runs once
            timer.Enabled = true; // Start the timer
        }

        private void OnTimerElapsed(Object source, ElapsedEventArgs e)
        {
            door.Close();
            timer.Dispose(); // Dispose of the timer when done
        }
    }
}
