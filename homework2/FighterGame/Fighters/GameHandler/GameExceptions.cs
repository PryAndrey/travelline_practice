namespace Fighters.GameHandler
{
    public class WarriorCountException : Exception
    {
        public WarriorCountException(string message) : base(message) { }
    }
    public class WrongInputException : Exception
    {
        public WrongInputException(string message) : base(message) { }
    }
}