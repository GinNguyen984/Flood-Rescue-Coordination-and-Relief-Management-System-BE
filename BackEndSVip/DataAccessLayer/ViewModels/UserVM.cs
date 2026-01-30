using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public int? RoleId { get; set; }
        public int? AreaId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
