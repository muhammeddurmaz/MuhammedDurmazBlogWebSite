﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UtilService
{
    public interface IMailService
    {
        void SendEmail(string to, string fromName);
    }
}
