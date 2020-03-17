namespace WeldingAnalyz.DAL.Models
{
    public class Worker : BaseEntity
    {
        public int? TaskId { get; set; }
        public Task Task { get; set; }
        public int? ForemanId { get; set; }
        public Foreman Foreman { get; set; }
    }
}
