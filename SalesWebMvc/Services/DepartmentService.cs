using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        //Dependencia com context e construtor
        private readonly SalesWebMvcContext _context;
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Método para retornar todos os departamentos
        public List<Department> FindAll()
        {
            //Retornar departamentos ordenado pelo nome
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
