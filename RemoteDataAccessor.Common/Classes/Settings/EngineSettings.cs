﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Settings;

namespace RemoteDataAccessor.Common.Classes.Settings
{
    public class EngineSettings : IEngineSettings
    {
        public int Set { get; set; }
    }
}