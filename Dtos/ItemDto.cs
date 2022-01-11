using System;

namespace net5api.Dtos{
     //immuatable
    public record ItemDto{

    public string Id {get;init;}
    public string Name{get;init;}
    public decimal Price{get;init;}
    public DateTimeOffset CreatedDate{get;init;}
    }
}