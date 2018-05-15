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
    public void Dispose()
        {
            db.Dispose();
        }
    }
}