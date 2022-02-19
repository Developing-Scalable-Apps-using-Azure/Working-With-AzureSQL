using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StarbucksStore.Models
{
    public partial class StarbucksOrder
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        public DateTimeOffset? Date { get; set; }
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("StarbucksOrders")]
        public virtual Customer Customer { get; set; }
    }
}
