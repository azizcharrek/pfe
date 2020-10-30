using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Domain.Entities;
using Data;
using Service;

namespace Web.Controllers
{
    [RoutePrefix("Api/Formateurs")]
    public class FormateursController : ApiController
    {
        private PfeContext db = new PfeContext();
        IEBuyService service = null;

        public FormateursController()
        {
            service = new EBuyService();
        }
       
     

        // GET: api/Formateurs/5
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult GetFormateur(int id)
        {
            Formateur formateur = service.GetFormateurById(id);
            if (formateur == null)
            {
                return NotFound();
            }

            return Ok(formateur);
        }

        // PUT: api/Formateurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormateur(int id, Formateur formateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formateur.id_formateur)
            {
                return BadRequest();
            }

            db.Entry(formateur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormateurExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Formateurs
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult PostFormateur(Formateur formateur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Formateurs.Add(formateur);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formateur.id_formateur }, formateur);
        }

        // DELETE: api/Formateurs/5
        [ResponseType(typeof(Formateur))]
        public IHttpActionResult DeleteFormateur(int id)
        {
            Formateur formateur = db.Formateurs.Find(id);
            if (formateur == null)
            {
                return NotFound();
            }

            db.Formateurs.Remove(formateur);
            db.SaveChanges();

            return Ok(formateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormateurExists(int id)
        {
            return db.Formateurs.Count(e => e.id_formateur == id) > 0;
        }
    }
}