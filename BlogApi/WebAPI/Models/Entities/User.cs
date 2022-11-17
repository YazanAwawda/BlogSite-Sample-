using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? userName { get; set; }
        public string? email { get; set; }
        public string ?password { get; set; }
        public bool admin { get; set; }
        public bool ban { get; set; }
    }
}
