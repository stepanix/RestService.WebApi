using System;
namespace RestService.Domain.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
