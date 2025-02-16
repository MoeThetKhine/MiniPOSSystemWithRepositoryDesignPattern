﻿namespace MiniPOSSystemWithRepositoryDesignPattern.Database.Models;

#region TblInvoice

public partial class TblInvoice
{
    public string InvoiceId { get; set; } = null!;

    public DateTime? InvoiceDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public bool? IsDelete { get; set; }
}

#endregion
