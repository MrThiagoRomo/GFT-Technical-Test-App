using GFT_Technical_Test_App.Domain.Enums;
using GFT_Technical_Test_App.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GFT_Technical_Test_App.ApplicationService
{
    public class OrderAppService : IOrderAppService
    {

        public Post OrderWorkflow(Post inputOrder)
        {

            Post outputOrder = new Post();

            try
            {

                if (inputOrder.value != "")
                {
                    var list = inputOrder.value.Split(',');

                    var str = list[0].ToString().ToLowerInvariant();

                    switch (str)
                    {
                        case "morning":
                            outputOrder = ManageDayOrder(list, 1);
                            break;
                        case "night":
                            outputOrder = ManageDayOrder(list, 2);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    throw new Exception("The Input String Cannot be null.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Message: " + ex.Message + " Stack: " + ex.StackTrace);
            }

            return outputOrder;
        }

        public Post ManageDayOrder(string[] list, int enumType)
        {

            Post decodedOrder = new Post();
            IList<string> strings = new List<string>();
            Item orderItem = new Item();
            int i = 0;

            foreach (var item in list)
            {

                if (i > 0)
                {
                    var dishOption = int.Parse(list[i]);

                    if (enumType == 1)
                    {

                        var name = (EnumDishOptionsMorning)dishOption;
                        orderItem.Name = name.ToString();

                    }
                    else
                    {
                        var name = (EnumDishOptionsNight)dishOption;
                        orderItem.Name = name.ToString();

                    }

                    strings.Add(orderItem.Name);

                }

                i++;
            }

            decodedOrder = GroupItems(strings);

            return decodedOrder;
        }

        public Post GroupItems(IList<string> strings)
        {

            IList<string> orderCount = new List<string>();
            Post orderList = new Post();

            try
            {
                var grouped = strings
                                  .GroupBy(s => s)
                                  .Select(g => new { Symbol = g.Key, Count = g.Count() });

                foreach (var item in grouped)
                {
                    var symbol = item.Symbol;
                    if (item.Count > 1)
                    {
                        symbol = symbol + "(X" + item.Count.ToString() + ")";
                    }

                    orderCount.Add(symbol);

                }

                string outputList = string.Join(",", orderCount);
                orderList.value = outputList;

            }
            catch (Exception)
            {

                throw;
            }

            return orderList;
        }

    }
}
