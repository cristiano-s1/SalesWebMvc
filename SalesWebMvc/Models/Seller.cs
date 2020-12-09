﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        //Propriedades
        public int Id { get; set; }
        public String Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseDalary { get; set; }

        //Associação vendedores possui 1 departamento
        //Propriedade Department
        public Department Department { get; set; }

        //Propriedade para gerar ID quando criar um vendedor
        public int DepartmentId { get; set; }

        //Associação 1 vendedor possui n vendas
        //ICollection -> Coleção generica, aceita lista, conjuntos, etc.
        //Propriedade com nome Sales já instanciada
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //Construtor padrão
        public Seller()
        {
        }

        //Construtor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseDalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseDalary = baseDalary;
            Department = department;
        }

        //Operação para adicionar uma venda 
        //Método
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        //Operação para remover uma venda 
        //Método
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Operação para retornar o total de vendas
        //Método
        public double TotalSales(DateTime initial, DateTime final)
        {
            //filtrar vendas por data, depois calcular a soma das vendas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
