namespace webapi.Models;

public partial class StandardService
{
    public int StandardServiceId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Currency { get; set; }

    public int? ServicePackageTypeId { get; set; }

    public virtual ICollection<ServiceData> ServiceData { get; set; } = new List<ServiceData>();
}
