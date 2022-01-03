using System;
using System.ComponentModel.DataAnnotations; //Used to 

namespace net5api.Dtos{
    //Used for post requests
    public record CreateItemDto{

    [Required]
    public string Name{get;init;}
    [Required]
    [Range(1,1000)]
    public decimal Price{get;init;}
    
    }
}