using CodeFirst.Data;
using CodeFirst.Models;
using CodeFirst.Repository;
using CodeFirst.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<StudentServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();  // To redirect from one page to another. If not present, application would Single phase app (SPA) : one page would refresh to show content
app.UseRouting();   

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}")
    .WithStaticAssets();

// Fluent Chain Methods : No need to create controller. Used in API gateway

// A simple Fluent chain for a GET request
app.MapGet("/books/{id}", (int id) =>
{
    return Results.Ok(new { Id = id, Title = "The Great Gatsby" });
})
.WithName("GetBookById")
.WithSummary("Retrieves a single book by its unique ID");

// A Fluent chain for a POST request : can be accessed by swagger, not directly through the url

//app.MapPost("/books", (Student newStudent) => 
//{
//    // Logic to save the book to a database would go here
//    return Results.Created($"/books/{newStudent.Id}", newStudent);
//})
//.WithName("CreateBook")
//.Accepts<Student>("application/json")
//.Produces<Student>(201);

app.MapPost("/fluent/students", (Student student) =>
{
    return Results.Created($"/students/{student.Id}", student);
});

app.Run();
