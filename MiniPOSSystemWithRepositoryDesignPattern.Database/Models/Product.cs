﻿using System;
using System.Collections.Generic;

namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string ProductCategoryId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int Qty { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsDelete { get; set; }
}