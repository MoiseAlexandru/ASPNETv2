using ASPNETv2.Data;
using ASPNETv2.Repository.GroupRepository;
using ASPNETv2.Repository.NoteRepostitory;
using ASPNETv2.Repository.ProfileRepository;
using ASPNETv2.Repository.UserRepository;
using ASPNETv2.Services.ProfileService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<INoteRepository, NoteRepository>();
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
