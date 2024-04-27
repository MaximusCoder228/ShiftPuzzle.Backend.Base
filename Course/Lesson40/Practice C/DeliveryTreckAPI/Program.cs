using DeliveryTreckAPI;
using System.Data.SQLite; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanionRepository>(provider =>
{
    string connectPath = "Data Source=DataBase.db";
    ICompanionRepository companionRepository = new SQLLiteCaseRepository(connectPath);
    return companionRepository;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();


app.Run();


