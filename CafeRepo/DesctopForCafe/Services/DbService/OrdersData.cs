using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopForCafe.Services.DbService
{
    public class OrdersData
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<ProductsData> Items { get; set; }
    }
    public class CustomersData
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone  { get; set; }
        public string Email { get; set; }
    }
    public class ProductsData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
