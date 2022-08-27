using DvdLibrary.WebApi.Data.Interfaces;
using DvdLibrary.WebApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.WebApi.Data
{
    public static class DvdRepositoryFactory
    {
        public static IDvdsRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new DvdRepositoryADO();
                case "SampleData":
                    return new DvdRepositoryMock();
                default:
                    throw new Exception("Could not find valid RepositoryType configuration value.");
            }
        }
    }
}