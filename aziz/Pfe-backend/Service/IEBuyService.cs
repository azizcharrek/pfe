using Domain.Entities;
using System;
using System.Drawing;
using System.IO;

namespace Service
{
  public  interface IEBuyService:IDisposable
    {
         void AddEmploye(Domain.Entities.Employe e);
         System.Collections.Generic.List<Domain.Entities.Employe> GetAllEmployes();
        System.Collections.Generic.List<Domain.Entities.Employe> GetAllFormateurEmployees();
        System.Collections.Generic.List<Formation> GetFirst20EmployeeByFormation(string titre);
         Employe GetEmployeById(int? id);
         void UpdateEmploye(Domain.Entities.Employe e);
         void DeleteEmploye(Domain.Entities.Employe e);
        void DeleteEmployeById(int? id);

        System.Collections.Generic.List<Formation> GetFormationBySession(string titre);
        System.Collections.Generic.List<Formation> GetAllFormationBySessionfound();
        System.Collections.Generic.List<Formation> GetAllFormations();
        System.Collections.Generic.List<Formation> GetFormationBySpecialite(string specialite);
        Formation GetFormationById(int? id);
        void DeleteFormationById(int? id);
        void DeleteFormation(Formation f);
        void UpdateFormation(Formation f);
        void AddFormation(Formation f);
        void save();


        System.Collections.Generic.List<Domain.Entities.Formateur> GetAllFormateurs();
        Formateur GetFormateurById(int? id);
        void AddFormateur(Formateur f);
        void UpdateFormateur(Formateur f);
        void DeleteFormateur(Formateur f);
        void DeleteFormateurById(int? id);
        ///////////////////////////////cours//////////////////////
        System.Collections.Generic.List<Domain.Entities.Cours> GetAllCours();
        Cours GetCoursById(int? id);
        void AddCours(Domain.Entities.Cours e);
    }
}
