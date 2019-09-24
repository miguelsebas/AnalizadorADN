using FParsec;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiciosWeb.Data.Modelo;
using ServicioWeb.Services;
using ServicioWeb.Services.Servicios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace ServicioWeb.WebApi.Controllers
{
    public class mutantController : ApiController
    {
        //Se instancia la BD y los Servicios
        MutantServices _sevicioMutant = new MutantServices();
        BDMutantEntities BD = new BDMutantEntities();

        //En este Get traemos los Stats que piden en los requerimientos usando la clase Stats creada para poder
        //devolver un JSON
        [System.Web.Http.HttpGet]
        public Stats Get()
        {
            var personas = BD.Person.ToList();
            Stats stats = new Stats();
            stats.Mutant = personas.Where(x => x.Mutant == 1).Count();
            stats.Human = personas.Where(x => x.Mutant == 0).Count();           
            stats.Ratio = stats.Mutant % personas.Count();
            return stats;
        }

        //En este Post Revisamos el Array que se nos manda y se guarda la informacion en la BD
        [System.Web.Mvc.HttpPost]        
        public int Index([Microsoft.AspNetCore.Mvc.FromBody]ADN dna)
        {
            try
            {
                byte valueToSave = 0;
                var personToInsert = new Person();
                //Con este procedimiento unimos el Array para crear un solo String para almacenar
                personToInsert.DNA = String.Join("", dna.dna);
                var dnaAArray = dna.ToString();
                // Invocamos al servicio que revisa todas las posibles variantes de concurrencias
                bool flag = _sevicioMutant.IsMutant(dna);
                if (flag)
                {
                    valueToSave = 1;
                }
                else
                {
                    valueToSave = 0;
                }
                personToInsert.Mutant = valueToSave;
                BD.Person.Add(personToInsert);
                BD.SaveChanges();
                //De Acuerdo al resultado del servicio sabemos si es mutante o no se lo plasma con los requerimientos pedidos
                if (valueToSave == 1)
                {
                    //Es Mutante
                    return StatusCodes.Status200OK;
                }
                else
                {
                    //No es Mutante
                    return StatusCodes.Status403Forbidden;
                }
            }
            catch (Exception)
            {
                return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
