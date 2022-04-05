using Newtonsoft.Json;

string city = Console.ReadLine();
string url = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/" + city + "?unitGroup=metric&key=ZZNADZU8FRBMC8VDJUD7GST9F&contentType=json";

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

    Console.WriteLine("Learn english mthrfckr");
    Console.WriteLine("Forecast for date: " + weather_date);
    Console.WriteLine("Forecast for date: " + weather_date);
    Console.WriteLine("General conditions: " + weather_desc);
    Console.WriteLine("The high temperature will be " + weather_tmax);
    Console.WriteLine("The low temperature will be: " + weather_tmin);
}
