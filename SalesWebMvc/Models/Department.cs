using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        //Propriedades
        public int Id { get; set; }
        public string Name { get; set; }

        //Associação 1 departamento possui n vendedores
        //ICollection -> Coleção generica, aceita lista, conjuntos, etc.
        //Propriedade com nome Sellers já instanciada
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //Construtor padrão
        public Department()
        {
        }

        //Construtor com argumentos (Coleções não podem estar nos argumentos)
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //Operação para adicionar um vendedor 
        //Método
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //Operação para retornar o total de vendas por departamento
        //Método
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Pegar a lista de vendedores do departamento, soma as vendas pelo periodo de data.
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }    
    }
}
