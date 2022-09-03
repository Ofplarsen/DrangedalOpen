using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath);
builder.Configuration.ConfigureConfig();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureService(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins seperated with comma
        .SetIsOriginAllowed(origin => true));// Allow any origin  
}
app.UseAuthentication();
app.UseAuthorization();
//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
