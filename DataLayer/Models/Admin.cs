using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace University_Management_System.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(100, 999)]
        public int AdminId { get; set; }
        [StringLength(8)]
        public string Pass { get; set; }
        public string Name { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }   
        public virtual ICollection<Role> Roles { get; set; }
    }
}