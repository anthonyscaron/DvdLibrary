using DvdLibrary.WebApi.Data;
using DvdLibrary.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDvds()
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvds = repo.GetAllDvds();

            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdById(int dvdId)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvd = repo.GetDvdById(dvdId);

            if (dvd != null)
            {
                return Ok(dvd);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByTitle(string title)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvds = repo.GetDvdsByTitle(title);
            
            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvds/year/{releaseYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByReleaseYear(int releaseYear)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvds = repo.GetDvdsByReleaseYear(releaseYear);

            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByDirector(string director)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvds = repo.GetDvdsByDirector(director);

            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsByRating(string rating)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvds = repo.GetDvdsByRating(rating);

            if (dvds != null)
            {
                return Ok(dvds);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult CreateDvd(CreateDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dvd dvd = new Dvd();

            dvd.Title = request.Title;
            dvd.ReleaseYear = request.ReleaseYear;
            dvd.Rating = request.Rating;
            dvd.Director = request.Director;
            dvd.Notes = request.Notes;
            
            var repo = DvdRepositoryFactory.GetRepository();
            repo.Create(dvd);

            return Created($"dvd/{dvd.DvdId}", dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult UpdateDvd(UpdateDvdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repo = DvdRepositoryFactory.GetRepository();
            var dvd = repo.GetDvdById(request.DvdId);

            if (dvd != null)
            {
                dvd.Title = request.Title;
                dvd.ReleaseYear = request.ReleaseYear;
                dvd.Rating = request.Rating;
                dvd.Director = request.Director;
                dvd.Notes = request.Notes;

                repo.Update(dvd);

                return Ok(dvd);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("dvd/{dvdId}")]
        [Route("DELETE")]
        public IHttpActionResult Delete(int dvdId)
        {
            var repo = DvdRepositoryFactory.GetRepository();
            var dvd = repo.GetDvdById(dvdId);

            if (dvd != null)
            {
                repo.Delete(dvd.DvdId);
                return Ok(dvd);
            }
            else
            {
                return NotFound();
            }
        }
    }
}