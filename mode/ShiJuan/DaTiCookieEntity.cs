using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mode.ShiJuan
{
    public class DaTiCookieEntity
    {
        public int shiJuanId { get; set; }
        public int daTiType { get; set; }//1.顺序;2.随机；
        public long shiTiId { get; set; }
        public string daAn { get; set; }//标准答案
        public string myDaAn { get; set; }//我的答案

    }
}
