﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkClient.Models
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserDTO Manager { get; set; }
    }
}
