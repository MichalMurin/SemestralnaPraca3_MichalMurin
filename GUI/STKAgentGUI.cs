
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SemestralnaPraca3_MichalMurin.UserControls;
using System.Web.UI;
using AgentSTKSimulation;
using simulation;
using UserControl = System.Windows.Forms.UserControl;

namespace SemestralnaPraca3_MichalMurin
{
    public partial class STKAgentGUI : Form
    {
        private STKAgentSimulation _simulator;
        private Dictionary<GuiTab, UserControl> _userControlers;
        private GuiTab _currentTab;
        public STKAgentGUI()
        {
            InitializeComponent();
            _simulator = new STKAgentSimulation();
            _userControlers = new Dictionary<GuiTab, UserControl>();
            CreateUserControlelrs();
            AddUserControlToPanel(_userControlers[GuiTab.SLOW_MODE], GuiTab.SLOW_MODE);
        }

        private void CreateUserControlelrs()
        {
            // slowMode UC
            SlowModeUC uc = new SlowModeUC(_simulator);
            _simulator.RegisterDelegate(uc);
            uc.Dock = DockStyle.Fill;
            _userControlers.Add(GuiTab.SLOW_MODE, uc);

            // FAST ...
            FastModeUC fastUC = new FastModeUC(_simulator);
            _simulator.RegisterDelegate(fastUC);
            fastUC.Dock = DockStyle.Fill;
            _userControlers.Add(GuiTab.FAST_MODE, fastUC);

            // Chart mechanics
            TechNumberToQueueLength chart1UC = new TechNumberToQueueLength(_simulator);
            _simulator.RegisterDelegate(chart1UC);
            chart1UC.Dock = DockStyle.Fill;
            _userControlers.Add(GuiTab.CHART_MECHANICS, chart1UC);

            // Chart technicianc
            MechanicsToTimeInSystem chart2UC = new MechanicsToTimeInSystem(_simulator);
            _simulator.RegisterDelegate(chart2UC);
            chart1UC.Dock = DockStyle.Fill;
            _userControlers.Add(GuiTab.CHART_TECHNICIANS, chart2UC);
        }

        private void StoppCurrentSimulation()
        {
            ((ISimulationStoppable)_userControlers[_currentTab]).StopSimulation();
        }

        public void AddUserControlToPanel(UserControl userControl, GuiTab tabName)
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
            _currentTab = tabName;
        }

        private void SlowModeBtn_clicked(object sender, EventArgs e)
        {
            StoppCurrentSimulation();
            var uc = _userControlers[GuiTab.SLOW_MODE];
            AddUserControlToPanel(uc, GuiTab.SLOW_MODE);
        }

        private void FixedSeedCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (FixedSeedCheckbox.Checked)
            {
                _simulator.Seed = 123456;
            }
            else
            {
                _simulator.Seed = -1;
            }
        }

        private void FasModeBtn_click(object sender, EventArgs e)
        {
            StoppCurrentSimulation();

            var uc = _userControlers[GuiTab.FAST_MODE];
            AddUserControlToPanel(uc, GuiTab.FAST_MODE);
        }

        private void MechanicsChartTabBtn_Click(object sender, EventArgs e)
        {
            StoppCurrentSimulation();

            var uc = _userControlers[GuiTab.CHART_MECHANICS];
            AddUserControlToPanel(uc, GuiTab.CHART_MECHANICS);
        }

        private void TechniciansChartTabBtn_Click(object sender, EventArgs e)
        {
            StoppCurrentSimulation();

            var uc = _userControlers[GuiTab.CHART_TECHNICIANS];
            AddUserControlToPanel(uc, GuiTab.CHART_TECHNICIANS);
        }
    }
}
