using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Classes
{
    public class CombosHelper : IDisposable
    {
        private static EcommerceContext db = new EcommerceContext();

        public static List<Departaments> GetDepartaments() {
       

        //Adiciona a menssagem selecine um departamento
        var dep = db.Departaments.ToList();
        dep.Add(new Departaments
            {   
                //se tentar salvar sem selecioner irá retornar 0
                DepartamentsId=0,
                Name="[ Selecione um Departamento]"

            });

            //Ordena os campos do ComboBox
            return dep=dep.OrderBy(d => d.Name).ToList();



            }

        public static List<City> GetCities()
        {


            //Adiciona a menssagem selecine um departamento
            var dep = db.Cities.ToList();
            dep.Add(new City
            {
                //se tentar salvar sem selecioner irá retornar 0
                DepartamentsId = 0,
                Name = "[ Selecione uma Cidade]"

            });

            //Ordena os campos do ComboBox
            return dep = dep.OrderBy(d => d.Name).ToList();



        }

        public static List<Company> GetCompanys()
        {


            //Adiciona a menssagem selecine um departamento
            var comp = db.Companies.ToList();
            comp.Add(new Company
            {
                //se tentar salvar sem selecioner irá retornar 0
                CompanyId = 0,
                Name = "[ Selecione uma Companhia]"

            });

            //Ordena os campos do ComboBox
            return comp = comp.OrderBy(c => c.Name).ToList();



        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}