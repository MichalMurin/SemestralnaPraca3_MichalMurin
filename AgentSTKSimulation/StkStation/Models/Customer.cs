﻿using AgentSim.StkStation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DISS_S2.StkStation
{
    public class Customer: INotifyPropertyChanged
    {
        public double StartWaitingTime { get; set; }
        private DateTime _startTimeForDebug;
        public bool HasParkingReserved { get; set; }
        public CarType CarType { get; set; }
        public int Id { get; set; }
        private CustomerSituation _situation;
        public CustomerSituation Situation
        {
            get { return _situation; }
            set
            {
                if (_situation == value)
                {
                    return;
                }
                _situation = value;
                OnPropertyChanged(nameof(Situation));
            } 
        }

        public Customer(double pStartWaitingTime, CarType carType, int id)
        {
            StartWaitingTime = pStartWaitingTime;
            _startTimeForDebug = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddHours(9).AddSeconds(StartWaitingTime);
            CarType = carType;
            Id = id;
            Situation = CustomerSituation.CREATED;
            HasParkingReserved = false;
        }

        public Customer(Customer other)
        {
            StartWaitingTime = other.StartWaitingTime;
            CarType = other.CarType;
            Id = other.Id;
            Situation = other.Situation;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Zakaznik {Id}, {CarType} {CustomerSitutationService.SituationToString(Situation)} ({_startTimeForDebug.ToString("HH:mm:ss")})";
        }
    }
}
