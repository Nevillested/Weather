using Newtonsoft.Json;

string city = Console.ReadLine();
string url = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "?unitGroup=metric&key=ZZNADZU8FRBMC8VDJUD7GST9F&contentType=json";

var client = new HttpClient();

var request = new HttpRequestMessage(HttpMethod.Get, url);

var response_sec = await client.SendAsync(request);
response_sec.EnsureSuccessStatusCode(); 

var body = await response_sec.Content.ReadAsStringAsync();

dynamic weather = JsonConvert.DeserializeObject<dynamic>(body);

Console.WriteLine("Learn english mthrfckr");
foreach (var day in weather.days)
{
    Console.WriteLine("Date: " + day.datetime + ". Desccription: " + day.description + " Max t:" + day.tempmax + "°. Min t:" + day.tempmin+ "°.");
}
