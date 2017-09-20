using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mode.ShiJuan
{
    public  class ShiJuanEntity
    {
        public int id { get; set; }
        public string shiJuanName { get; set; }
        public DateTime cT { get; set; }
        public DateTime uT { get; set; }
        public int isDeleted { get; set; }
    }
}
