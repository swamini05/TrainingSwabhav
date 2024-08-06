namespace CommandDesignPatternDemo.Models
{
    internal class OnCommand : ICommand
    {
        private Television _tv;
        public OnCommand(Television tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.On();
        }
    }
}
