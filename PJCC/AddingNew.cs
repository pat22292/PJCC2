using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Properties;
using MetroFramework;
using System.Data.SqlClient;
using System.IO;


namespace PJCC
{
    public partial class AddingNew : MetroForm
    {
        public AddingNew()
        {
            InitializeComponent();
            metroComboBox1.SelectedIndex = 0;
            metroComboBox2.SelectedIndex = 0;
            metroComboBox3.SelectedIndex = 0;
            CRUD autoSugg = new CRUD();
            autoSugg.autoSuggest(textBoxX1);
           
        }

        private void done_Click(object sender, EventArgs e)
        {
            //CRUD newService = new CRUD();
            //newService.insertService(metroDateTime1.Value.ToString(), textBoxX1.Text, metroComboBox2.Text, metroComboBox3.Text, metroComboBox1.Text, metroTextBox2.Text,);
        }

        private void metroComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {

            //metroLabel5.Text 
        }
    }
}
