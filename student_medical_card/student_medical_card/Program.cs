using student_medical_card.Repository.PrescriptionRepo.Implementations;
using student_medical_card.Repository.PrescriptionRepo.Interfaces;
using student_medical_card.Repository.StudentRepo.Implements;
using student_medical_card.Repository.StudentRepo.Interfaces;
using student_medical_card.Service.PrescriptionRepo.interfaces;
using student_medical_card.Service.PrescriptionServ.implementation;
using student_medical_card.Service.StudentServ.Implementations;
using student_medical_card.Service.StudentServ.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<s_IGetRepo, s_GetRepo>();
builder.Services.AddScoped<s_IGetServ, s_GetServ>();

builder.Services.AddScoped<p_IAddRepo, p_AddRepo>();
builder.Services.AddScoped<p_IAddServ, p_AddServ>();

builder.Services.AddScoped<s_IAddRepo, s_AddRepo>();
builder.Services.AddScoped<s_IAddServ, s_AddServ>();

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
