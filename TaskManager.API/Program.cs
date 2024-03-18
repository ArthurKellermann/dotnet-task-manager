using TaskManager.Domain.Repositories;
using TaskManager.Domain.Repositories.Interfaces;
using TaskManager.Application.UseCases.Users.RegisterUser;
using TaskManager.Application.UseCases.Users.GetUsers;
using TaskManager.Application.UseCases.Users.GetUserById;
using TaskManager.Application.UseCases.Users.UpdateUser;
using TaskManager.Application.UseCases.Users.DeleteUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<GetUsersUseCase>();
builder.Services.AddScoped<GetUserByIdUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();
builder.Services.AddScoped<DeleteUserUseCase>();

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
