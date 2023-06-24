using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class ServiceData
{
    public int ServiceDataId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Street { get; set; }

    public string? Number { get; set; }

    public string? PostCode { get; set; }

    public string? Location { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? ProblemDefinition { get; set; }

    public decimal? CostCeiling { get; set; }

    public int? BikeTypeId { get; set; }

    public int? BrandId { get; set; }

    public bool? OptedForStandardService { get; set; }

    public int? StandardServiceId { get; set; }

    public bool? IsElectricDriveExist { get; set; }

    public virtual BikeType? BikeType { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual StandardService? StandardService { get; set; }
}
