using System.Collections.Generic;

namespace WeldingAnalyz.DAL.Models
{
    public class Foreman
    {
        public int ForemanId { get; set; }
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }

        public Foreman()
        {
            Workers = new List<Worker>();
        }
    }
}