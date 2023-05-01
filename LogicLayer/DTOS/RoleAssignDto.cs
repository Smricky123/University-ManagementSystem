using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DTOS
{
    public class RoleAssignDto
    {
        public int Id { get; set; }
        public bool viewRole { get; set; }
        public bool createRole { get; set; }
        public bool updateRole { get; set; }
        public bool deleteRole { get; set; }
        public bool masterRole { get; set; }
        public ICollection<AdminDto> Admins { get; set; }

        public RoleAssignDto()
        {
            viewRole = false;
            createRole = false;
            updateRole = false;
            deleteRole = false;
            masterRole = false;
        }
    }
}
