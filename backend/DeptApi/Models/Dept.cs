
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeptApi.Models
{
    public class Dept
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string? DeptName { get; set; }

        public int NumOfEmployees { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public virtual Manager? Manager { get; set; }
    }
}
