using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace DAL.Interfaces.DTO
{
    public class DalRole : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<DalUser> Users { get; set; }
    }
}
