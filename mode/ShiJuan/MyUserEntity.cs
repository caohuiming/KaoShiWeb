﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mode.ShiJuan
{
    public class MyUserEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPhone { get; set; }
        public string userPwd { get; set; }
        public DateTime cT { get; set; }
        public DateTime uT { get; set; }
        public int isDeleted { get; set; }
    }
}
