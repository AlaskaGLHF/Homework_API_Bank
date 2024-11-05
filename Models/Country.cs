﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}