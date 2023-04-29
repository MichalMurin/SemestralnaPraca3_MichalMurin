using AgentSTKSimulation;
using DISS_S2.SimulationCore;
using DISS_S2.StkStation;
using AgentSim.StkStation.Models;
using OSPABA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using simulation;
using agents;
using managers;

namespace SemestralnaPraca3_MichalMurin.UserControls
{
    public partial class SlowModeUC : UserControl, OSPABA.ISimDelegate, ISimulationStoppable
    {
        private STKAgentSimulation _simulator;
        private bool _isSimulationRunning = false;
        private Thread _simulationThread;
        private BindingSource _bindingSourceCustomers = new BindingSource();
        private BindingSource _bindingSourceWorkers = new BindingSource();
        private bool _showQueues = false;
        public SlowModeUC(STKAgentSimulation core)
        {
            InitializeComponent();
            _simulator = core; 
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            ////
            ((SurroundingAgent)_simulator.FindAgent(SimId.SurroundingAgent)).AllCustomers.CollectionChanged += ListChanged;
            //_simulator.AllWorkers.CollectionChanged += ListChanged;
            ////
            _bindingSourceCustomers.DataSource = ((SurroundingAgent)_simulator.FindAgent(SimId.SurroundingAgent)).AllCustomers;
            //_bindingSourceWorkers.DataSource = _simulator.AllWorkers;
            CustomersListBox.DataSource = _bindingSourceCustomers;
            //WorkersListBox.DataSource = _bindingSourceWorkers;
        }


        private void ListChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                if (sender.GetType() == typeof(ObservableCollection<Customer>))
                {
                    var list = (ObservableCollection<Customer>)sender;
                    list[list.Count - 1].PropertyChanged += PropertyChanged;
                }
                if (sender.GetType() == typeof(ObservableCollection<Worker>))
                {
                    var list = (ObservableCollection<Worker>)sender;
                    list[list.Count - 1].PropertyChanged += PropertyChanged;
                }
                this.Invoke((MethodInvoker)delegate { UpdateCustomerListbox(); });
            }
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (_isSimulationRunning)
            {
                if (sender.GetType() == typeof(Customer))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCustomerListbox(); });
                }
                if (sender.GetType().BaseType == typeof(Worker))
                {
                    this.Invoke((MethodInvoker)delegate { UpdateWorkersListbox(); });
                }
            }
        }

        private void UpdateCustomerListbox()
        {
            _bindingSourceCustomers.ResetBindings(false);
            if (_showQueues)
            {
                QueueForAcceptanceListbox.DataSource = null;
                QueueForPaymentListBox.DataSource = null;
                //QueueForAcceptanceListbox.DataSource = _simulator.CustomerQueueForAcceptance.ToList();
                //QueueForPaymentListBox.DataSource = _simulator.CustomerQueueForPayment.ToList();
            }
        }
        private void UpdateWorkersListbox()
        {
            _bindingSourceWorkers.ResetBindings(false);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!_isSimulationRunning)
            {
                _simulationThread = new Thread(new ThreadStart(this.RunSimulation));
                _simulationThread.IsBackground = true;
                var sleep = RychlostMenic.Maximum - RychlostMenic.Value;
                _simulator.SetSimSpeed(1, sleep/1000.0);

                _simulator.Mode = SimulationMode.SLOW;
                ((MechanicsAgent)_simulator.FindAgent(SimId.MechanicsAgent)).MechanicsNumber = (int)MechanicCounter.Value;
                ((TechniciansAgent)_simulator.FindAgent(SimId.TechniciansAgent)).TechniciansNumber = (int)techniciansCounter.Value;
                _simulationThread.Start();
            }
            else
            {
                if (_simulator.IsPaused())
                {
                    _simulator.ResumeSimulation();
                }
            }
        }
        private void RunSimulation()
        {
            if (_simulator.IsPaused())
            {
                _simulator.ResumeSimulation();
            }
            _isSimulationRunning = true;
            _simulator.Simulate(1,8*3600);
            _isSimulationRunning = false;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void RychlostMenic_Scroll(object sender, EventArgs e)
        {
            var sleep = RychlostMenic.Maximum - RychlostMenic.Value;
            _simulator.SetSimSpeed(1, sleep/1000.0);
        }

        private void Update(STKAgentSimulation simulation)
        {
            SystemTime.Text = simulation.GetCurentTimeInDatFormat().ToString("HH:mm:ss");
            RadaNaPrijatieLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).CustomerQueueForAcceptance.Count.ToString();
            RadaNaPlatenieLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).CustomerQueueForPayment.Count.ToString();
            ZaparkovaneAutaLbl.Text = ((MechanicsAgent)simulation.FindAgent(SimId.MechanicsAgent)).ParkingInGarage.GetCarParked().ToString();
            VolnyParkingLbl.Text = ((MechanicsAgent)simulation.FindAgent(SimId.MechanicsAgent)).ParkingInGarage.GetFreeSpots().ToString();
            VolniTechniciLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).FreeTechnicians.Count.ToString();
            VolniMechanicLbl.Text = ((MechanicsAgent)simulation.FindAgent(SimId.MechanicsAgent)).FreeMechanics.Count.ToString();

            CurrentNUmberOfCstomersLbl.Text = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).CurrentNumberOfCustomersInTheSystem.ToString();
            NUmberAllCustomersLbl.Text = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).NumberOfCustomersInTheSystemAtAll.ToString();
            // v minutach
            AverageTWaitingTimeLbl.Text = (((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).TimeWaitingForAcceptanceStatistics.GetAverage() / 60).ToString();
            AverageTimeInSystemLbl.Text = (((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).TimeInTheSystemStatistics.GetAverage() / 60).ToString();
            AvgFreeMechanicsLbl.Text = ((MechanicsAgent)simulation.FindAgent(SimId.MechanicsAgent)).AvergaeNumberOfFreeMechanics.GetAverage().ToString(); 
            AvgFreeTechniciansLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).AvergaeNumberOfFreeTechnicians.GetAverage().ToString();

        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (_simulator != null && _simulator.IsRunning())
            {
                if (!_simulator.IsPaused())
                {
                    _simulator.PauseSimulation();
                }
            }
        }

        public void StopSimulation()
        {
            _isSimulationRunning = false;
            if (_simulator != null)
            {
                if (_simulator.IsRunning())
                {
                    _simulator.StopSimulation();
                }
                if (_simulator.IsPaused())
                {
                    _simulator.ResumeSimulation();
                }
            }
        }

        private void QueueShowCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (QueueShowCheckbox.Checked)
            {
                _showQueues = true;
                //QueueForAcceptanceListbox.DataSource = _simulator.CustomerQueueForAcceptance.ToList();
                //QueueForPaymentListBox.DataSource = _simulator.CustomerQueueForPayment.ToList();
            }
            else
            {
                _showQueues = false;
                QueueForAcceptanceListbox.DataSource = null;
                QueueForPaymentListBox.DataSource = null;

            }
        }

        public void SimStateChanged(Simulation sim, SimState state)
        {
            //throw new NotImplementedException();
        }

        public void Refresh(Simulation sim)
        {
            if (_isSimulationRunning)
            {
                this.Invoke((MethodInvoker)delegate { Update((STKAgentSimulation)sim); });
            }
        }
    }
}
