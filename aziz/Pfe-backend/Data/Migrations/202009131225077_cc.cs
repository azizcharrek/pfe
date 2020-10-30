namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "C##AZIZ.Cours",
                c => new
                    {
                        id_cours = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Titre = c.String(),
                        Sprécialite = c.String(),
                        Description = c.String(),
                        Fichier = c.String(),
                    })
                .PrimaryKey(t => t.id_cours);
            
            CreateTable(
                "C##AZIZ.Employe",
                c => new
                    {
                        id_emp = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        prenom = c.String(),
                        nom = c.String(),
                        Email = c.String(),
                        cin = c.Decimal(nullable: false, precision: 10, scale: 0),
                        adress = c.String(),
                        image = c.String(),
                        type = c.Decimal(nullable: false, precision: 10, scale: 0),
                        departement = c.String(),
                        specialite = c.String(),
                        forma = c.Decimal(nullable: false, precision: 10, scale: 0),
                        date_de_naissance = c.DateTime(nullable: false),
                        Password = c.String(),
                        formation_id_form = c.Decimal(precision: 10, scale: 0),
                        Formateur_id_formateur = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_emp)
                .ForeignKey("C##AZIZ.Foramtion", t => t.formation_id_form)
                .ForeignKey("C##AZIZ.Formateur", t => t.Formateur_id_formateur)
                .Index(t => t.formation_id_form)
                .Index(t => t.Formateur_id_formateur);
            
            CreateTable(
                "C##AZIZ.Foramtion",
                c => new
                    {
                        id_form = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        titre = c.String(),
                        specialite = c.String(),
                        description = c.String(),
                        duree = c.Decimal(nullable: false, precision: 10, scale: 0),
                        date_debut = c.Decimal(nullable: false, precision: 10, scale: 0),
                        date_fin = c.Decimal(nullable: false, precision: 10, scale: 0),
                        nbr_part = c.Decimal(nullable: false, precision: 10, scale: 0),
                        certification = c.String(),
                        prix = c.Single(nullable: false),
                        sess = c.Decimal(precision: 10, scale: 0),
                        Cours_id_cours = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_form)
                .ForeignKey("C##AZIZ.Cours", t => t.Cours_id_cours)
                .ForeignKey("C##AZIZ.Session", t => t.sess)
                .Index(t => t.sess)
                .Index(t => t.Cours_id_cours);
            
            CreateTable(
                "C##AZIZ.Formateur",
                c => new
                    {
                        id_formateur = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        nom = c.String(),
                        prenom = c.String(),
                        Email = c.String(),
                        image = c.String(),
                        age = c.Decimal(nullable: false, precision: 10, scale: 0),
                        specialite = c.String(),
                        compagnie = c.String(),
                        Formation_id_form = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.id_formateur)
                .ForeignKey("C##AZIZ.Foramtion", t => t.Formation_id_form)
                .Index(t => t.Formation_id_form);
            
            CreateTable(
                "C##AZIZ.Session",
                c => new
                    {
                        id_sess = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        date_debut = c.DateTime(nullable: false),
                        date_fin = c.DateTime(nullable: false),
                        titre = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id_sess);
            
            CreateTable(
                "C##AZIZ.User",
                c => new
                    {
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Password = c.String(maxLength: 255),
                        Role = c.String(),
                        EmailConfirmed = c.Decimal(nullable: false, precision: 1, scale: 0),
                        Token = c.String(maxLength: 255),
                        image = c.String(),
                        AccessFailCount = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Type = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Enabled = c.Decimal(nullable: false, precision: 1, scale: 0),
                        PhoneNumber = c.String(),
                        LockoutDateUtc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("C##AZIZ.Foramtion", "sess", "C##AZIZ.Session");
            DropForeignKey("C##AZIZ.Formateur", "Formation_id_form", "C##AZIZ.Foramtion");
            DropForeignKey("C##AZIZ.Employe", "Formateur_id_formateur", "C##AZIZ.Formateur");
            DropForeignKey("C##AZIZ.Employe", "formation_id_form", "C##AZIZ.Foramtion");
            DropForeignKey("C##AZIZ.Foramtion", "Cours_id_cours", "C##AZIZ.Cours");
            DropIndex("C##AZIZ.Formateur", new[] { "Formation_id_form" });
            DropIndex("C##AZIZ.Foramtion", new[] { "Cours_id_cours" });
            DropIndex("C##AZIZ.Foramtion", new[] { "sess" });
            DropIndex("C##AZIZ.Employe", new[] { "Formateur_id_formateur" });
            DropIndex("C##AZIZ.Employe", new[] { "formation_id_form" });
            DropTable("C##AZIZ.User");
            DropTable("C##AZIZ.Session");
            DropTable("C##AZIZ.Formateur");
            DropTable("C##AZIZ.Foramtion");
            DropTable("C##AZIZ.Employe");
            DropTable("C##AZIZ.Cours");
        }
    }
}
