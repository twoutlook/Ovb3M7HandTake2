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
    [Route("odata/AppDb/SortHoleCardsStds")]
    public partial class SortHoleCardsStdsController : ODataController
    {
        private Ovb3M7Db.Server.Data.AppDbContext context;

        public SortHoleCardsStdsController(Ovb3M7Db.Server.Data.AppDbContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> GetSortHoleCardsStds()
        {
            var items = this.context.SortHoleCardsStds.AsQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>();
            this.OnSortHoleCardsStdsRead(ref items);

            return items;
        }

        partial void OnSortHoleCardsStdsRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> items);

        partial void OnSortHoleCardsStdGet(ref SingleResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/AppDb/SortHoleCardsStds(HoleCardsStd={HoleCardsStd})")]
        public SingleResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> GetSortHoleCardsStd(string key)
        {
            var items = this.context.SortHoleCardsStds.Where(i => i.HoleCardsStd == Uri.UnescapeDataString(key));
            var result = SingleResult.Create(items);

            OnSortHoleCardsStdGet(ref result);

            return result;
        }
        partial void OnSortHoleCardsStdDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        [HttpDelete("/odata/AppDb/SortHoleCardsStds(HoleCardsStd={HoleCardsStd})")]
        public IActionResult DeleteSortHoleCardsStd(string key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.SortHoleCardsStds
                    .Where(i => i.HoleCardsStd == Uri.UnescapeDataString(key))
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnSortHoleCardsStdDeleted(item);
                this.context.SortHoleCardsStds.Remove(item);
                this.context.SaveChanges();
                this.OnAfterSortHoleCardsStdDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSortHoleCardsStdUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        [HttpPut("/odata/AppDb/SortHoleCardsStds(HoleCardsStd={HoleCardsStd})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutSortHoleCardsStd(string key, [FromBody]Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.HoleCardsStd != Uri.UnescapeDataString(key)))
                {
                    return BadRequest();
                }
                this.OnSortHoleCardsStdUpdated(item);
                this.context.SortHoleCardsStds.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCardsStds.Where(i => i.HoleCardsStd == Uri.UnescapeDataString(key));
                
                this.OnAfterSortHoleCardsStdUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/AppDb/SortHoleCardsStds(HoleCardsStd={HoleCardsStd})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchSortHoleCardsStd(string key, [FromBody]Delta<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.SortHoleCardsStds.Where(i => i.HoleCardsStd == Uri.UnescapeDataString(key)).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnSortHoleCardsStdUpdated(item);
                this.context.SortHoleCardsStds.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCardsStds.Where(i => i.HoleCardsStd == Uri.UnescapeDataString(key));
                
                this.OnAfterSortHoleCardsStdUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSortHoleCardsStdCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item)
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

                this.OnSortHoleCardsStdCreated(item);
                this.context.SortHoleCardsStds.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCardsStds.Where(i => i.HoleCardsStd == item.HoleCardsStd);

                

                this.OnAfterSortHoleCardsStdCreated(item);

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
