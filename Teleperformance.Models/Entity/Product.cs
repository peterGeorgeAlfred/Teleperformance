using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Teleperformance.Models.Entity
{
    public class Product
    {
        #region ID
        [Key]
        public int Product_ModelNum { get; set; }
        #endregion

        #region Name
        [Required(ErrorMessage = "Product name is Required")]
        public string Product_Name { get; set; }

        #endregion

        #region QTY

        [Required(ErrorMessage = "prdouct quantity  is requrid")]
        public int Product_QTY { get; set; }
        #endregion
    }
}
