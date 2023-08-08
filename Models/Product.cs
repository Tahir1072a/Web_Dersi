using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.ModelMetadataTypes;

namespace WebApplication1.Models
{
    public class Product
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
