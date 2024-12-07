using FoodFlow.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFlow.Modules.Measurements.Application.Domain.Entities;

public class Measurement : BaseEntity
{
    public string Token { get; set; }
    public decimal Value { get; set; }
}
