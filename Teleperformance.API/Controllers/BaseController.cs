using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teleperformance.repository.IGeneral;

namespace Teleperformance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class BaseController<TEnttiy> : ControllerBase where TEnttiy : class
    {

        private readonly IGeneral<TEnttiy> GeneralDB;
       
        public BaseController(IGeneral<TEnttiy> _GeneralDB)
        {
            GeneralDB = _GeneralDB;
        }

        #region GET
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEnttiy>>> GetAll()
        {
            try
            {
                return await GeneralDB.GetAll();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEnttiy>> Get(int id)
        {
            try
            {
                var result = await GeneralDB.GetById(id);
                if (result == null)
                    return NotFound($"Cannot Find {typeof(TEnttiy).Name} with id {id}");

                return Ok(result);
            }// try 
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            } // catch 
        }

        #endregion

        #region POST
        [HttpPost]
        public virtual async Task<ActionResult<TEnttiy>> Post(TEnttiy addedItem)
        {
            try
            {

            
                addedItem = await GeneralDB.ADD(addedItem);
                if (addedItem == null)
                    return BadRequest(null);
                return Created("",addedItem);

            }
            catch
            {

                return Problem();

            }


        }

        #endregion

        #region PUT
        [HttpPut]
        public async Task<IActionResult> Put(TEnttiy updatedItem)
        {

            try
            {


                

                var updatedShop = await GeneralDB.Update(updatedItem);
                if (updatedShop == null)
                    return NotFound();

                return Ok(updatedItem);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
        #endregion

        #region Delete
        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEnttiy>> Delete(int id)
        {
            var Item = await GeneralDB.Delete(id);
            if (Item == null)
            {
                return NotFound();
            }
            return Ok(Item);


        }

        #endregion


    }// class
}
