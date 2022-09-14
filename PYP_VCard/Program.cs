using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PYP_VCard.DataContext;
using PYP_VCard.Models;
using System.Net;

HttpClient client = new HttpClient();
var request = await client.GetAsync("https://randomuser.me/api?results=50");

var responseString = request.Content.ReadAsStringAsync().Result;
//var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString);
var result=JObject.Parse(responseString);

Context context = new Context();
var a = Environment.NewLine;
for (var i = 0; i < result["results"].ToArray().Length; i++)
{
    VCard card=new VCard();
    card.FirstName= result["results"][i]["name"]["first"].ToString();
    card.LastName= result["results"][i]["name"]["last"].ToString();
    card.Phone= result["results"][i]["phone"].ToString();
    card.Email= result["results"][i]["email"].ToString();
    card.Country = result["results"][i]["location"]["country"].ToString();
    card.City = result["results"][i]["location"]["city"].ToString();
    await context.VCards.AddAsync(card);
    context.SaveChanges();

    
}
context.VCards
        .ToList()
        .ForEach(x =>
            Console.WriteLine($"{a} BEGIN:VCARD {a} FN:{x.FirstName} d'{x.LastName} {a} N:d'{x.LastName};{x.FirstName} {a} SORT-STRING:{x.LastName} {a} END:VCARD "));


