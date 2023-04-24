using AgentSTKSimulation;
using OSPABA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using simulation;

namespace SemestralnaPraca3_MichalMurin.UserControls
{
    public partial class MechanicsToTimeInSystem : UserControl, OSPABA.ISimDelegate, ISimulationStoppable
    {
        private STKAgentSimulation _simulator;
        private bool _isSimulationRunning = false;
        private Thread _simulationThread;
        private const string SERIES_NAME = "Priemerny cas v systeme";
        public MechanicsToTimeInSystem(STKAgentSimulation core)
        {
            InitializeComponent();
            _simulator = core;
        }


        private void Update(Simulation simulation)
        {
            var mechanics = simulation.MechanicsNumber;
            var average = simulation.SIMULATIONTimeInTheSystemStatistics.GetAverage()/60;
            chart1.Series[SERIES_NAME].Points.AddXY(mechanics, average);
            resultsListBox.Items.Add($"{mechanics}      :{average}");
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

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!_isSimulationRunning)
            {
                resultsListBox.Items.Clear();
                resultsListBox.Items.Add($"Mech.:avg.");
                chart1.Series[SERIES_NAME].Points.Clear();
                chart1.ChartAreas[0].AxisY.IsStartedFromZero = false;
                _simulationThread = new Thread(new ThreadStart(this.RunSimulation));
                _simulationThread.IsBackground = true;
                _simulationThread.Start();
            }
        }

        private void RunSimulation()
        {
            int numberOfTechnicscs = (int)technicsCounter.Value;
            int replications = (int)replicationCounterForOneRun.Value;
            int startNumberMechs = (int)MechanicsCounterStart.Value;
            int endNumberMechs = (int)MechanicsCounterEnd.Value;
            int numberOfRuns = endNumberMechs - startNumberMechs + 1;

            _simulator.Mode = AgentSim.StkStation.Models.SimulationMode.UPDATE_AFTER_SIMULATION;
            if (_simulator.IsPaused())
            {
                _simulator.ResumeSimulation();
            }
            _simulator.MechanicsNumber = startNumberMechs;
            _simulator.TechniciansNumber = numberOfTechnicscs;
            _isSimulationRunning = true;
            for (int i = 0; i < numberOfRuns; i++)
            {
                _simulator.Simulate(replications);
                _simulator.MechanicsNumber++;
                if (!_isSimulationRunning)
                {
                    break;
                }
            }
            _isSimulationRunning = false;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        public void SimStateChanged(Simulation sim, SimState state)
        {
            throw new NotImplementedException();
        }

        public void Refresh(Simulation sim)
        {
            if (_isSimulationRunning)
            {
                this.Invoke((MethodInvoker)delegate { Update(((STKAgentSimulation)simulation)); });
            }
        }
    }
}
