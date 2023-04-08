using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(8)]
        public string Pass { get; set; }
        public string Name { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public bool viewRole { get; set; }
        public bool createRole { get; set; }
        public bool updateRole { get; set; }
        public bool deleteRole { get; set; }
        public bool masterRole { get; set; }

        public Admin()
        {
        viewRole = false;
        createRole = false;
        updateRole = false;
        deleteRole = false;
    }
    }
}