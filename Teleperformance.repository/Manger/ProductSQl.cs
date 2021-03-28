using Teleperformance.Context;
using Teleperformance.Models.Entity;
using Teleperformance.repository.IGeneral;
using Teleperformance.repository.IManger;

namespace Teleperformance.repository.Manger
{


    public class ProductSQl : General<Product>, IProduct
    {

        public ProductSQl(DBContext _db) : base(_db)
        {

        }
    }
}
