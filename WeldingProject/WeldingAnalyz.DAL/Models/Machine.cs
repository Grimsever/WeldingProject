namespace WeldingAnalyz.DAL.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string MachineNumber { get; set; }
        public int MachineDataId { get; set; }
        public MachineData MachineData { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public Machine()
        {
            MachineData = new MachineData();
        }
    }
}
