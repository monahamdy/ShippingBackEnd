using Shipping.Models;

namespace Shipping.DTO
{
    public record RegisterDtoRepresentive(
        string UserName,
        string Email,
        string Password,
        string Phone,
        string Address,
        string Governate,
        string Branch ,
        DiscountType type_of_discount ,
        int Percent 
        )
    {
        
    }
}
