using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SaveClassLibrary;

namespace SerializationClientWindowsFormsApplication
{
    public partial class NewClientForm : Form
    {
        private List<Client> list;

        public NewClientForm(ref List<Client> list)
        {
            if (list == null)
                list = new List<Client>();
            InitializeComponent();

            this.list = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Fill all fields");
                return;
            }

            Sex sex;
            if (radioButtonMale.Checked)
                sex = Sex.Male;
            else sex = Sex.Female;

            Client client = new Client(textBox1.Text, textBox2.Text, sex);

            list.Add(client);

            Saver.SaveClientsAsJson(list);

            this.Close();
        }
    }
}
