using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Radzen;

using Ovb3M7Db.Server.Data;

namespace Ovb3M7Db.Server
{
    public partial class AppDbService
    {
        AppDbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly AppDbContext context;
        private readonly NavigationManager navigationManager;

        public AppDbService(AppDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public void ApplyQuery<T>(ref IQueryable<T> items, Query query = null)
        {
            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }
        }


        public async Task ExportPokerHandsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/pokerhands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/pokerhands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPokerHandsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/pokerhands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/pokerhands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPokerHandsRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.PokerHand> items);

        public async Task<IQueryable<Ovb3M7Db.Server.Models.AppDb.PokerHand>> GetPokerHands(Query query = null)
        {
            var items = Context.PokerHands.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnPokerHandsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPokerHandGet(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnGetPokerHandById(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.PokerHand> items);


        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> GetPokerHandById(int id)
        {
            var items = Context.PokerHands
                              .AsNoTracking()
                              .Where(i => i.Id == id);

 
            OnGetPokerHandById(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnPokerHandGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnPokerHandCreated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandCreated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> CreatePokerHand(Ovb3M7Db.Server.Models.AppDb.PokerHand pokerhand)
        {
            OnPokerHandCreated(pokerhand);

            var existingItem = Context.PokerHands
                              .Where(i => i.Id == pokerhand.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PokerHands.Add(pokerhand);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(pokerhand).State = EntityState.Detached;
                throw;
            }

            OnAfterPokerHandCreated(pokerhand);

            return pokerhand;
        }

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> CancelPokerHandChanges(Ovb3M7Db.Server.Models.AppDb.PokerHand item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPokerHandUpdated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandUpdated(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> UpdatePokerHand(int id, Ovb3M7Db.Server.Models.AppDb.PokerHand pokerhand)
        {
            OnPokerHandUpdated(pokerhand);

            var itemToUpdate = Context.PokerHands
                              .Where(i => i.Id == pokerhand.Id)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(pokerhand);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterPokerHandUpdated(pokerhand);

            return pokerhand;
        }

        partial void OnPokerHandDeleted(Ovb3M7Db.Server.Models.AppDb.PokerHand item);
        partial void OnAfterPokerHandDeleted(Ovb3M7Db.Server.Models.AppDb.PokerHand item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> DeletePokerHand(int id)
        {
            var itemToDelete = Context.PokerHands
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPokerHandDeleted(itemToDelete);


            Context.PokerHands.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPokerHandDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSortHoleCardsStdsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecardsstds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecardsstds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSortHoleCardsStdsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecardsstds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecardsstds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSortHoleCardsStdsRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> items);

        public async Task<IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>> GetSortHoleCardsStds(Query query = null)
        {
            var items = Context.SortHoleCardsStds.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSortHoleCardsStdsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSortHoleCardsStdGet(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnGetSortHoleCardsStdByHoleCardsStd(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> items);


        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> GetSortHoleCardsStdByHoleCardsStd(string holecardsstd)
        {
            var items = Context.SortHoleCardsStds
                              .AsNoTracking()
                              .Where(i => i.HoleCardsStd == holecardsstd);

 
            OnGetSortHoleCardsStdByHoleCardsStd(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSortHoleCardsStdGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSortHoleCardsStdCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> CreateSortHoleCardsStd(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd sortholecardsstd)
        {
            OnSortHoleCardsStdCreated(sortholecardsstd);

            var existingItem = Context.SortHoleCardsStds
                              .Where(i => i.HoleCardsStd == sortholecardsstd.HoleCardsStd)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SortHoleCardsStds.Add(sortholecardsstd);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(sortholecardsstd).State = EntityState.Detached;
                throw;
            }

            OnAfterSortHoleCardsStdCreated(sortholecardsstd);

            return sortholecardsstd;
        }

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> CancelSortHoleCardsStdChanges(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSortHoleCardsStdUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> UpdateSortHoleCardsStd(string holecardsstd, Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd sortholecardsstd)
        {
            OnSortHoleCardsStdUpdated(sortholecardsstd);

            var itemToUpdate = Context.SortHoleCardsStds
                              .Where(i => i.HoleCardsStd == sortholecardsstd.HoleCardsStd)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(sortholecardsstd);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSortHoleCardsStdUpdated(sortholecardsstd);

            return sortholecardsstd;
        }

        partial void OnSortHoleCardsStdDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);
        partial void OnAfterSortHoleCardsStdDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> DeleteSortHoleCardsStd(string holecardsstd)
        {
            var itemToDelete = Context.SortHoleCardsStds
                              .Where(i => i.HoleCardsStd == holecardsstd)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSortHoleCardsStdDeleted(itemToDelete);


            Context.SortHoleCardsStds.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSortHoleCardsStdDeleted(itemToDelete);

            return itemToDelete;
        }
    
        public async Task ExportSortHoleCombosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecombos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecombos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSortHoleCombosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecombos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecombos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSortHoleCombosRead(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> items);

        public async Task<IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>> GetSortHoleCombos(Query query = null)
        {
            var items = Context.SortHoleCombos.AsQueryable();


            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                ApplyQuery(ref items, query);
            }

            OnSortHoleCombosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSortHoleComboGet(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnGetSortHoleComboByHoleCombo(ref IQueryable<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> items);


        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> GetSortHoleComboByHoleCombo(string holecombo)
        {
            var items = Context.SortHoleCombos
                              .AsNoTracking()
                              .Where(i => i.HoleCombo == holecombo);

 
            OnGetSortHoleComboByHoleCombo(ref items);

            var itemToReturn = items.FirstOrDefault();

            OnSortHoleComboGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        partial void OnSortHoleComboCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboCreated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> CreateSortHoleCombo(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo sortholecombo)
        {
            OnSortHoleComboCreated(sortholecombo);

            var existingItem = Context.SortHoleCombos
                              .Where(i => i.HoleCombo == sortholecombo.HoleCombo)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SortHoleCombos.Add(sortholecombo);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(sortholecombo).State = EntityState.Detached;
                throw;
            }

            OnAfterSortHoleComboCreated(sortholecombo);

            return sortholecombo;
        }

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> CancelSortHoleComboChanges(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSortHoleComboUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboUpdated(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> UpdateSortHoleCombo(string holecombo, Ovb3M7Db.Server.Models.AppDb.SortHoleCombo sortholecombo)
        {
            OnSortHoleComboUpdated(sortholecombo);

            var itemToUpdate = Context.SortHoleCombos
                              .Where(i => i.HoleCombo == sortholecombo.HoleCombo)
                              .FirstOrDefault();

            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }
                
            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(sortholecombo);
            entryToUpdate.State = EntityState.Modified;

            Context.SaveChanges();

            OnAfterSortHoleComboUpdated(sortholecombo);

            return sortholecombo;
        }

        partial void OnSortHoleComboDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);
        partial void OnAfterSortHoleComboDeleted(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo item);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> DeleteSortHoleCombo(string holecombo)
        {
            var itemToDelete = Context.SortHoleCombos
                              .Where(i => i.HoleCombo == holecombo)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSortHoleComboDeleted(itemToDelete);


            Context.SortHoleCombos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSortHoleComboDeleted(itemToDelete);

            return itemToDelete;
        }
        }
}