﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.WebApi.Data.Interfaces
{
    public interface IRatingRepository
    {
        string[] GetAllRatings();
    }
}
