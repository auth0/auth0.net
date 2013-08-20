using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using RestSharp;
using Newtonsoft.Json;

public class PaginatedList<T> : List<T>
{
    private IDictionary<string, string> links;

    public PaginatedList(IEnumerable<T> items, string linkHeader)
        : base(items)
    {
        var entries = linkHeader.Split(',');
        if (string.IsNullOrEmpty(linkHeader))
        {
            links = new Dictionary<string, string>();
        }
        else
        {

            links = entries.ToDictionary(
                e => Regex.Match(e, "rel=\"(.*)\"").Groups[1].Value,
                e => Regex.Match(e.Trim(), "^<(.*)>").Groups[1].Value);
        }
    }

    public bool HasNextPage
    {
        get { return links.ContainsKey("next"); }
    }

    public IDictionary<string, string> Links 
    {
        get { return links; }
    }

    public PaginatedList<T> GetNextPage() 
    {
        if (!this.HasNextPage) {
            throw new InvalidOperationException();
        }

        var client1 = new RestClient(Links["next"]);
        var request = new RestRequest("");

        request.AddHeader("accept", "application/json");

        var response = client1.Execute(request);
        var linkHeader = response.Headers.FirstOrDefault(h => h.Name == "Link");

        return new PaginatedList<T>(JsonConvert.DeserializeObject<List<T>>(response.Content), linkHeader != null ? linkHeader.Value.ToString() : "");

    }

}