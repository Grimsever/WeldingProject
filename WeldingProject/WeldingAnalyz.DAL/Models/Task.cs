
namespace WeldingAnalyz.DAL.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int TechnologicalMapId { get; set; }
        public TechnologicalMap TechnologicalMap { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
