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

        public static List<Category> GetCategories(int companyId)
        {


            //Adiciona a menssagem selecine um departamento
            var cat = db.Categories.Where(c=> c.CompanyId==companyId).ToList();
            cat.Add(new Category
            {
                //se tentar salvar sem selecioner irá retornar 0
               CategoryId = 0,
               Description = "[ Selecione uma Categoria]"

            });

            //Ordena os campos do ComboBox
            return cat = cat.OrderBy(d => d.Description).ToList();

        }

        public static List<Tax> GetTaxes(int companyId)
        {


            //Adiciona a menssagem selecine um departamento
            var tax = db.Taxes.Where(c => c.CompanyId == companyId).ToList();
            tax.Add(new Tax
            {
                //se tentar salvar sem selecioner irá retornar 0
                TaxId = 0,
                Description = "[ Selecione uma Taxa]"

            });

            //Ordena os campos do ComboBox
            return tax = tax.OrderBy(d => d.Description).ToList();

        }




        public void Dispose()
        {
            db.Dispose();
        }
    }
}