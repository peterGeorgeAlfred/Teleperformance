using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.Models.Entity;
using Teleperformance.repository.IManger;

namespace Teleperformance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController<Product>
    {
       
        public ProductController(IProduct _ProductDb) : base(_ProductDb)
        {
           
           
        }





    }
}
