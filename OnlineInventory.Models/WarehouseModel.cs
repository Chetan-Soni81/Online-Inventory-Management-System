﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInventory.Models
{
    [Table("tbl_warehouse")]
    public class WarehouseModel
    {
        [Key]
        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public virtual ICollection<StockModel> Stocks { get; set; } = new List<StockModel>();
    }
}
