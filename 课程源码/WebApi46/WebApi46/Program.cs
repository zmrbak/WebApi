using System.Text.RegularExpressions;

var url = "https://localhost:7161/Identity/Account/Login";

var httpClient=new HttpClient();
var content=httpClient.GetStringAsync(url).Result;
var requestVerificationToken = Regex.Match(content, @"<input[^>]+name=""__RequestVerificationToken""[^>]+type=""hidden""[^>]+value=""(.+?)""[^>]*>");

var form = new Dictionary<string, string>();
form.Add("Input.Email", "20995658@qq.com");
form.Add("Input.Password", "A20995658@qq.com");
form.Add("__RequestVerificationToken", requestVerificationToken.Groups[1].Value);
form.Add("Input.RememberMe", "false");

var result=httpClient.PostAsync(url,new FormUrlEncodedContent(form)).Result;

var apiUrl = "https://localhost:7161/api/Values";
content = httpClient.GetStringAsync(apiUrl).Result;
Console.WriteLine(content);

