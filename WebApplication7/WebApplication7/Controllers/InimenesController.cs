using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using WebApplication7.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Inimene>("Inimenes");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class InimenesController : ODataController
    {
        private northwindEntities db = new northwindEntities();

        // GET: odata/Inimenes
        [EnableQuery]
        public IQueryable<Inimene> GetInimenes()
        {
            return db.Inimenes;
        }

        // GET: odata/Inimenes(5)
        [EnableQuery]
        public SingleResult<Inimene> GetInimene([FromODataUri] int key)
        {
            return SingleResult.Create(db.Inimenes.Where(inimene => inimene.Id == key));
        }

        // PUT: odata/Inimenes(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Inimene> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inimene inimene = db.Inimenes.Find(key);
            if (inimene == null)
            {
                return NotFound();
            }

            patch.Put(inimene);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InimeneExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inimene);
        }

        // POST: odata/Inimenes
        public IHttpActionResult Post(Inimene inimene)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inimenes.Add(inimene);
            db.SaveChanges();

            return Created(inimene);
        }

        // PATCH: odata/Inimenes(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Inimene> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Inimene inimene = db.Inimenes.Find(key);
            if (inimene == null)
            {
                return NotFound();
            }

            patch.Patch(inimene);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InimeneExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(inimene);
        }

        // DELETE: odata/Inimenes(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Inimene inimene = db.Inimenes.Find(key);
            if (inimene == null)
            {
                return NotFound();
            }

            db.Inimenes.Remove(inimene);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InimeneExists(int key)
        {
            return db.Inimenes.Count(e => e.Id == key) > 0;
        }
    }
}
