using System.Collections.Generic;

namespace WeldingAnalyz.DAL.Models
{
    public class MachineData
    {
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public ICollection<Voltage> Voltages { get; set; }
        public ICollection<Amperage> Amperages { get; set; }

        public MachineData()
        {
            Voltages = new List<Voltage>();
            Amperages = new List<Amperage>();
        }
    }
}
