﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.DTO
{
    public class ProfileDto
    {
        public string UserName { get; set; }
        public PermissionDto[] Permissions { get; set; }        
    }
}