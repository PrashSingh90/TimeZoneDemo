﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_BO.DataModel
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumberValue { get; set; }
    }
}
