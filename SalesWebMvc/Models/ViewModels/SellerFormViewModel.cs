using System.Collections.Generic;


namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        //O que vai ser preciso no formulário
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
