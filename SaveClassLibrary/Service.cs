using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveClassLibrary
{
    [Serializable]
    public class Service
    {
        public string Name { get; set; }
        public float Cost { get; set; }
        public float Time { get; set; }

        public Service()
        {

        }

        public Service(string name, float cost, float time)
        {
            Name = name;
            Cost = cost;
            Time = time;
        }
    }
}
