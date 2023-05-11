// See https://aka.ms/new-console-template for more information
using ConfigurationFileJson;
using Newtonsoft.Json;


Pages page = new Pages();
page.Name = "HomeComponent";
List<Fields> fields = new List<Fields>();
fields.Add(new Fields() { IsVisible = true, Name = "UnitPrice", Text = String.Empty });
fields.Add(new Fields() { IsVisible = true, Name = "Field1", Text = String.Empty });
fields.Add(new Fields() { IsVisible = true, Name = "Field2", Text = String.Empty });
fields.Add(new Fields() { IsVisible = true, Name = "Image", Text = String.Empty });
fields.Add(new Fields() { IsVisible = true, Name = "Field4", Text = String.Empty });
fields.Add(new Fields() { IsVisible = true, Name = "Field5", Text = String.Empty });







page.Fields = fields;
Configurations configuration = new Configurations();
configuration.Pages = new List<Pages>() { page };

String config = JsonConvert.SerializeObject(configuration, Formatting.Indented);
Console.WriteLine(config);
int a = 0;
