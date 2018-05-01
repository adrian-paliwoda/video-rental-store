using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace video_rental_store.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        public short SignTypeFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

    }
}