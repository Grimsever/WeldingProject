namespace WeldingAnalyz.DAL.Models
{
    public class Voltage
    {
        public int VoltageId { get; set; }
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }
        public double Value { get; set; }
    }
}