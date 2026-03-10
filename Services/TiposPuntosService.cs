using Jeremy_Sanchez_AP1_P2.DAL;
using Jeremy_Sanchez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P2.Services;

public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.Where(criterio).AsNoTracking().ToListAsync();
    }
}