using System;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        //Propriedades
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        //Propriedades Enums
        public SaleStatus Status { get; set; }

        //Associação vendas possui 1 vendedor
        //Propriedade Seller
        public Seller Seller { get; set; }

        //Construtor padrão
        public SalesRecord()
        {
        }

        //Construtor com argumentos
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
