﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elazone.UI.Areas.Admin.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int AccessDeniedCount { get; set; }
        public bool IsLocked { get; set; }
    }
}
