﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models.Dto
{
    public class UpdateComment
    {
        public int Id { get; set; }
        public string ?newComment { get; set; }
    }
}
