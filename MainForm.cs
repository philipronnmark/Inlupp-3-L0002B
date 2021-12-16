/** 
 * Author1:  Philip Rönnmark 990513-4392 (phrinn-1@student.ltu.se) 
 * Course:   L0002B
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inlupp_3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates person, and calls method for checking valid id number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKontrollera_Click(object sender, EventArgs e)
        {
            Person p = new Person(txtFirstName.Text, txtLastName.Text, txtIdNumer.Text);
            txtResult.Text = p.checkPerson();
        }
    }
}
