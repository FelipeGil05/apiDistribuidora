using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Dtos;

namespace Application.Interfaces
{
    public interface ICartService
    {
        public Cart? GetCartById(int id);
        public Cart? GetCartByClientId(int id);
        public List<Cart> GetCarts();
        public int AddCart(CartDto cartDto);
        public void AddItemToCart(int cartId, int itemId);
        public void UpdateCart(int id, bool delivery);
        public void DeleteCart(int id);
    }
}
