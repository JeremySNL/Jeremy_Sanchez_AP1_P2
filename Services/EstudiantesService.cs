using Jeremy_Sanchez_AP1_P2.Models;
using Jeremy_Sanchez_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P2.Services;

public class EstudiantesService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<Estudiantes?> Buscar(int estudianteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == estudianteId);
    }
    public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
    }
}