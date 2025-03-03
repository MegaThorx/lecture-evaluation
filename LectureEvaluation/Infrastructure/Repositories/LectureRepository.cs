using LectureEvaluation.Domain.Models;
using LectureEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LectureEvaluation.Infrastructure.Repositories;

public class LectureRepository(MySqlDbContext context) : ILectureRepository
{
    public async Task<List<Lecture>> FindAllAsync()
    {
        return await context.Lectures.ToListAsync();
    }

    public async Task<Lecture> AddAsync(Lecture entity)
    {
        context.Lectures.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<Lecture?> FindByIdAsync(int id)
    {
        return await context.Lectures.FindAsync(id);
    }

    public async Task<Lecture> UpdateAsync(Lecture entity)
    {
        var dbEntity = await FindByIdAsync(entity.Id);

        if (dbEntity is null)
            return null;
        
        dbEntity.Title = entity.Title;
        dbEntity.LectureName = entity.LectureName;
        dbEntity.ExternalId = entity.ExternalId;
        context.Lectures.Update(dbEntity);
        await context.SaveChangesAsync();
        return dbEntity;
    }

    public async Task DeleteAsync(Lecture entity)
    {
        var dbEntity = await FindByIdAsync(entity.Id);

        if (dbEntity is null)
            return;

        context.Lectures.Remove(dbEntity);
        await context.SaveChangesAsync();
    }
}