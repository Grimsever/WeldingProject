namespace WeldingAnalyz.DAL.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string Name { get; set; }
        public int? TaskId { get; set; }
        public Task Task { get; set; }
        public int? ForemanId { get; set; }
        public Foreman Foreman { get; set; }
    }
}
