using Accommodations.Models;

namespace Accommodations.Commands;
//new exception
public class InterruptionProcess : Exception
{
    public InterruptionProcess() : base() { }

    public InterruptionProcess(string message) : base(message) { }

    public InterruptionProcess(string message, Exception innerException) : base(message, innerException) { }
}

public class CancelBookingCommand(IBookingService bookingService, Guid bookingId) : ICommand
{
    private Booking? _canceledBooking;

    public void Execute()
    {
        _canceledBooking = bookingService.FindBookingById(bookingId);
        if (_canceledBooking != null)
        {
            bookingService.CancelBooking(bookingId);
            decimal cancellationPenalty = bookingService.CalculateCancellationPenaltyAmount(_canceledBooking);
            Console.WriteLine($"Booking {_canceledBooking.Id} was canceled. Cancellation penalty: {cancellationPenalty}");
        }
        else
        {
            throw new InterruptionProcess($"Booking {bookingId} not found.");
        }
    }

    public void Undo()
    {
        Console.WriteLine("Undo for cancel is not supported");
    }
}
