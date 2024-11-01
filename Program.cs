using ims.Data;
using ims.Repository.StockRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// setup controller
builder.Services.AddControllers();
// 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// setup database
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IStockRepository, StockRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// allow * origin
app.UseCors(x => x
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials()
      .WithOrigins("http://localhost:5173")
      .SetIsOriginAllowed(origin => true));

app.MapControllers();

app.Run();
