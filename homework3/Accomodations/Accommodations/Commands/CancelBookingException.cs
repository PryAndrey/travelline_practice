namespace Accommodations.Commands;
//New exception
public class InterruptionProcess : Exception
{
    public InterruptionProcess() : base() { }

    public InterruptionProcess(string message) : base(message) { }

    public InterruptionProcess(string message, Exception innerException) : base(message, innerException) { }
}