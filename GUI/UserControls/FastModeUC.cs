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
        private bool _isVisible = false;
        public FastModeUC(STKAgentSimulation core)
        {
            InitializeComponent();
            _simulator = core;
        }


        private void Update(STKAgentSimulation simulation)
        {
            CurrentReplicationLbl.Text = (simulation.CurrentReplication+1).ToString();
            AverageWaitingTimeLbl.Text = (((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).SIMULATIONTimeWaitingForAcceptanceStatistics.GetAverage() / 60).ToString();
            AverageTimeInSystemLbl.Text = (((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).SIMULATIONTimeInTheSystemStatistics.GetAverage() / 60).ToString();
            AverageCustomersNumAtEndDayLbl.Text = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).SIMULATIONNumberOfCustomersAtTHeEndOfDay.GetAverage().ToString();
            FreeTechniciansLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).TechniciansService.AvergaeFreeWorkersGlobal().ToString();
            FreeMechanicsLbl.Text = ((MechanicsAgent)simulation.FindAgent(SimId.MechanicsAgent)).MechanicsService.AvergaeFreeWorkersGlobal().ToString();
            AverageNumberOfCustomersInFirstQueueLbl.Text = ((TechniciansAgent)simulation.FindAgent(SimId.TechniciansAgent)).SIMULATIONAverageNumberOfCustomersInQueueForAcceptance.GetAverage().ToString();
            AvgNumberOfCustomersInSystem.Text = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).SIMULATIONAverageNumberOfCustomersInSystem.GetAverage().ToString();
            //interval spolahlivosti
           (double min, double max) interval = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).SIMULATIONTimeInTheSystemStatistics.GetConfidenceInterval(0.9);
            ConfidenceIntervalTimeInSystemLbl.Text = $"<{interval.min / 60} ; {interval.max / 60}>";
            interval = ((SurroundingAgent)simulation.FindAgent(SimId.SurroundingAgent)).SIMULATIONAverageNumberOfCustomersInSystem.GetConfidenceInterval(0.95);
            ConfidenceIntervalNumberOfCustomersInSystemLbl.Text = $"<{interval.min} ; {interval.max}>";
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            if (!_isSimulationRunning)
            {
                _simulator.SetMaxSimSpeed();
                _simulationThread = new Thread(new ThreadStart(this.RunSimulation));
                _simulationThread.IsBackground = true;
                CalculateSalary();
                _simulationThread.Start();
            }
        }

        private void CalculateSalary()
        {
            int salary = (int)CertificatedMechanicsNumPad.Value * 2000;
            salary += (int)NonCertificatedMechanicsNumPad.Value * 1500;
            salary += (int)TechnicianNumPad.Value * 1100;
            MzdoveNakladyLbl.Text = $"{salary}€";
        }
        private void RunSimulation()
        {
            _simulator.Mode = AgentSim.StkStation.Models.SimulationMode.FAST;
            if (_simulator.IsPaused())
            {
                _simulator.ResumeSimulation();
            }
            ((MechanicsAgent)_simulator.FindAgent(SimId.MechanicsAgent)).MechanicsService.WorkersNumber = (int)CertificatedMechanicsNumPad.Value;
            ((MechanicsAgent)_simulator.FindAgent(SimId.MechanicsAgent)).MechanicsService.NonCertificatedNumber = (int)NonCertificatedMechanicsNumPad.Value;
            ((TechniciansAgent)_simulator.FindAgent(SimId.TechniciansAgent)).TechniciansService.WorkersNumber = (int)TechnicianNumPad.Value;
            int replications = (int)replicationsNumpad.Value;
            _isSimulationRunning = true;
            _simulator.Simulate(replications, STKAgentSimulation.MAX_TIME);
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
                    _simulator.CorrectReplicationRun = false;
                }
            }
        }

        public void SimStateChanged(Simulation sim, SimState state)
        {
            //
        }

        public void Refresh(Simulation sim)
        {
            if (_isVisible)
            {
                this.Invoke((MethodInvoker)delegate { Update((STKAgentSimulation)sim); });
            }
        }

        public void SetControlVisible(bool visible)
        {
            _isVisible = visible;
        }

        private void saveCsvBtn_Click(object sender, EventArgs e)
        {
            if (!_isSimulationRunning)
            {
                var dialog = new FolderBrowserDialog();
                dialog.ShowDialog();
                var path = dialog.SelectedPath;
                _simulator.SaveCsvResults(path);
            }
            else
            {
                MessageBox.Show("Simulacia este bezi", "CHYBA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
