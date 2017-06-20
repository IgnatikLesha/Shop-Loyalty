using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class User
    {
        public User()
        {
            Sales = new HashSet<Sale>();
            Roles = new HashSet<Role>();
            Bonus = new Bonus();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string Email { get; set; }

        [Required]
        [StringLength(60)]
        public string Password { get; set; }
        
        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual Bonus Bonus {get; set; }
    }
}
