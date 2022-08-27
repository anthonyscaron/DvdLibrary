using DvdLibrary.WebApi.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.WebApi.Data.Repositories
{
    public class RatingRepositorySupport : IRatingRepository
    {
        private string[] _ratings = { "G", "PG", "PG-13", "R" };

        public string[] GetAllRatings()
        {
            return _ratings;
        }
    }
}