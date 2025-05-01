using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dtos;

namespace Application.Interfaces
{
    public interface IItemService
    {
        public Item? GetItemById(int id);
        public List<Item> GetItems();
        public int AddItem(ItemDto itemDto);
        public void UpdateItem(int id, int quantity);
        public void DeleteItem(int id);
    }
}
