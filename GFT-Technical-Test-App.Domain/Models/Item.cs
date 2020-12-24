using GFT_Technical_Test_App.Domain.Enums;

namespace GFT_Technical_Test_App.Domain.Models
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public EnumDishType Type { get; set; }
    }
}
