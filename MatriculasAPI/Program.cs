using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.MapPost("/reporte", () =>
{
    //Logica que obtenga los datos de la BD
    //Convertir información a HTML
    var htmlCode = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Template\\invoice1.html");
    SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
    SelectPdf.PdfDocument doc = converter.ConvertHtmlString(htmlCode);
    //doc.Save(AppDomain.CurrentDomain.BaseDirectory + "Template\\invoice1.pdf");
    byte[] data = doc.Save();
    var result = Convert.ToBase64String(data);
    doc.Close();
    //{status = "ok", data = "result"};
    return result;
});



app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
