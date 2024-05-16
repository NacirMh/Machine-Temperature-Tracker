using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDashboarding.Entities
{
    public class Machine
    {
        int id;
        float temperature;
        DateTime time;

        public int Id { get => id; set => id = value; }
        public float Temperature { get => temperature; set => temperature = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
