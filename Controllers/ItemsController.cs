using Microsoft.AspNetCore.Mvc;
using net5api.Repositories;
using net5api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using net5api.Dtos;

namespace net5api.Controllers{


    //GET /items

    [ApiController]
    [Route("[controller]")] //same as [items]
    public class ItemsController : ControllerBase {
        private readonly IInMemItemsRepo repo;
        

        //Injected via singleton in startup

        public ItemsController(IInMemItemsRepo repo){
            this.repo = repo;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems(){

            return repo.GetItems().Select(item=>Extensions.AsDto(item));
           
        }
        //items/id
        [HttpGet("{Guid}")]
        public ActionResult<ItemDto> GetItem(Guid Guid){
            var a = Extensions.AsDto(repo.GetItem(Guid));
            if(a==null){
                return StatusCode(404);
            }
            return a;
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
           Item item = new(){
               Id= Guid.NewGuid(),
               Price = itemDto.Price,
               Name = itemDto.Name,
               CreatedDate = DateTimeOffset.UtcNow
           };

            repo.CreateItem(item);
            //return the newly created item and action where we can retrieve it's info
            //returns a 201 created response; **make sure params right! or no route matches values error
            return CreatedAtAction(nameof(GetItem),new {Guid = item.Id},itemDto);  //item type returned
        }

        //Convention for PUT is to not return anything!
        [HttpPut("{Guid}")]
        public ActionResult UpdateItem(Guid Guid, UpdateItemDto itemDto){
           Item item = repo.GetItem(Guid);
           if(item==null){
               return NotFound();
           }
           Item updateItem = item with {
               Name = itemDto.Name,
               Price = itemDto.Price

           };
           repo.UpdateItem(updateItem);
           return NoContent(); //Standard Convention for PUT return nothing

        }

        //Convention for Delete is not to return nothing
        [HttpDelete("{Guid}")]
        public ActionResult DeleteItem(Guid Guid){

            Item item = repo.GetItem(Guid);
            if(item is null){
                return NotFound();
            }

            repo.DeleteItem(Guid);
            return NoContent();

        }

    }
}