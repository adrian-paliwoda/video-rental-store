using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using video_rental_store.Models;

namespace video_rental_store.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

//        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MemberShipTypeId { get; set; }

        public MemberShipTypeDto MemberShipType { get; set; } 
    }
}