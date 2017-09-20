using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mode.ShiJuan
{
    public class ResultEntity
    {
        public int shiJuanId { get; set; }//试卷编号
        public string shiJuanName { get; set; }//试卷名称
        public string daTiType { get; set; }//答题类型1：顺序，2：
        public int allNum { get; set; }//昨天总数
        public int rightNum { get; set; }//作对总数
        public List<long> wrongShiTiIds { get; set; }//错误试题编号列表
    }
}
