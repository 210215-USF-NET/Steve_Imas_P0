using System;
using System.Collections.Generic;

#nullable disable

namespace Dozen2DL.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public int? Customer { get; set; }
        public int? Location { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
    }
}
