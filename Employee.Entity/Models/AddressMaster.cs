using System;
using System.Collections.Generic;

namespace Employee.Entity.Models;

public partial class AddressMaster
{
    public int Id { get; set; }

    public Guid AddressId { get; set; }

    public Guid EmployeeId { get; set; }

    public string? Address { get; set; }

    public int? PinCode { get; set; }

    public virtual EmployeeMaster Employee { get; set; } = null!;
}
