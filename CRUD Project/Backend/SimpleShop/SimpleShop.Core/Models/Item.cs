using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Core.models
{
    public class Item
    {
        public const int MAX_TITLE_LENGTH = 50;
        private Item(Guid id, string title, string description, float price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public float Price { get; }

        public static (Item Item, string Error) Create(Guid id, string title, string description, float price)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title can`t be empty or longer then 50 symbols";
            }
            var item = new Item(id, title, description, price);
            return (item, error);
        }

    }
}
