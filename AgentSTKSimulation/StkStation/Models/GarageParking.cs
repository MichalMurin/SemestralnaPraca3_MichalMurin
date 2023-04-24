using DISS_S2.StkStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation.Models
{
    /// <summary>
    /// Trieda na spravu parkoviska v dielni s kapacitou 5 aut
    /// </summary>
    public class GarageParking
    {
        public const int MAX_CARS_IN_PARKING_GARAGE = 5;
        // 
        private int _freeSpotsCount;
        private Queue<Customer> _parking;

        public GarageParking()
        {
            _parking = new Queue<Customer>();
            _freeSpotsCount = MAX_CARS_IN_PARKING_GARAGE;
        }

        public void ResetGarage()
        {
            _parking.Clear();
            _freeSpotsCount = MAX_CARS_IN_PARKING_GARAGE;
        }

        public int GetCarParked()
        {
            return _parking.Count;
        }
        public int GetFreeSpots()
        {
            return _freeSpotsCount;
        }

        public bool IsFreeSpot()
        {
            if (_freeSpotsCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReservePlaceForCar()
        {
            if (IsFreeSpot())
            {
                _freeSpotsCount--;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Nie je mozne rezervovat miesto! Parkovisko je plne vybookovane!");
            }
        }

        public void ParkCustomersCarInGrage(Customer customer)
        {
            if (_parking.Count < GarageParking.MAX_CARS_IN_PARKING_GARAGE)
            {
                _parking.Enqueue(customer);
                customer.Situation = CustomerSituation.WAITING_IN_GARAGE;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Nie je mozne zaparkovat vozidlo! Parkovisko je plne!");
            }
        }

        public bool IsWaitingCar()
        {
            if (_parking.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Customer GetCustomersCarFromParking()
        {
            if (IsWaitingCar())
            {
                _freeSpotsCount++;
                return _parking.Dequeue();
            }
            else
            {
                throw new ArgumentOutOfRangeException("Ziadne vozidlo momentalne necaka!");
            }
        }
    }
}
