using DomainProduct.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainProduct
{
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdParent { get; set; }
    } 
}
