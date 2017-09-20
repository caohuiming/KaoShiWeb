using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mode.ShiJuan
{
    public class UserDaAnEntity
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int shiJuanId { get; set; }
        public int shiTiId { get; set; }
        public string daAn { get; set; }

        public DateTime cT { get; set; }
        public DateTime uT { get; set; }
        public int isDeleted { get; set; }
    }
}
