using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TV_and_MS
{
    public partial class EditTZ : Form
    {
        public EditTZ()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AddradioButton.Checked==true)
            {
                this.Close();
                AddTZ atz = new AddTZ();
                atz.Show();
            }
            if(ChangeradioButton.Checked==true)
            {
                this.Close();
                ChangeTZ ctz = new ChangeTZ();
                ctz.Show();
            }
            if (DeleteradioButton.Checked == true)
            {
                this.Close();
                DelTZ dtz= new DelTZ();
                dtz.Show();
            }
        }
    }
}
