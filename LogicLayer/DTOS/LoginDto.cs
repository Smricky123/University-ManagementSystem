﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTOS
{
    public class LoginDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}
