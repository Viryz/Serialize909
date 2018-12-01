using SaveClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerializationClientWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private List<Service> listServices;
        private List<Client> listClients;
        private List<Order> listOrders;

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshClients()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(listClients.ToArray());
            comboBox1.SelectedItem = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "Name";
            try
            {
                Saver.LoadClientsAsJson(ref listClients);
                RefreshClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                Saver.LoadServicesAsBinary(ref listServices);
                FillGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {
                Saver.LoadOrdersAsXML(ref listOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Service item in listServices)
            {
                dataGridView1.Rows.Add(item.Name, item.Cost, item.Time, false);
            }
        }

        private void buttonNewService_Click(object sender, EventArgs e)
        {
            NewServiceForm nsf = new NewServiceForm(ref listServices);
            nsf.ShowDialog();
            FillGrid();
        }

        private void buttonNewClient_Click(object sender, EventArgs e)
        {
            NewClientForm ncf = new NewClientForm(ref listClients);
            ncf.ShowDialog();
            RefreshClients();
        }

        private void buttonVheckout_Click(object sender, EventArgs e)
        {
            Client client = (Client)comboBox1.SelectedItem;
            List<Service> list = new List<Service>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewCheckBoxCell box = dataGridView1.Rows[i].Cells[3] as DataGridViewCheckBoxCell;
                if ((bool)box.Value)
                    list.Add(listServices[i]);
            }

            Order order = new Order(client, list);

            if (listOrders == null)
                listOrders = new List<Order>();
            listOrders.Add(order);

            Saver.SaveOrdersAsXML(listOrders);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdersView ov = new OrdersView(ref listOrders);
            ov.ShowDialog();
        }
    }
}
