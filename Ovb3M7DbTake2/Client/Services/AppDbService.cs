
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Radzen;

namespace Ovb3M7Db.Client
{
    public partial class AppDbService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;

        public AppDbService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/AppDb/");
        }


        public async System.Threading.Tasks.Task ExportPokerHandsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/pokerhands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/pokerhands/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPokerHandsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/pokerhands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/pokerhands/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetPokerHands(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.PokerHand>> GetPokerHands(Query query)
        {
            return await GetPokerHands(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.PokerHand>> GetPokerHands(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"PokerHands");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPokerHands(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.PokerHand>>(response);
        }

        partial void OnCreatePokerHand(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> CreatePokerHand(Ovb3M7Db.Server.Models.AppDb.PokerHand pokerHand = default(Ovb3M7Db.Server.Models.AppDb.PokerHand))
        {
            var uri = new Uri(baseUri, $"PokerHands");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(pokerHand), Encoding.UTF8, "application/json");

            OnCreatePokerHand(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.PokerHand>(response);
        }

        partial void OnDeletePokerHand(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeletePokerHand(int id = default(int))
        {
            var uri = new Uri(baseUri, $"PokerHands({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePokerHand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetPokerHandById(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.PokerHand> GetPokerHandById(string expand = default(string), int id = default(int))
        {
            var uri = new Uri(baseUri, $"PokerHands({id})");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPokerHandById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.PokerHand>(response);
        }

        partial void OnUpdatePokerHand(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdatePokerHand(int id = default(int), Ovb3M7Db.Server.Models.AppDb.PokerHand pokerHand = default(Ovb3M7Db.Server.Models.AppDb.PokerHand))
        {
            var uri = new Uri(baseUri, $"PokerHands({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(pokerHand), Encoding.UTF8, "application/json");

            OnUpdatePokerHand(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportSortHoleCardsStdsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecardsstds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecardsstds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSortHoleCardsStdsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecardsstds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecardsstds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetSortHoleCardsStds(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>> GetSortHoleCardsStds(Query query)
        {
            return await GetSortHoleCardsStds(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>> GetSortHoleCardsStds(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCardsStds");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSortHoleCardsStds(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>>(response);
        }

        partial void OnCreateSortHoleCardsStd(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> CreateSortHoleCardsStd(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd sortHoleCardsStd = default(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd))
        {
            var uri = new Uri(baseUri, $"SortHoleCardsStds");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(sortHoleCardsStd), Encoding.UTF8, "application/json");

            OnCreateSortHoleCardsStd(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>(response);
        }

        partial void OnDeleteSortHoleCardsStd(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteSortHoleCardsStd(string holeCardsStd = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCardsStds('{Uri.EscapeDataString(holeCardsStd.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSortHoleCardsStd(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetSortHoleCardsStdByHoleCardsStd(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd> GetSortHoleCardsStdByHoleCardsStd(string expand = default(string), string holeCardsStd = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCardsStds('{Uri.EscapeDataString(holeCardsStd.Trim().Replace("'", "''"))}')");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSortHoleCardsStdByHoleCardsStd(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd>(response);
        }

        partial void OnUpdateSortHoleCardsStd(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateSortHoleCardsStd(string holeCardsStd = default(string), Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd sortHoleCardsStd = default(Ovb3M7Db.Server.Models.AppDb.SortHoleCardsStd))
        {
            var uri = new Uri(baseUri, $"SortHoleCardsStds('{Uri.EscapeDataString(holeCardsStd.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(sortHoleCardsStd), Encoding.UTF8, "application/json");

            OnUpdateSortHoleCardsStd(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        public async System.Threading.Tasks.Task ExportSortHoleCombosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecombos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecombos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSortHoleCombosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/appdb/sortholecombos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/appdb/sortholecombos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGetSortHoleCombos(HttpRequestMessage requestMessage);

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>> GetSortHoleCombos(Query query)
        {
            return await GetSortHoleCombos(filter:$"{query.Filter}", orderby:$"{query.OrderBy}", top:query.Top, skip:query.Skip, count:query.Top != null && query.Skip != null);
        }

        public async Task<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>> GetSortHoleCombos(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCombos");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSortHoleCombos(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>>(response);
        }

        partial void OnCreateSortHoleCombo(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> CreateSortHoleCombo(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo sortHoleCombo = default(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo))
        {
            var uri = new Uri(baseUri, $"SortHoleCombos");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(sortHoleCombo), Encoding.UTF8, "application/json");

            OnCreateSortHoleCombo(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>(response);
        }

        partial void OnDeleteSortHoleCombo(HttpRequestMessage requestMessage);

        public async Task<HttpResponseMessage> DeleteSortHoleCombo(string holeCombo = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCombos('{Uri.EscapeDataString(holeCombo.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSortHoleCombo(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }

        partial void OnGetSortHoleComboByHoleCombo(HttpRequestMessage requestMessage);

        public async Task<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo> GetSortHoleComboByHoleCombo(string expand = default(string), string holeCombo = default(string))
        {
            var uri = new Uri(baseUri, $"SortHoleCombos('{Uri.EscapeDataString(holeCombo.Trim().Replace("'", "''"))}')");

            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSortHoleComboByHoleCombo(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Ovb3M7Db.Server.Models.AppDb.SortHoleCombo>(response);
        }

        partial void OnUpdateSortHoleCombo(HttpRequestMessage requestMessage);
        
        public async Task<HttpResponseMessage> UpdateSortHoleCombo(string holeCombo = default(string), Ovb3M7Db.Server.Models.AppDb.SortHoleCombo sortHoleCombo = default(Ovb3M7Db.Server.Models.AppDb.SortHoleCombo))
        {
            var uri = new Uri(baseUri, $"SortHoleCombos('{Uri.EscapeDataString(holeCombo.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(sortHoleCombo), Encoding.UTF8, "application/json");

            OnUpdateSortHoleCombo(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}