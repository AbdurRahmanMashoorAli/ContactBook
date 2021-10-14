using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactBook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists($"{Application.StartupPath}/data.dat"))
                database.ReadXml($"{Application.StartupPath}/data.dat");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                contactsBindingSource.Filter = $"Name Like '*{txtSearch.Text}*' or" +
                    $" Email Like '*{txtSearch.Text}*' or Address Like '*{txtSearch.Text}*' or" +
                    $" City Like '*{txtSearch.Text}*' or Country Like '*{txtSearch.Text}*' or " +
                    $"Province Like '*{txtSearch.Text}*'";
            }
        }
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contactsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            contactsBindingSource.EndEdit();
            database.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Contact Added","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
