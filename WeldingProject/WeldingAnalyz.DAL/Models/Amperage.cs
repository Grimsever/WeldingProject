namespace WeldingAnalyz.DAL.Models
{
    public class Amperage
    {
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }
        public double Value { get; set; }
    }
}