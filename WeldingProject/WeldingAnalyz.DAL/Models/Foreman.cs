using System.Collections.Generic;

namespace WeldingAnalyz.DAL.Models
{
    public class Foreman:BaseEntity
    {
        public ICollection<Worker> Workers { get; set; }

        public Foreman()
        {
            Workers = new List<Worker>();
        }
    }
}