using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTOS
{
    public class AdminDto
    {
        public int AdminId { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string ImagePath { get; set; }
        public ICollection<RoleAssignDto> Roles { get; set; }
        public RoleAssignDto Role { get; set; }
    }
}

