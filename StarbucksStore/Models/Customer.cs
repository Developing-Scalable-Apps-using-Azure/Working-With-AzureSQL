using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StarbucksStore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            StarbucksOrders = new HashSet<StarbucksOrder>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string FirstName { get; set; }
        [StringLength(150)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        [InverseProperty(nameof(StarbucksOrder.Customer))]
        public virtual ICollection<StarbucksOrder> StarbucksOrders { get; set; }
    }
}
