using AgentSTKSimulation;
using DISS_S2.SimulationCore;
using DISS_S2.StkStation;
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
using agents;
using managers;

namespace SemestralnaPraca3_MichalMurin.UserControls
{
    public partial class FastModeUC : UserControl, OSPABA.ISimDelegate, ISimulationStoppable
    {
        private STKAgentSimulation _simulator;
        private bool _isSimulationRunning = false;
        private Thread _simulationThread;
        public FastModeUC(STKAgentSimulation core)
        {
            InitializeComponent();
            _simulator = core;
        }


        private void Update(STKAgentSimulation simulation)
        {
            CurrentReplicationLbl.Text = simulation.ReplicationCount.ToString();
            AverageWaitingTimeLbl.Text = (((TechniciansManager)simulation.FindAgent(SimId.TechniciansAgent).MyManager).SIMULATIONTimeWaitingForAcceptanceStatistics.GetAverage() / 60).ToString();
            AverageTimeInSystemLbl.Text = (((SurroundingManager)simulation.FindAgent(SimId.SurroundingAgent).MyManager).SIMULATIONTimeInTheSystemStatistics.GetAverage() / 60).ToString();
            AverageCustomersNumAtEndDayLbl.Text = simulation.SIMULATIONNumberOfCustomersAtTHeEndOfDay.GetAverage().ToString();
            FreeTechniciansLbl.Text = ((TechniciansManager)simulation.FindAgent(SimId.TechniciansAgent).MyManager).SIMULATIONAvergaeNumberOfFreeTechnicians.GetAverage().ToString();
            FreeMechanicsLbl.Text = ((MechanicsManager)simulation.FindAgent(SimId.MechanicsAgent).MyManager).SIMULATIONAvergaeNumberOfFreeMechanics.GetAverage().ToString();
            AverageNumberOfCustomersInFirstQueueLbl.Text = ((TechniciansManager)simulation.FindAgent(SimId.TechniciansAgent).MyManager).SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.GetAverage().ToString();
            AvgNumberOfCustomersInSystem.Text = ((SurroundingManager)simulation.FindAgent(SimId.SurroundingAgent).MyManager).SIMULATIONAverageNumberOfCustomersInSystem.GetAverage().ToString();
            //interval spolahlivosti
           (double min, double max) interval = ((SurroundingManager)simulation.FindAgent(SimId.SurroundingAgent).MyManager).SIMULATIONTimeInTheSystemStatistics.GetConfidenceInterval(0.9);
            ConfidenceIntervalTimeInSystemLbl.Text = $"<{interval.min / 60} ; {interval.max / 60}>";
            interval = ((SurroundingManager)simulation.FindAgent(SimId.SurroundingAgent).MyManager).SIMULATIONAverageNumberOfCustomersInSystem.GetConfidenceInterval(0.95);
            ConfidenceIntervalNumberOfCustomersInSystemLbl.Text = $"<{interval.min} ; {interval.max}>";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!_isSimulationRunning)
            {
                _simulationThread = new Thread(new ThreadStart(this.RunSimulation));
                _simulationThread.IsBackground = true;
                _simulationThread.Start();
            }
        }
        private void RunSimulation()
        {
            _simulator.Mode = AgentSim.StkStation.Models.SimulationMode.FAST;
            if (_simulator.IsPaused())
            {
                _simulator.ResumeSimulation();
            }
            ((MechanicsAgent)_simulator.FindAgent(SimId.MechanicsAgent)).MechanicsNumber = (int)MechanicsNumPad.Value;
            ((TechniciansAgent)_simulator.FindAgent(SimId.TechniciansAgent)).TechniciansNumber = (int)TechnicianNumPad.Value;
            int replications = (int)replicationsNumpad.Value;
            _isSimulationRunning = true;
            _simulator.Simulate(replications);
            _isSimulationRunning = false;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        public void StopSimulation()
        {
            if (_isSimulationRunning && _simulationThread.IsAlive)
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
