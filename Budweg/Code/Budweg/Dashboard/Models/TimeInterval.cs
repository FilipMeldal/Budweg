using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dashboard.Models
{
    public enum TimeInterval
    {
        [Display(Name = "It's Now")]
        Now,
        OneDay,
        ThreeDays,
        OneMonth,
        ThreeMonths,
        SixMonths,
        LastYear,
        TwoYears,
    }
}
