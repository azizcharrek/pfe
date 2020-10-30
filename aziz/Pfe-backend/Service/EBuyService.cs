using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Service
{
    public class EBuyService : IEBuyService
    {
        IDatabaseFactory factory = null;
        IUnitOfWork uow = null;

        public EBuyService()
        {
            factory = new DatabaseFactory();
            uow = new UnitOfWork(factory);
        }


        /*mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmEmployee*/
        public void AddEmploye(Employe e)
        {
            //add the product in context set
            uow.EmployeRepository.Add(e);
        }
        public List<Employe> GetAllEmployes()
        {
            return uow.EmployeRepository.GetAll().ToList();
        }
        public Employe GetEmployeById(int? id)
        {
            return uow.EmployeRepository.GetById(id);
        }
        public void UpdateEmploye(Employe e)
        {
            uow.EmployeRepository.Update(e);
        }
        public void DeleteEmploye(Employe e)
        {
            uow.EmployeRepository.Delete(e);
        }
        public void DeleteEmployeById(int? id)
        {
            Employe e = uow.EmployeRepository.GetById(id);
            uow.EmployeRepository.Delete(e);
            uow.EmployeRepository.Delete(pr => pr.id_emp == id);
        }
        public List<Employe> GetEmployeByFormation(string titre)
        {
            return uow.EmployeRepository.GetMany(p => p.formation.titre == titre).ToList();
        }
        public void save()
        {
            try
            {
                uow.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /*mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm   FORMATION   mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm*/
        public List<Formation> GetFormationBySession(string titre)
        {
            return uow.FormationRepository.GetMany(p => p.session.titre == titre).ToList();
        }
        public List<Formation> GetAllFormationBySessionfound()
        {
            return uow.FormationRepository.GetMany(p => p.session.date_fin < DateTime.Now).ToList();
        }
        public List<Formation> GetFormationBySpecialite(string specialite)
        {
            return uow.FormationRepository.GetMany(p => p.specialite == specialite).ToList();
        }
      /*  public List<Employe> GetFirst20EmployeeByFormation(string titre)
        {
            return uow.EmployeRepository.GetMany(p => p.formation.titre==titre).Count()).Take(20).ToList();
        }*/
        public void AddFormation(Formation f)
        {
            //add the product in context set
            uow.FormationRepository.Add(f);
        }
        public void UpdateFormation(Formation f)
        {
            uow.FormationRepository.Update(f);
        }
        public void DeleteFormation(Formation f)
        {
            uow.FormationRepository.Delete(f);
        }
        public void DeleteFormationById(int? id)
        {
            Formation e = uow.FormationRepository.GetById(id);
            uow.FormationRepository.Delete(e);
            uow.FormationRepository.Delete(pr => pr.id_form == id);
        }
        public List<Formation> GetAllFormations()
        {
            return uow.FormationRepository.GetAll().ToList();
        }
        public Formation GetFormationById(int? id)
        {
            return uow.FormationRepository.GetById(id);
        }


       
        ///////////////////////////////////////////////////////Formateur
        public List<Formateur> GetAllFormateurs()
        {
            return uow.FormateurRepository.GetAll().ToList();
    }
        public List<Employe> GetAllFormateurEmployees()
        {
            return uow.EmployeRepository.GetMany(p=>p.forma ==1).ToList();
        }
        public Formateur GetFormateurById(int? id)
        {
            return uow.FormateurRepository.GetById(id);
        }
        public void AddFormateur(Formateur f)
        {
            uow.FormateurRepository.Add(f);
        }
        public void UpdateFormateur(Formateur f)
        {
            uow.FormateurRepository.Update(f);
        }
        public void DeleteFormateur(Formateur f)
        {
            uow.FormateurRepository.Delete(f);
        }
        public void DeleteFormateurById(int? id)
        {
            Formateur e = uow.FormateurRepository.GetById(id);
            uow.FormateurRepository.Delete(e);
            uow.FormateurRepository.Delete(pr => pr.id_formateur == id);
        }

        public List<Formation> GetFirst20EmployeeByFormation(string titre)
        {
            throw new NotImplementedException();
        }
        ///////////////////////////cours////////////////
        public List<Cours> GetAllCours()
        {
            return uow.CoursRepository.GetAll().ToList();
        }
        public Cours GetCoursById(int? id)
        {
            return uow.CoursRepository.GetById(id);
        }
        public void AddCours(Cours f)
        {
            //add the product in context set
            uow.CoursRepository.Add(f);
        }
    }
    
}
