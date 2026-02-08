using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICT2_InventoryManagementApp.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Rate { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }


    [ValidateNever]
    public virtual Category Category { get; set; } = null!;
}
