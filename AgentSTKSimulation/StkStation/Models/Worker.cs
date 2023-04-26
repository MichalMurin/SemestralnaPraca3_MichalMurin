using AgentSTKSimulation.StkStation.Models;
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
        public bool IsWorking { get; set; }
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
            IsWorking = false;
            Id = id;
            Work = Work.UNKNOWN;
        }
        public Worker(Worker other)
        {
            IsWorking = other.IsWorking;
            Id = other.Id;
            Work = other.Work;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
