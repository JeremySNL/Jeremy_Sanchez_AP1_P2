using Jeremy_Sanchez_AP1_P2.DAL;
using Jeremy_Sanchez_AP1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P2.Services;

public class AsignacionesPuntosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(AsignacionesPuntos asignacion)
    {
        if (!await Existe(asignacion.AsignacionId))
        {
            return await Insertar(asignacion);
        }
        else
        {
            return await Modificar(asignacion);
        }
    }

    public async Task<bool> Existe(int asignacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos.AnyAsync(a => a.AsignacionId == asignacionId);
    }
    public async Task<bool> Insertar(AsignacionesPuntos asignacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.AsignacionesPuntos.Add(asignacion);
        await AfectarComponentes(contexto, asignacion.DetallesAsignaciones.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Modificar(AsignacionesPuntos asignacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        AsignacionesPuntos asignacionAntigua = await contexto.AsignacionesPuntos.Include(a => a.DetallesAsignaciones).FirstOrDefaultAsync(a => a.AsignacionId == asignacion.AsignacionId);
        if (asignacionAntigua == null) return false;

        await AfectarComponentes(contexto, asignacionAntigua.DetallesAsignaciones.ToArray(), TipoOperacion.Resta);

        asignacionAntigua.DetallesAsignaciones.Clear();
        foreach (var detalle in asignacion.DetallesAsignaciones)
        {
            asignacionAntigua.DetallesAsignaciones.Add(detalle);
        }

        await AfectarComponentes(contexto, asignacion.DetallesAsignaciones.ToArray(), TipoOperacion.Suma);

        asignacionAntigua.Fecha = asignacion.Fecha;
        asignacionAntigua.TotalPuntos = asignacion.TotalPuntos;
        asignacionAntigua.EstudianteId = asignacion.EstudianteId;

        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task AfectarComponentes(Contexto contexto, DetallesAsignaciones[] detalles, TipoOperacion tipoOperacion)
    {
        foreach (var detalle in detalles)
        {
            Estudiantes estudiante = await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudianteId == detalle.EstudianteId);
            if (estudiante != null)
            {
                if (tipoOperacion == TipoOperacion.Suma)
                {
                    estudiante.BalancePuntos += detalle.CantidadPuntos;
                }
                else if (tipoOperacion == TipoOperacion.Resta)
                {
                    estudiante.BalancePuntos -= detalle.CantidadPuntos;
                }
            }
        }
    }
    public async Task<AsignacionesPuntos?> Buscar(int asignacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos.Include(p => p.DetallesAsignaciones).FirstOrDefaultAsync(a => a.AsignacionId == asignacionId);
    }
    public async Task<bool> Eliminar(int asignacionId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        AsignacionesPuntos asignacion = await contexto.AsignacionesPuntos.Include(p => p.DetallesAsignaciones).FirstOrDefaultAsync(a => a.AsignacionId == asignacionId);
        if (asignacion == null) return false;

        await AfectarComponentes(contexto, asignacion.DetallesAsignaciones.ToArray(), TipoOperacion.Resta);

        contexto.AsignacionesPuntos.Remove(asignacion);

        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<List<AsignacionesPuntos>> Listar(Expression<Func<AsignacionesPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.AsignacionesPuntos.Where(criterio).AsNoTracking().ToListAsync();
    }
}
public enum TipoOperacion
{
    Suma = 1,
    Resta = 2
}