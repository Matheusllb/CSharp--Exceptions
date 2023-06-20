using CustomExceptions.Entities;
using CustomExceptions.Entities.Exceptions;

namespace CustomExceptions
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.Write("Room number: ");
                int roomNumber = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation r = new Reservation(roomNumber, checkIn, checkOut);
                Console.Write("Reservation: " + r);

                Console.WriteLine();
                Console.WriteLine("Enter the date to update reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                r.UpdateReservation(checkIn, checkOut);
                Console.Write("Reservation: " + r);
            }
            catch (DomainException ex)
            {
                Console.WriteLine("Error in reservation: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Format error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
