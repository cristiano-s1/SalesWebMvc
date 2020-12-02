using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SalesWebMvc.Services
{
    public class SellerService
    {
        //Dependencia com SalesWebMvcContext
        private readonly SalesWebMvcContext _context;

        //Construtor com argumentos
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Criar um método de lista para retornar todos os vendedores do banco de dados
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        //Inserir um novo vendedor no banco de dados
        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
