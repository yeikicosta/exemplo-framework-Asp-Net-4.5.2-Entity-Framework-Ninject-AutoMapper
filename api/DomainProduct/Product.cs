using DomainProduct.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainProduct
{
    public class Product : IEntity
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public virtual Category Category { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }        public DateTime? RegisterDate { get; set; }
    }
}
