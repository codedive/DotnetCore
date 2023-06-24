using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class ServicePackageType
{
    public int ServicePackageTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ServicePackage> ServicePackages { get; set; } = new List<ServicePackage>();
}
