using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ovb3M7Db.Server.Controllers.AppDb
{
    [Route("odata/AppDb/PokerHands")]
    public partial class PokerHandsController : ODataController
    {
        private Ovb3M7Db.Server.Data.AppDbContext context;

        public PokerHandsController(Ovb3M7Db.Server.Data.AppDbContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<Ovb3M7Db.Server.Models.AppDb.PokerHand> GetPokerHands()
        {
            var items = this.context.PokerHands.AsQueryable<Ovb3M7Db.Server.Models.AppDb.PokerHand>();
            this.OnPokerHandsRead(ref items);

            return items;
        }

        partial void OnPokerHandsRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.PokerHand> items);

        partial void OnPokerHandGet(ref SingleResult<Ovb3M7Db.Server.Models.AppDb.PokerHand> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/AppDb/PokerHands(Id={Id})")]
        public SingleResult<Ovb3M7Db.Server.Models.AppDb.PokerHand> GetPokerHand(int key)
        {
            var items = this.context.PokerHands.Where(i => i.Id == key);
            var result = SingleResult.Create(items);

            OnPokerHandGet(ref result);

            return result;
        }
        partial void OnPokerHandDeleted(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandDeleted(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        [HttpDelete("/odata/AppDb/PokerHands(Id={Id})")]
        public IActionResult DeletePokerHand(int key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.PokerHands
                    .Where(i => i.Id == key)
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnPokerHandDeleted(item);
                this.context.PokerHands.Remove(item);
                this.context.SaveChanges();
                this.OnAfterPokerHandDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnPokerHandUpdated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandUpdated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        [HttpPut("/odata/AppDb/PokerHands(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutPokerHand(int key, [FromBody]Ovb3M7Db.Server.Models.AppDb.PokerHand item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.Id != key))
                {
                    return BadRequest();
                }
                this.OnPokerHandUpdated(item);
                this.context.PokerHands.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.PokerHands.Where(i => i.Id == key);
                
                this.OnAfterPokerHandUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/AppDb/PokerHands(Id={Id})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchPokerHand(int key, [FromBody]Delta<Ovb3M7Db.Server.Models.AppDb.PokerHand> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.PokerHands.Where(i => i.Id == key).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnPokerHandUpdated(item);
                this.context.PokerHands.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.PokerHands.Where(i => i.Id == key);
                
                this.OnAfterPokerHandUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnPokerHandCreated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandCreated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] Ovb3M7Db.Server.Models.AppDb.PokerHand item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null)
                {
                    return BadRequest();
                }

                this.OnPokerHandCreated(item);
                this.context.PokerHands.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.PokerHands.Where(i => i.Id == item.Id);

                

                this.OnAfterPokerHandCreated(item);

                return new ObjectResult(SingleResult.Create(itemToReturn))
                {
                    StatusCode = 201
                };
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
