using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveClassLibrary
{
    [Serializable]
    public class Order
    {
        public Client Client { get; set; }
        public List<Service> Services { get; set; }
        public DateTime OrderDate { get; set; }
        public float Sum { get; set; }

        public Order()
        {

        }

        public Order(Client client, List<Service> services)
        {
            Client = client;
            Services = services;
            if (Services.Count != 0)
                Sum = services.Sum((s) => s.Cost);
        }

    }
}
