using System;
namespace net5api.Entities{
    //immuatable
    public record Item{

    public string ItemId {get;set;}
    public string Name{get;set;}
    public decimal Price{get;set;}
    public DateTimeOffset CreatedDate{get;set;}
    
    }
}