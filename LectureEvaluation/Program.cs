using LectureEvaluation.Domain.Repositories;
using LectureEvaluation.Domain.Services;
using LectureEvaluation.Infrastructure.Repositories;
using LectureEvaluation.Infrastructure.MockRepositories;
using LectureEvaluation.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpClient();

var connectionString = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<MySqlDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// builder.Services.AddSingleton<IEvaluationRepository, MockEvaluationRepository>();
// builder.Services.AddSingleton<ILectureRepository, MockLectureRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IEvaluationRepository, EvaluationRepository>();
builder.Services.AddScoped<IEvaluationSummaryService, EvaluationSummaryService>();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
