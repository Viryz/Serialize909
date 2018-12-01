using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace SaveClassLibrary
{
    public static class Saver
    {
        static BinaryFormatter bf = new BinaryFormatter();
        static DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Client>));
        static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

        // Services.
        public static void LoadServicesAsBinary(ref List<Service> list)
        {
            using (FileStream fs = new FileStream("services.dat", FileMode.Open))
            {
                list = (List<Service>)bf.Deserialize(fs);
            }
        }
        public static void SaveServicesAsBinary(List<Service> list)
        {
            try
            {
                using (FileStream fs = new FileStream("services.dat", FileMode.OpenOrCreate))
                {
                    bf.Serialize(fs, list);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
        }

        // Clients.
        public static void LoadClientsAsJson(ref List<Client> list)
        {
            using (FileStream fs = new FileStream("clients.json", FileMode.Open))
            {
                list = (List<Client>)jsonFormatter.ReadObject(fs);
            }
        }
        public static void SaveClientsAsJson(List<Client> list)
        {
            using (FileStream fs = new FileStream("clients.json", FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, list);
            }
        }

        // Orders.
        public static void LoadOrdersAsXML(ref List<Order> list)
        {
            list = new List<Order>();

            using (FileStream fs = new FileStream("orders.xml", FileMode.OpenOrCreate))
            {
                list = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }
        public static void SaveOrdersAsXML(List<Order> list)
        {
            File.Delete("orders.xml");
            using (FileStream fs = new FileStream("orders.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, list);
            }
        }

    }
}
