using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VP_Details.Models;

namespace VP_Details.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();


            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MockDataStore)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("VP_Details.Assets.US_Vice_Presidents.csv");
            using (var reader = new StreamReader(stream))
            {
                var rank = 0;
                int count = 0;
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLine();
                    if (count == 0)
                    {
                        count++;
                        continue;
                    }
                    var values = line.Split(',');
                    if (values.Count() < 7)
                    {
                        count++;
                        continue;
                    }
                    Int32.TryParse(values[0], out rank);
                    items.Add(new Item()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Rank = rank,
                        Text = values[1],
                        PartyAff = values[2],
                        Term = values[3],
                        BirthPlace = values[4],
                        Born = values[5],
                        Died = values[6],
                        ServedUnder = values[7]
                    });
                    count++;
                }
            }




            var mockItems = items;
            //new List<Item>
            //{
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
            //    new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            //};

            //foreach (var item in mockItems)
            //{
            //    items.Add(item);
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}