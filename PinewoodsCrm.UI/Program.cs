using PinewoodsCrm.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddTransient<ICustomersService, CustomersService>()
    .AddRazorPages();

builder.Services.AddHttpClient<ICustomersService, CustomersService>(client => { client.BaseAddress = new Uri(builder.Configuration["ApiUrl"] ?? ""); });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
