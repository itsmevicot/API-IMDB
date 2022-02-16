﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Entity<T>
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
    }
}
