using EconomyGame.DB;
using EconomyGame.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
	options.AddPolicy("allowFrontEnd",
					  policy =>
					  {
						  policy.WithOrigins("https://localhost:5173").AllowAnyMethod().AllowAnyHeader();
					  });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEconomyGameManager, EconomyGameManager>();
builder.Services.AddScoped<IEconomyGameDataAccess, EconomyGameDataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("allowFrontEnd");

app.UseAuthorization();

app.MapControllers();


app.Run();
