using net5api.Dtos;
using net5api.Entities;
namespace net5api{
    public static class Extensions{

        public static ItemDto AsDto(Item item){
            return new ItemDto{
                Id = item.Id,
                Price = item.Price,
                Name = item.Name,
                CreatedDate = item.CreatedDate
            };

        }

    }
}