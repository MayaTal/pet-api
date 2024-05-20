using API;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    //I've tried to put the connection string in application.json but didn't succeed.
    var connectionString = "mongodb+srv://mayatal:IfRCVnGTB4UVYjz0@cluster0.mprpaxt.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
    return new MongoClient(connectionString);
});

builder.Services.AddScoped<MongoHelper>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
