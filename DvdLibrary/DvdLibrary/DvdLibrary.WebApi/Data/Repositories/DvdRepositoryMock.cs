using DvdLibrary.WebApi.Data.Interfaces;
using DvdLibrary.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.WebApi.Data.Repositories
{
    public class DvdRepositoryMock : IDvdsRepository
    {
        private static List<Dvd> _dvds = new List<Dvd>
        {
            new Dvd {DvdId=1, Title="The Land Before Time", ReleaseYear=1988, Director="Don Bluth", Rating="G",
                Notes="During the age of the dinosaurs, a massive famine forces several herds of dinosaurs to seek an oasis known as the Great Valley."},
            new Dvd {DvdId=2, Title="Hook", ReleaseYear=1991, Director="Steven Spielberg", Rating="PG",
                Notes="When Captain James Hook kidnaps his children, an adult Peter Pan must return to Neverland and reclaim his youthful spirit in order to challenge his old enemy."},
            new Dvd {DvdId=3, Title="Happy Gilmore", ReleaseYear=1996, Director="Dennis Dugan", Rating="PG-13",
                Notes="A rejected hockey player puts his skills to the golf course to save his grandmothers house."},
            new Dvd {DvdId=4, Title="Donnie Darko", ReleaseYear=2001, Director="Richard Kelly", Rating="R",
                Notes="After narrowly escaping a bizarre accident, a troubled teenager is plagued by visions of a man in a large rabbit suit who manipulates him to commit a series of crimes."}
        };
        
        public void Create(Dvd dvd)
        {
            dvd.DvdId = _dvds.Max(m=>m.DvdId) + 1;
            _dvds.Add(dvd);
        }

        public void Delete(int dvdId)
        {
            _dvds.RemoveAll(m => m.DvdId == dvdId);
        }

        public List<Dvd> GetAllDvds()
        {
            return _dvds;
        }

        public Dvd GetDvdById(int dvdId)
        {
            return _dvds.FirstOrDefault(m=>m.DvdId==dvdId);
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            var dvds = _dvds.Where(m => m.Director.StartsWith(director)).ToList();
            return dvds;
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            var dvds = _dvds.Where(m => m.Rating.StartsWith(rating)).ToList();
            return dvds; ;
        }

        public List<Dvd> GetDvdsByReleaseYear(int releaseYear)
        {
            List<Dvd> dvds = new List<Dvd>();

            foreach (var d in _dvds)
            {
                var inputString = releaseYear.ToString();
                var currentString = d.ReleaseYear.ToString();

                if (currentString.StartsWith(inputString))
                {
                    dvds.Add(d);
                }

            }

            return dvds;
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            var dvds = _dvds.Where(m => m.Title.StartsWith(title)).ToList();
            return dvds;
        }

        public void Update(Dvd dvd)
        {
            var found = _dvds.FirstOrDefault(m => m.DvdId == dvd.DvdId);

            if (found != null)
            {
                found = dvd;
            }
        }
    }
}