﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Setting
{
    public int SettingId { get; set; }

    public int UserId { get; set; }

    public string? NotificationPreferences { get; set; }

    public string? CurrencyDisplay { get; set; }

    public string? Language { get; set; }

    public virtual User User { get; set; } = null!;
}
