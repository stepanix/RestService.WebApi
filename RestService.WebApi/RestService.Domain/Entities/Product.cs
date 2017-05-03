using RestService.Domain.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestService.Domain.Entities
{
    public class Product:BaseEntity
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
