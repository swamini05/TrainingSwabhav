namespace CommandDesignPatternDemo.Models
{
    internal class OffCommand : ICommand
    {
        private Television _tv;

        public OffCommand(Television tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.Off();
        }
    }
}
