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
    [Route("odata/AppDb/SortHoleCombos")]
    public partial class SortHoleCombosController : ODataController
    {
        private Ovb3M7Db.Server.Data.AppDbContext context;

        public SortHoleCombosController(Ovb3M7Db.Server.Data.AppDbContext context)
        {
            this.context = context;
        }

    
        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IEnumerable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> GetSortHoleCombos()
        {
            var items = this.context.SortHoleCombos.AsQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>();
            this.OnSortHoleCombosRead(ref items);

            return items;
        }

        partial void OnSortHoleCombosRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> items);

        partial void OnSortHoleComboGet(ref SingleResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> item);

        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [HttpGet("/odata/AppDb/SortHoleCombos(HoleCombo={HoleCombo})")]
        public SingleResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> GetSortHoleCombo(string key)
        {
            var items = this.context.SortHoleCombos.Where(i => i.HoleCombo == Uri.UnescapeDataString(key));
            var result = SingleResult.Create(items);

            OnSortHoleComboGet(ref result);

            return result;
        }
        partial void OnSortHoleComboDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        [HttpDelete("/odata/AppDb/SortHoleCombos(HoleCombo={HoleCombo})")]
        public IActionResult DeleteSortHoleCombo(string key)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                var item = this.context.SortHoleCombos
                    .Where(i => i.HoleCombo == Uri.UnescapeDataString(key))
                    .FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                this.OnSortHoleComboDeleted(item);
                this.context.SortHoleCombos.Remove(item);
                this.context.SaveChanges();
                this.OnAfterSortHoleComboDeleted(item);

                return new NoContentResult();

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSortHoleComboUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        [HttpPut("/odata/AppDb/SortHoleCombos(HoleCombo={HoleCombo})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PutSortHoleCombo(string key, [FromBody]Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (item == null || (item.HoleCombo != Uri.UnescapeDataString(key)))
                {
                    return BadRequest();
                }
                this.OnSortHoleComboUpdated(item);
                this.context.SortHoleCombos.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCombos.Where(i => i.HoleCombo == Uri.UnescapeDataString(key));
                
                this.OnAfterSortHoleComboUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPatch("/odata/AppDb/SortHoleCombos(HoleCombo={HoleCombo})")]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult PatchSortHoleCombo(string key, [FromBody]Delta<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> patch)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var item = this.context.SortHoleCombos.Where(i => i.HoleCombo == Uri.UnescapeDataString(key)).FirstOrDefault();

                if (item == null)
                {
                    return BadRequest();
                }
                patch.Patch(item);

                this.OnSortHoleComboUpdated(item);
                this.context.SortHoleCombos.Update(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCombos.Where(i => i.HoleCombo == Uri.UnescapeDataString(key));
                
                this.OnAfterSortHoleComboUpdated(item);
                return new ObjectResult(SingleResult.Create(itemToReturn));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        partial void OnSortHoleComboCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        [HttpPost]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        public IActionResult Post([FromBody] Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item)
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

                this.OnSortHoleComboCreated(item);
                this.context.SortHoleCombos.Add(item);
                this.context.SaveChanges();

                var itemToReturn = this.context.SortHoleCombos.Where(i => i.HoleCombo == item.HoleCombo);

                

                this.OnAfterSortHoleComboCreated(item);

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
