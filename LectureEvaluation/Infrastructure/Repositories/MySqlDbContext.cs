using LectureEvaluation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluation.Infrastructure.Repositories;

public class MySqlDbContext : DbContext
{
    public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
    {
    }
    
    public DbSet<Lecture> Lectures { get; set; }
    
    public DbSet<Evaluation> Evaluations { get; set; }
}