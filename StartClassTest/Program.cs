using StartClassTest.ConfigModel;
using StartClassTest.IServices;
using StartClassTest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IContactUsService, ContactUsService>(); 
builder.Services.Configure<EmailConfigSettings>(builder.Configuration.GetSection("EmailConfig"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthorization(); 

app.MapControllers();

app.Run();
