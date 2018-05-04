using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace video_rental_store.Dtos
{
    public class MemberShipTypeDto
    {
        public byte Id { get; set; }

        public string Name { get; set; }

    }
}