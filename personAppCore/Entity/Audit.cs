using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personAppCore.Entity
{
    public abstract class Audit
    {
        public Audit()
        {
            CDate = DateTime.Now;
        }
        public int CUserId { get; set; }
        public DateTime CDate { get; set; }
        public int? MUserId { get; set; }
        public DateTime? MDate { get; set; }
    }
}
