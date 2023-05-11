using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Column("USR_Name")]
        public string Name { get; set; }

        [Column("USR_Type")]
        public UserType? Type { get; set; }
    }
}