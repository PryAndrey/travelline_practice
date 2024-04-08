using System.Globalization;
using Accommodations;
using Accommodations.Commands;
using Accommodations.Dto;
using Accommodations.Models;

namespace Accommodations;

public static class AccommodationsProcessor
{
    private static BookingService _bookingService = new();
    private static Dictionary<int, ICommand> _executedCommands = new();
    private static int s_commandIndex = 0;

    public static void Run()
    {
        Console.WriteLine("Booking Command Line Interface");
        Console.WriteLine("Commands:");
        Console.WriteLine("'book <UserId> <Category> <StartDate> <EndDate> <Currency>' - to book a room");
        Console.WriteLine("'cancel <BookingId>'                                        - to cancel a booking");
        Console.WriteLine("'undo'                                                      - to undo the last command");
        Console.WriteLine("'find <BookingId>'                                          - to find a booking by ID");
        Console.WriteLine("'search <StartDate> <EndDate> <CategoryName>'               - to search bookings");
        Console.WriteLine("'exit'                                                      - to exit the application");

        string input;
        while ((input = Console.ReadLine()) != "exit")
        {
            try
            {
                ProcessCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InterruptionProcess ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    private static void ProcessCommand(string input)
    {
        string[] parts = input.Split(' ');
        string commandName = parts[0];

        switch (commandName)
        {
            case "book":
                if (parts.Length != 6)
                {
                    Console.WriteLine("Invalid number of arguments for booking.");
                    return;
                }

                //Check currency in CurrencyDto
                if (!Enum.TryParse(parts[5], true, out CurrencyDto currency))
                {
                    throw new ArgumentException($"Invalid Currency '{parts[5]}'. Input Rub/Usd/Cny");
                }

                //Check in and out dates
                if (!DateTime.TryParse(parts[3], CultureInfo.InvariantCulture, out DateTime bookStartDate))
                {
                    throw new ArgumentException("Invalid in date");
                }
                if (!DateTime.TryParse(parts[4], CultureInfo.InvariantCulture, out DateTime bookEndDate))
                {
                    throw new ArgumentException("Invalid out date");
                }

                BookingDto bookingDto = new()
                {
                    UserId = int.Parse(parts[1]),
                    Category = parts[2],
                    StartDate = bookStartDate,
                    EndDate = bookEndDate,
                    Currency = currency,
                };

                BookCommand bookCommand = new(_bookingService, bookingDto);
                bookCommand.Execute();
                _executedCommands.Add(++s_commandIndex, bookCommand);
                Console.WriteLine("Booking command run is successful.");
                break;

            case "cancel":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid number of arguments for canceling.");
                    return;
                }

                //Check Guid format
                if (!Guid.TryParse(parts[1], out Guid bookingId))
                {
                    throw new ArgumentException($"Invalid Guid format '{parts[1]}'.");
                }
                CancelBookingCommand cancelCommand = new(_bookingService, bookingId);
                cancelCommand.Execute();
                _executedCommands.Add(++s_commandIndex, cancelCommand);
                Console.WriteLine("Cancellation command run is successful.");
                break;

            case "undo":
                //check empty history stack
                if (s_commandIndex == 0)
                {
                    Console.WriteLine("There's nothing to undo.");
                    return;
                }
                // if undo create booking which was cancel then returned exception.
                // And next undo of history is broken.
                try
                {
                    _executedCommands[s_commandIndex].Undo();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Undo Error: {ex.Message}");
                }
                _executedCommands.Remove(s_commandIndex);
                s_commandIndex--;
                Console.WriteLine("Last command undone.");

                break;
            case "find":
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid arguments for 'find'. Expected format: 'find <BookingId>'");
                    return;
                }
                //Check Guid format
                if (!Guid.TryParse(parts[1], out Guid id))
                {
                    throw new ArgumentException($"Invalid Guid format '{parts[1]}'.");
                }
                FindBookingByIdCommand findCommand = new(_bookingService, id);
                findCommand.Execute();
                break;

            case "search":
                if (parts.Length != 4)
                {
                    Console.WriteLine("Invalid arguments for 'search'. Expected format: 'search <StartDate> <EndDate> <CategoryName>'");
                    return;
                }
                //Check in and out dates
                if (!DateTime.TryParse(parts[1], CultureInfo.InvariantCulture, out DateTime searchingStartDate))
                {
                    throw new ArgumentException("Incorrect in date");
                }
                if (!DateTime.TryParse(parts[2], CultureInfo.InvariantCulture, out DateTime searchingEndDate))
                {
                    throw new ArgumentException("Incorrect out date");
                }
                string categoryName = parts[3];
                SearchBookingsCommand searchCommand = new(_bookingService, searchingStartDate, searchingEndDate, categoryName);
                searchCommand.Execute();
                break;

            default:
                Console.WriteLine("Unknown command.");
                break;
        }
    }
}
/*
test input

book 1-5 Standard/Deluxe 04/08/2024< 04/08/2024< rub/usd/cny

book 1 Standard 4/08/2024 5/01/2024 cny
book 5 Standard 4/09/2024 5/06/2024 rub
book 2 Standard 4/13/2024 5/05/2024 rub
book 4 Standard 4/20/2024 5/09/2024 usd
book 2 Deluxe 4/10/2024 5/02/2024 usd
book 3 Deluxe 4/17/2024 5/03/2024 rub
book 3 Deluxe 4/17/2024 5/02/2024 cny
book 1 Deluxe 4/27/2024 5/07/2024 cny

search 4/17/2024 5/10/2024 Standard
search 4/20/2024 5/10/2024 Standard
search 4/08/2024 5/05/2024 Standard

search 4/17/2024 5/10/2024 Deluxe
search 4/20/2024 5/10/2024 Deluxe
search 4/08/2024 5/05/2024 Deluxe
  
  */