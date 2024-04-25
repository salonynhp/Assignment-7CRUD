using System;
using System.Collections.Generic;

namespace Employee.Entity.Models;

public partial class EmployeeMaster
{
    public int Id { get; set; }

    public Guid EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public byte? Gender { get; set; }

    public DateTimeOffset? DateOfJoining { get; set; }

    public string? Designation { get; set; }

    public virtual ICollection<AddressMaster> AddressMasters { get; set; } = new List<AddressMaster>();
}
