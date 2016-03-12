﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class ProductBatchViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(1, 9999)]
        public decimal Price  { get; set; }
          [Required]
          [Range(1, 9999)]
        public decimal Stock { get; set; }
    }
}