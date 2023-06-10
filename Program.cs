var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoint =>
{
	endpoint.Map("/Home", async (context) =>
	{
		await context.Response.WriteAsync("you are in homepage");
	});
	endpoint.MapGet("/Product", async (context) =>
	{
		await context.Response.WriteAsync("you are in productpage with get request");
	});
	endpoint.MapPost("/Product", async (context) =>
	{
		await context.Response.WriteAsync("you are in productpage with post request");
	});
	endpoint.MapPut("/Product", async (context) =>
	{
		await context.Response.WriteAsync("you are in productpage with put request");
	});
	endpoint.MapDelete("/Product", async (context) =>
	{
		await context.Response.WriteAsync("you are in productpage with delete request");
	});

});

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
