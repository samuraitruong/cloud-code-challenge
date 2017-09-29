﻿using System;
using System.Collections.Generic;

namespace Hiring.Cloud.CodeChallenge.Model.Interfaces
{
    public interface IOwner
    {
        string Name { get; set; }
        List<ICar> Cars { get; set; }
    }
}
