using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddResponseCaching();      // Enables caching for HTTP-requests


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// the client is compiled to static files stored in the wwwroot-folder
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        const int durationInSeconds = 60 * 60 * 24 * 7;     // Duration for keeping static files in the browser is sat to one week
        context.Context.Response.Headers[HeaderNames.CacheControl] =
        "public,max-age=" + durationInSeconds;
    }
});

app.UseResponseCaching();   // When we make a request from client it will be stored (server-side), Response can be specified for each endpoint by annotations. Sensitive data should never be cached at all!! Caching is ideal for static non-sensitive data


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
