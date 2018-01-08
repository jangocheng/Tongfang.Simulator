using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tongfang.Simulator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnClearReceive_Click(object sender, EventArgs e)
        {
            richTextBoxReceive.Clear();
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            richTextBoxError.Clear();
        }
    }
}
