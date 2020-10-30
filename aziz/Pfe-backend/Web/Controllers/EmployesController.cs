using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Domain.Entities;
using Service;
using System.IO;
using Data;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Web.Controllers
{
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Api/Employee")]
    public class EmployesController : ApiController
    {
        IEBuyService service = null;
        public EmployesController()
        {
            service = new EBuyService();
        }
        private PfeContext db = new PfeContext();



        // GET: api/Formateurs
        [HttpGet]
        [Route("GetAllFormateurEmployees")]
        public IHttpActionResult GetAllFormateurEmployees()
        {
            List<Employe> yup = service.GetAllFormateurEmployees();
            return Ok(yup);
        }



        [HttpGet]
        [Route("GetEmployeeDetailsById/{id_emp}")]
        [AllowAnonymous]
        public IHttpActionResult Details(int? id)
        {

            Employe Employe = service.GetEmployeById(id);
            if (Employe == null)
            {
                return NotFound();
            }

            return Ok(Employe);
        }

        [HttpGet]
        [Route("AllEmployeeDetails")]
        [AllowAnonymous]
        public IHttpActionResult GetEmaployee()
        {

            IList<Employe> emp = service.GetAllEmployes();

            return Ok(emp);
        }
        [HttpPost]
        [Route("InsertEmployeeDetails")]
        [AllowAnonymous]
        public IHttpActionResult Create(Employe employe)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // employe.photo = UploadInput.FileName;
                //TempData["image"] = UploadInput;
                //  HttpPostedFileBase file = TempData["image"] as HttpPostedFileBase;
                service.AddEmploye(employe);
                service.save();
                var mediaRoot = System.Web.HttpContext.Current.Server.MapPath("~/media");
                // file.SaveAs(mediaRoot);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employe);
        }


        [HttpPost]
        [Route("Upload")]
        [AllowAnonymous]
        public async Task<string> AddDetails()
        {

            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            
            string erros ="";
            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach(var file in provider.FileData)
                {
                    var name = file.Headers.ContentDisposition.FileName;
                    name = name.Trim('"');
                    var c = name.Split('.');
                    var length = c.Length;
                    var extension = c[length - 1];
                    var toStore = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString() + "." + extension;
                    var localFileName = file.LocalFileName;
                    erros = ("localFileName : " + localFileName + " -- name : " + name + " to be Stored " + toStore);

                    var filePath = Path.Combine(root, toStore);
                    File.Move(localFileName, filePath);

                    return toStore;
                }
            }catch(Exception e)
            {
                return $"Error : {e.Message} {erros}";
            }
            return null;
           
        }


        [HttpDelete]
        [Route("DeleteEmployeeDetails")]
        [AllowAnonymous]
        public IHttpActionResult DeleteEmaployeeDelete(int id)
        {
            int empId = Convert.ToInt32(id);
            Employe objEmp = new Employe();
            objEmp = service.GetEmployeById(id);
            if (objEmp == null)
            {
                return NotFound();
            }

            service.DeleteEmploye(objEmp);
            service.save();

            return Ok(objEmp);
        }
        [HttpGet]
        [Route("GetFormationDetailsById/{formationId}")]
        [AllowAnonymous]
        public IHttpActionResult GetFormationById(int? formationId)
        {
            Formation formation = service.GetFormationById(formationId);
            int ID = Convert.ToInt32(formationId);
            try
            {
                formation = service.GetFormationById(formationId);
                if (formation == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(formation);
        }
        [HttpPut]
        [Route("UpdateEmployeeDetails")]
        [AllowAnonymous]
        public IHttpActionResult PutEmaployeeMaster(Employe employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Employe emp = new Employe();
                emp = service.GetEmployeById(employee.id_emp);
                if (emp != null)
                {
                    emp.nom = employee.nom;
                    emp.prenom = employee.prenom;
                    emp.Email = employee.Email;
                    emp.date_de_naissance = employee.date_de_naissance;
                    emp.type = employee.type;
                    emp.image = employee.image;
                    emp.cin = employee.cin;
                    emp.adress = employee.adress;
                    emp.departement = employee.departement;
                    emp.specialite = employee.specialite;
                    emp.formation = employee.formation;

                }
                service.save();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(employee);
        }

        /********************************************************Formation****************************/
        [HttpGet]
        [Route("AllFormationDetails")]
        [AllowAnonymous]
        public IHttpActionResult GetFormation()
        {

            IList<Formation> emp = service.GetAllFormations();

            return Ok(emp);
        }
        [HttpGet]
        [Route("GetFormationBySpecialite")]
        public IHttpActionResult GetFormationBySpecialite(string specialite)
        {

            List<Formation> emp = service.GetFormationBySpecialite(specialite);

            return Ok(emp);
        }
        [HttpPost]
        [Route("InsertFormationDetails")]
        [AllowAnonymous]
        
        public IHttpActionResult CreateFormation(Formation formation)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.AddFormation(formation);
                service.save();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(formation);
        }
        [HttpPut]
        [Route("UpdateformationDetails")]
        [AllowAnonymous]
        public IHttpActionResult PutFormation(Formation formation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Formation form = new Formation();
                form = service.GetFormationById(formation.id_form);
                if (form != null)
                {
                    form.titre = formation.titre;
                    form.specialite = formation.specialite;
                    form.description = formation.description;
                    form.duree = formation.duree;
                    form.date_debut = formation.date_debut;
                    form.date_fin = formation.date_fin;
                    form.nbr_part = formation.nbr_part;
                    form.certification = formation.certification;
                    form.prix = formation.prix;
                    form.Formateurs = formation.Formateurs;

                }
                service.save();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(formation);
        }
        [HttpDelete]
        [Route("DeleteFormationDetails")]
        [AllowAnonymous]
        public IHttpActionResult DeleteFormation(int id)
        {
            int empId = Convert.ToInt32(id);
            Formation objEmp = new Formation();
            objEmp = service.GetFormationById(id);
            if (objEmp == null)
            {
                return NotFound();
            }

            service.DeleteFormation(objEmp);
            service.save();

            return Ok(objEmp);
        }
        ////////////////////////////////////////////////////////////////
        /*  public string uploadimage(HttpPostedFileBase file)

          {
              Random r = new Random();
              string path = "-1";
              int random = r.Next();
              if (file != null && file.ContentLength > 0)
              {
                  string extension = Path.GetExtension(file.FileName);
                  if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                  {
                      try
                      {
                          path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                          file.SaveAs(path);
                          path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);
                          //    ViewBag.Message = "File uploaded successfully";
                      }
                      catch (Exception ex)
                      {
                          path = "-1";
                      }
                  }
                  else
                  {
                      Response.Write("<script>alert('Only jpg ,jpeg or png formats are acceptable....'); </script>");
                  }
              }
              else
              {
                  Response.Write("<script>alert('Please select a file'); </script>");
                  path = "-1";
              }
              return path;*/
        //////////////////////////////////////////////////////////cours////////////////////////////////////////////
        // GET: api/cours
        [HttpGet]
        [Route("GetAllCours")]
        public IHttpActionResult GetAllCours()
        {
            List<Employe> yup = service.GetAllFormateurEmployees();
            return Ok(yup);
        }
        [HttpGet]
        [Route("GetCoursById/{id_Cours}")]
        public IHttpActionResult DetailsCours(int? id)
        {

            Cours Cours = service.GetCoursById(id);
            if (Cours == null)
            {
                return NotFound();
            }

            return Ok(Cours);
        }
        [HttpPost]
        [Route("InsertCoursDetails")]
        public IHttpActionResult CreateCours(Cours cours)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                // employe.photo = UploadInput.FileName;
                //TempData["image"] = UploadInput;
                //  HttpPostedFileBase file = TempData["image"] as HttpPostedFileBase;
                service.AddCours(cours);
                service.save();
                var mediaRoot = System.Web.HttpContext.Current.Server.MapPath("~/media");
                // file.SaveAs(mediaRoot);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(cours);
        }
        // GET: /Cours/Edit/5
        public IHttpActionResult Edit(int id)
        {
            return Ok();
        }
       
        [HttpPut]
        [Route("CoursUpdate")]
        public IHttpActionResult CoursUpdate(Cours emp)
        {

            var objEmp = service.GetCoursById(emp.id_cours);

            if (objEmp != null)
            {
                objEmp.Titre = emp.Titre;
                objEmp.Sprécialite = emp.Sprécialite;
                objEmp.Description = emp.Description;
                objEmp.Fichier = emp.Fichier;

            }
            this.service.AddCours(objEmp);
            service.save();
            //service.save();

            /*   if ( service.save() is true)
               {
                   return Ok( "Sucessfully updated of employee records");
               }
               else
               {
                   return Ok ("Updation faild");
               }*/
            return Ok(objEmp);
                        
        }

    }
}

