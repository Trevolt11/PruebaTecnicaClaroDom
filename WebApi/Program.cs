using WebApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowAnyOrigin = "_myAllowAnyOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowAnyOrigin,
                      policy =>
                      {
                          policy.AllowAnyOrigin(); // Permite cualquier origen
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});



builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBookService, BookService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowAnyOrigin);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

