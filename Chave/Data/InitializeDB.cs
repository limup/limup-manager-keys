using Chave.Models.ChaveViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chave.Data
{
    public class InitializeDB
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Procura por empresas
            if (context.Empresa.Any())
            {
                return;   //O BD foi alimentado
            }

            // Procura por empresas
            if (context.Licenca.Any())
            {
                return;   //O BD foi alimentado
            }

            var empresa = new EmpresaViewModels[]
            {
              new EmpresaViewModels{Id=1, Nome="Limup"},
              new EmpresaViewModels{Id=2, Nome="Microsoft"},
            };

            foreach (EmpresaViewModels p in empresa)
            {
                context.Empresa.Add(p);
            }

            context.SaveChanges();
        }
    }
}
