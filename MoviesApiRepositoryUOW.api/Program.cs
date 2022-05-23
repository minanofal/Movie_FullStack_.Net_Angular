using Microsoft.EntityFrameworkCore;
using MoviesApiRepositoryUOW.Core;
using MoviesApiRepositoryUOW.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((setup) => {
    setup.AddPolicy("default", (options) => {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });

}

    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
