using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Management_System.Models;

namespace DataLayer.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public int Id { get; set; }
        public bool viewRole { get; set; }
        public bool createRole { get; set; }
        public bool updateRole { get; set; }
        public bool deleteRole { get; set; }
        public bool masterRole { get; set; }       
        public virtual ICollection<Admin> Admins { get; set; }


        public Role()
        {
            viewRole = false;
            createRole = false;
            updateRole = false;
            deleteRole = false;
            masterRole = false;
        }
    }
}
