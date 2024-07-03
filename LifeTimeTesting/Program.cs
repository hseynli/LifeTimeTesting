using LifeTimeTesting.Filter;
using LifeTimeTesting.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<LifetimeIndicatorFilter>();
//or
builder.Services.AddScoped(provider =>
{
    return new LifetimeIndicatorFilter(provider.GetRequiredService<IIdGenerator>(),                 
                                       provider.GetRequiredService<ILogger<LifetimeIndicatorFilter>>());
});
// behaviors
builder.Services.AddTransient<IIdGenerator>(p => new IdGenerator());
//or
//builder.Services.AddTransient<IIdGenerator, IdGenerator>();
//builder.Services.AddSingleton<IdGenerator>();
//builder.Services.AddScoped<IdGenerator>();

//ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
// null if not registered
//serviceProvider.GetService<IdGenerator>();
// throws exception if not registered
//serviceProvider.GetRequiredService<IdGenerator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();