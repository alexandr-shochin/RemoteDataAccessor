﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteDataAccessor.Common.Interfaces.Component;

namespace RemoteDataAccessor.Common.Interfaces.Settings
{
    public interface IAPIProviderSettings : ISettings
    {
        int Set { get; set; }
    }
}
