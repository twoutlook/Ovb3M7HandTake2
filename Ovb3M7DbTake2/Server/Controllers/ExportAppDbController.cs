using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Ovb3M7Db.Server.Data;

namespace Ovb3M7Db.Server.Controllers
{
    public partial class ExportAppDbController : ExportController
    {
        private readonly AppDbContext context;
        private readonly AppDbService service;

        public ExportAppDbController(AppDbContext context, AppDbService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/AppDb/pokerhands/csv")]
        [HttpGet("/export/AppDb/pokerhands/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPokerHandsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPokerHands(), Request.Query, false), fileName);
        }

        [HttpGet("/export/AppDb/pokerhands/excel")]
        [HttpGet("/export/AppDb/pokerhands/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportPokerHandsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPokerHands(), Request.Query, false), fileName);
        }

        [HttpGet("/export/AppDb/sortholecardsstds/csv")]
        [HttpGet("/export/AppDb/sortholecardsstds/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSortHoleCardsStdsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSortHoleCardsStds(), Request.Query, false), fileName);
        }

        [HttpGet("/export/AppDb/sortholecardsstds/excel")]
        [HttpGet("/export/AppDb/sortholecardsstds/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSortHoleCardsStdsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSortHoleCardsStds(), Request.Query, false), fileName);
        }

        [HttpGet("/export/AppDb/sortholecombos/csv")]
        [HttpGet("/export/AppDb/sortholecombos/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSortHoleCombosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetSortHoleCombos(), Request.Query, false), fileName);
        }

        [HttpGet("/export/AppDb/sortholecombos/excel")]
        [HttpGet("/export/AppDb/sortholecombos/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportSortHoleCombosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetSortHoleCombos(), Request.Query, false), fileName);
        }
    }
}
