using OrderAPI.DbContexts;
using OrderAPI.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<OrdersDatabaseSettings>(
    builder.Configuration.GetSection("OrdersDatabase"));

builder.Services.AddSingleton<IAppDbContext, AppDbContext>();

builder.Services.AddHttpClient("Cart", httpClient =>
    httpClient.BaseAddress = new Uri(builder.Configuration["Services:CartAPI"]));

builder.Services.RegisterOrdersModule();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapOrdersEndpoins();

app.Run();
