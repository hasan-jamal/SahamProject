﻿using System;
using System.Collections.Generic;

namespace SahamProject.Web.Model
{
    public partial class Status
    {
        public Status()
        {
            Shipments = new HashSet<Shipment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
