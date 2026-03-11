using HidingFieldsAPI.Data;
using HidingFieldsAPI.Repository;
using HidingFieldsAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();   // Service = property (starts with capital letter)

builder.Services.AddDbContext<StudentPortalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// If app environment is not development, app would not debug(breakpoints wont work) and would run directly.
if (app.Environment.IsDevelopment())   // In dev env, errors will be thrown in swagger ui
{
    app.UseSwagger();   // Swagger document
    app.UseSwaggerUI();  // swagger user interaction
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();