using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        //Dependencia com context e construtor
        private readonly SalesWebMvcContext _context;
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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            //Verificar de existe algum registro no banco de dados com a condição colocada
            if (!_context.Seller.Any(x => x.Id == obj.Id))
            {
                //Se não existir lançar exception
                throw new NotFoundException("Id not found");
            }

            //Bloco try para capturar uma possivel ocorrencia de exceção do banco de dados
            try
            {
                //Se existir atualizar o objeto
                _context.Update(obj);
                _context.SaveChanges();
            }

            //Se ocorrer a exceção do Entity Framework
            catch (DbConcurrencyException e )
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }

    }
}
