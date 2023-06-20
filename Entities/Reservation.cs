
using CustomExceptions.Entities.Exceptions;
using System.Security.Cryptography.X509Certificates;

namespace CustomExceptions.Entities
{
    public class Reservation
    {
        public int RoomNumber { get; private set; }
        public DateTime CheckIn { get; private set; }
        public DateTime CheckOut { get; private set; }

        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut) 
        {
            if (CheckOut < CheckIn)
            {
                throw new DomainException("Check-out date must be after check-in date.");
            }

            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        public void UpdateReservation(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            if (CheckIn < now || CheckOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates.");
            }
            if(CheckOut <= CheckIn)
            {
                throw new DomainException("Check-out date must be after check-in date.");
            }

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public override string ToString() 
        {
            return "Room number: "
                + RoomNumber
                + ", check-in date: "
                + CheckIn.ToString("dd/MM/yyyy")
                + ", check-out date: "
                + CheckOut.ToString("dd/MM/yyyy")
                + " - "
                + Duration()
                + " nights.";
        }
    }
}
