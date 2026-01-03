using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phantom.Class;

namespace Phantom
{
    public partial class MainForm : Form
    {

        List<PhantomUnit> phantomUnits = new List<PhantomUnit>();

        public MainForm()
        {
            InitializeComponent();

            LoadPhantomUnitList();
        }

        private void LoadPhantomUnitList()
        {
            phantomUnits = SQLiteDataAccess.LoadUnit();

            WireUpPhantomUnitList();
        }

        private void WireUpPhantomUnitList()
        {
            lB_list.DataSource = null;
            lB_list.DataSource = phantomUnits;
            lB_list.DisplayMember = "PhantomUnitPath";
        }
    }
}
