using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using WeatherApp;
using Supabase;
using System.Net.Http;
using Blazored.LocalStorage;
using MongoDB.Driver;
using MongoDB.Bson;  // Add this line for MongoDB usage

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Add MudBlazor services
builder.Services.AddMudServices();

// Add HttpClient service for API calls
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Supabase connection setup
var supabaseUrl = "https://ncqdtgupapsahbhavhtp.supabase.co";
var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im5jcWR0Z3VwYXBzYWhiaGF2aHRwIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzczNTQzMjMsImV4cCI6MjA1MjkzMDMyM30.ShiqlbJ3JW7XzxM9A6kFHJnlYm4vTFheSeeSg6y-UbQ"; // Secure this key appropriately
var supabaseOptions = new Supabase.SupabaseOptions();
builder.Services.AddSingleton(new Supabase.Client(supabaseUrl, supabaseKey, supabaseOptions));

// Register LocalStorage service
builder.Services.AddBlazoredLocalStorage();

// MongoDB connection setup
builder.Services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb://localhost:27017"));

await builder.Build().RunAsync();
