using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Teleperformance.Models.Entity;

namespace Teleperformance.Context.Helper
{
   public static class ModelBulderExtiensions
    {
        public static void Seed ( this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                  new Product {Product_ModelNum = 1, Product_Name = "Pro1" , Product_QTY = 10},
                  new Product {Product_ModelNum = 2, Product_Name = "Pro2" , Product_QTY = 20},
                  new Product {Product_ModelNum = 3, Product_Name = "Pro3" , Product_QTY = 30}
               
                );
        }
    }
}
