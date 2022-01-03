using System;
namespace net5api.Entities{
    //immuatable
    public record Item{

    public Guid Id {get;init;}
    public string Name{get;init;}
    public decimal Price{get;init;}
    public DateTimeOffset CreatedDate{get;init;}
    public string Gang { get; init; }
    }
}