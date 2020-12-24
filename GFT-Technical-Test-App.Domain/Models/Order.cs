using GFT_Technical_Test_App.Domain.Enums;
using System.Collections.Generic;

namespace GFT_Technical_Test_App.Domain.Models
{
    public class Order
    {
        public EnumDayTime DayTime { get; set; }
        public IList<Item> Items { get; set; }
    }
}
