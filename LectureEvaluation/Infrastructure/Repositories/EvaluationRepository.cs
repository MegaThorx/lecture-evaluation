using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluation.Infrastructure.Repositories;

public class EvaluationRepository(MySqlDbContext context) : IEvaluationRepository
{
    public async Task<List<Evaluation>> FindAllAsync()
    {
        return await context.Evaluations.ToListAsync();
    }

    public async Task<Evaluation> AddAsync(Evaluation entity)
    {
        context.Evaluations.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Evaluation?> FindByIdAsync(int id)
    {
        return await context.Evaluations.FindAsync(id);
    }

    public async Task<Evaluation> UpdateAsync(Evaluation entity)
    {
        var dbEntity = await FindByIdAsync(entity.Id);

        if (dbEntity is null)
            return null;
        
        dbEntity.ImprovementText = entity.ImprovementText;
        dbEntity.PositiveText = entity.PositiveText;
        context.Evaluations.Update(dbEntity);
        await context.SaveChangesAsync();
        return dbEntity;
    }

    public async Task DeleteAsync(Evaluation entity)
    {
        var dbEntity = await FindByIdAsync(entity.Id);

        if (dbEntity is null)
            return;

        context.Evaluations.Remove(dbEntity);
        await context.SaveChangesAsync();
    }

    public async Task<List<Evaluation>> FindByLectureAsync(int lectureId)
    {
        return await context.Evaluations.Where(x => x.LectureId == lectureId).ToListAsync();
    }
}