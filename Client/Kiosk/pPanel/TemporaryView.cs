using Kiosk.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class TemporaryView : Form
    {

        private static TemporaryTable TemporaryTable = new TemporaryTable();
        public TemporaryView()
        {
            InitializeComponent();
        }

        private void TemporaryViewcs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TemporaryTable.GetTemporaryDataTable();
        }
    }
}
