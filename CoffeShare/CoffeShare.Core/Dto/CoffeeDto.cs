using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShare.Core.Models;

namespace CoffeeShare.Core.Dto
{
    public class CoffeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ManufacturerDto Manufacturer { get; set; }
        public int ManufacturerId { get; set; }
        public CountryDto Country { get; set; }
        public int CountryId { get; set; }
        public BeansProcessing BeansProcessing { get; set; }
        public DegreeOfRoasting DegreeOfRoasting { get; set; }
        public BeanType BeanType { get; set; }
        public string ImgUrl { get; set; }
    }
}
