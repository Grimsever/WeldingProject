using System.ComponentModel.DataAnnotations;

namespace WeldingAnalyz.DAL.Models
{
    public class BaseEntity : ITEntity
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}
