using DvdLibrary.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.WebApi.Data.Interfaces
{
    public interface IDvdsRepository
    {
        List<Dvd> GetAllDvds();
        Dvd GetDvdById(int dvdId);
        List<Dvd> GetDvdsByTitle(string title);
        List<Dvd> GetDvdsByReleaseYear(int releaseYear);
        List<Dvd> GetDvdsByDirector(string director);
        List<Dvd> GetDvdsByRating(string rating);
        void Create(Dvd dvd);
        void Update(Dvd dvd);
        void Delete(int dvdId);
    }
}
