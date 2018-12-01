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
    public partial class OrdersView : Form
    {
        public OrdersView(ref List<Order> list)
        {
            InitializeComponent();
            foreach (Order order in list)
            {
                listBox1.Items.Add("***************************");
                listBox1.Items.Add("Client: " + order.Client.Name);
                listBox1.Items.Add("Phone number: " + order.Client.PhoneNumber);
                listBox1.Items.Add("   Services: ");
                foreach (Service service in order.Services)
                {
                    listBox1.Items.Add(service.Name + " " + service.Cost + " " + service.Time);
                }
                listBox1.Items.Add("***************************");
            }
        }
    }
}
