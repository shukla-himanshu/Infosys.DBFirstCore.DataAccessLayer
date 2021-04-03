﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infosys.DBFirstCore.DataAccessLayer.Models
{
    public partial class PurchaseDetail
    {
        public long PurchaseId { get; set; }
        public string EmailId { get; set; }
        public string ProductId { get; set; }
        public short QuantityPurchased { get; set; }
        public DateTime DateOfPurchase { get; set; }

        public virtual User Email { get; set; }
        public virtual Product Product { get; set; }
    }
}
