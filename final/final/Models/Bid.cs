namespace final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidID { get; set; }

        public int BuyerID { get; set; }

        public int ItemID { get; set; }

        public int Price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Item Item { get; set; }
    }
}
