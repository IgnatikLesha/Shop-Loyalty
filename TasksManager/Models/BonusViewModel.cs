using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repository;

namespace TasksManager.Models
{
    public class BonusViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int Points { get; set; }

        public bool IsActive { get; set; }
    }
}
