using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ServiceData> ServiceData { get; set; } = new List<ServiceData>();
}
