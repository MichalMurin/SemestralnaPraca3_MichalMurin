using AgentSTKSimulation.StkStation.Models;
using DISS_S2.StkStation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentSim.StkStation.Models
{
    public class Worker: INotifyPropertyChanged
    {
        public bool IsBusy { get; set; }
        public bool HadLunch { get; set; }

        public int CustomerId { get; set; }
        private Work _work;
        public Work Work
        {
            get { return _work; }
            set
            {
                if (_work == value)
                {
                    return;
                }
                _work = value;
                OnPropertyChanged(nameof(Work));
            }
        }
        public int Id { get; set; }

        public Worker(int id)
        {
            CustomerId = -1;
            IsBusy = false;
            Id = id;
            Work = Work.UNKNOWN;
            HadLunch = false;
        }
        public Worker(Worker other)
        {
            IsBusy = other.IsBusy;
            Id = other.Id;
            Work = other.Work;
            HadLunch = other.HadLunch;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
