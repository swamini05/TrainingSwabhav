using CommandDesignPatternDemo.Models;

namespace CommandDesignPatternDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Television tv = new Television();

            ICommand onCommand = new OnCommand(tv);
            ICommand offCommand = new OffCommand(tv);

            RemoteControl remote = new RemoteControl();

            remote.SetCommand(onCommand);
            remote.PressButton();
            remote.SetCommand(offCommand);
            remote.PressButton();

            Console.ReadLine();
        }
    }
}
