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
using System.Web;

namespace Web.Controllers
{
   // [Authorize]
   // [RoutePrefix("Api/Employee")]
    public class FormationsController : ApiController
    {
        private PfeContext db = new PfeContext();
        IEBuyService service = null;

        public FormationsController()
        {
            service = new EBuyService();
        }
        // GET: api/Formations

        [HttpGet]
        [Route("AllFormationDetails")]
        public IHttpActionResult GetFormations()
        {
            List<Formation> form = service.GetAllFormations();
            return Ok(form);
        }
        /* public IHttpActionResult GetEmployeByFormation(Employe e)
         {
             List<Employe> emp = service.GetFirst20EmployeeByFormation(e);
             return Ok(emp);
         }
         */
        [HttpGet]
        [Route("GetFormationDetailsById/{id}")]
        public IHttpActionResult Details(int? id)
        {

            Formation Formation = service.GetFormationById(id);
            if (Formation == null)
            {
                return NotFound();
            }

            return Ok(Formation);
        }
        [HttpPost]
        [Route("InsertFormationDetails")]
        public IHttpActionResult Create(Formation formation, HttpPostedFileBase UploadInput)
        {

            if (!ModelState.IsValid || UploadInput == null || UploadInput.ContentLength == 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                /* employe.image = UploadInput.FileName;
                 TempData["image"] = UploadInput;
                 HttpPostedFileBase file = TempData["image"] as HttpPostedFileBase;*/
                service.AddFormation(formation);
                service.save();
                /*  var path = Path.Combine(HttpServer.server("~/Content/Upload"), employe.image);
                  file.SaveAs(path);*/
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(formation);
        }


        // GET: api/Formations/5
        [ResponseType(typeof(Formation))]
        public IHttpActionResult GetFormation(int id)
        {
            Formation formation = service.GetFormationById(id);
            if (formation == null)
            {
                return NotFound();
            }

            return Ok(formation);
        }

        // PUT: api/Formations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormation(int id, Formation formation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formation.id_form)
            {
                return BadRequest();
            }

            //  db.Entry(formation).State = EntityState.Modified;
            service.UpdateFormation(formation);
            service.save();
            try
            {
                service.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormationExists(id))
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

        // POST: api/Formations
        [ResponseType(typeof(Formation))]
        public IHttpActionResult PostFormation(Formation formation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.AddFormation(formation);
            service.save();

            return CreatedAtRoute("DefaultApi", new { id = formation.id_form }, formation);
        }

        // DELETE: api/Formations/5
        [ResponseType(typeof(Formation))]
        public IHttpActionResult DeleteFormation(int id)
        {
            Formation formation = service.GetFormationById(id);
            if (formation == null)
            {
                return NotFound();
            }

            service.DeleteFormation(formation);
            service.save();

            return Ok(formation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*   private bool FormationExists(int id)
           {
               return db.Formations.Count(e => e.id_form == id) > 0;
           }*/
        private bool FormationExists(int id)
        {
            return db.Formations.Count(e => e.id_form == id) > 0;
        }
    }
}