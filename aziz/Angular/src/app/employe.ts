import { Formation } from './formation';
import { Binary } from '@angular/compiler';

export class Employe {
    id_emp: number;
    nom: string;
    prenom: string;
    Email: string;
    cin: string;
    adress:string; 
    image: string;
    type:string;
    departement:string; 
    specialite:string; 
    date_de_naissance:Date;
    forma:boolean;
    formation:Formation;

    constructor(){}
   // virtual public List<Formation> formations { get; set; }

  
}

