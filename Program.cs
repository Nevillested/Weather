using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;



string city = Console.ReadLine();
string url = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/"+city+"?key=ZZNADZU8FRBMC8VDJUD7GST9F&contentType=json";

HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

string response;

using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
{
    response = streamReader.ReadToEnd();
}

var client = new HttpClient();

var request = new HttpRequestMessage(HttpMethod.Get, url);

var response_sec = await client.SendAsync(request);
response_sec.EnsureSuccessStatusCode(); 

var body = await response_sec.Content.ReadAsStringAsync();

dynamic weather = JsonConvert.DeserializeObject<dynamic>(body);

foreach (var day in weather.days)
{
    string weather_date = day.datetime;
    string weather_desc = day.description;
    string weather_tmax = day.tempmax;
    string weather_tmin = day.tempmin;

    Console.WriteLine("Forecast for date: " + weather_date);
    Console.WriteLine(" General conditions: " + weather_desc);
    Console.WriteLine(" The high temperature will be " + weather_tmax);
    Console.WriteLine(" The low temperature will be: " + weather_tmin);
}
