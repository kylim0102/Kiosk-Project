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
    public partial class KioskPanel : UserControl
    {
         pPanel.CartPanel cartPanel = new pPanel.CartPanel();
        public event EventHandler ButtonClicked;

        public KioskPanel()
        {
            InitializeComponent();
            
        }

        public void button4_Click(object sender, EventArgs e)
        {

            ButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
