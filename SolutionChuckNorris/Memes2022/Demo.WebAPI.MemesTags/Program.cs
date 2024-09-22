using Memes.Core.Interfaces;
using Memes.Repositories.EfCore;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//https://gavilan.blog/2021/05/19/fixing-the-error-a-possible-object-cycle-was-detected-in-different-versions-of-asp-net-core/
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//// json serializer options 
//// https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions?view=net-6.0
/// doesn't work

//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.PropertyNameCaseInsensitive = true;
//    //https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.propertynamingpolicy?view=net-6.0#System_Text_Json_JsonSerializerOptions_PropertyNamingPolicy
//    //https://docs.microsoft.com/en-us/dotnet/api/system.text.json.jsonnamingpolicy?view=net-6.0
//    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
//    options.SerializerOptions.WriteIndented = true;
//    //https://docs.microsoft.com/en-us/dotnet/api/system.text.json.serialization.referencehandler.ignorecycles?view=net-6.0
//    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});



//var connectionString = builder.Configuration.GetConnectionString("MemesDB");


var connectionString = "Server=tcp:micgiserver2022.database.windows.net,1433;Initial Catalog=Db2022Memes ;User ID=Teacher;Password=$PSG#is#Magic$;";
builder.Services.AddDbContext<MemesDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddTransient<ITagsRepository, Memes.Repositories.EfCore.TagRepository>();


builder.Services.AddTransient<IMemesRepository, Memes.Repositories.EfCore.Repository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseAuthorization();

app.MapControllers();

app.Run();
