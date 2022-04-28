using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Customers.Data.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        public string LastName { get; set; }

        [MinLength(1)]
        public string? Address { get; set; }
 
        [Phone]
        public string? Phone { get; set; }
    }
}