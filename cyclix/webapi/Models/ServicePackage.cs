using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class ServicePackage
{
    public int ServicePackageId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Currency { get; set; }

    public int? ServicePackageTypeId { get; set; }

    public virtual ServicePackageType? ServicePackageType { get; set; }
}
