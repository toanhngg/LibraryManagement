using LibraryManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

// Optional: Add other services such as DB context, authentication, etc.
// builder.Services.AddDbContext<YourDbContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Optional: Configure logging, CORS, etc.
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error"); // Handle errors in production
    app.UseHsts();
}

// Optional: Enable CORS if needed
// app.UseCors("AllowAll");

app.MapGrpcService<GreeterService>();
app.MapGrpcService<BookService>();


app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
