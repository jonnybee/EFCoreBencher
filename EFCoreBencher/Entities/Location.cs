﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EFCoreBenchmark.Entities
{
    /// <summary>
    /// Product inventory and manufacturing locations.
    /// </summary>
    public partial class Location
    {
        public Location()
        {
            ProductInventories = new HashSet<ProductInventory>();
            WorkOrderRoutings = new HashSet<WorkOrderRouting>();
        }

        /// <summary>
        /// Primary key for Location records.
        /// </summary>
        public short LocationId { get; set; }
        /// <summary>
        /// Location description.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Standard hourly cost of the manufacturing location.
        /// </summary>
        public decimal CostRate { get; set; }
        /// <summary>
        /// Work capacity (in hours) of the manufacturing location.
        /// </summary>
        public decimal Availability { get; set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<WorkOrderRouting> WorkOrderRoutings { get; set; }
    }
}