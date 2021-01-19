using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDONovohaisk
{
    public partial class UnitForm : Form
    {
        public UnitForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
           // EventForm ef = new EventForm();
           // ef.ShowDialog();
        }
    }
}
