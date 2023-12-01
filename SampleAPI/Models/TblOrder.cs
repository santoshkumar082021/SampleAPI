using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SampleAPI.Models
{
    /// <summary>
    /// TblOrder 
    /// </summary>
    public partial class TblOrder
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string? ProductName { get; set; }
        
        [Required]
        public int? OrderQty { get; set; }
        
        [Required]
        public decimal? TotalPrice { get; set; }
        
        [Required]
        [DefaultValue(true)]
        public bool? IsInvoiced { get; set; }
        
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        [MaxLength(100)]
        public string? Description { get; set; }

        public DateTime? UpdatedDate { get; set; }
        
        [Required]
        [DefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
