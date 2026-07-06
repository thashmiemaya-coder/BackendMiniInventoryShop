using System;
using System.Collections.Generic;

namespace MiniInventory.Domain.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string? Barcode { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<StockIn>? StockIns { get; set; }
        public ICollection<StockOut>? StockOuts { get; set; }
    }
}