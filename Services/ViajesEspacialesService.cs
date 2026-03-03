using Jeremy_Sanchez_AP1_P2.Models;
using Jeremy_Sanchez_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jeremy_Sanchez_AP1_P2.Services;

public class ViajesEspacialesService(IDbContextFactory<Contexto> DbFactory)
{
    /*public async Task<bool> Guardar(ViajesEspaciales entradaHuacal)
    {
        
    }

    public async Task<bool> Existe(int EntradaId)
    {
        
    }
    public async Task<bool> Insertar(ViajesEspaciales entradaHuacal)
    {
        
    }
    public async Task<bool> Modificar(ViajesEspaciales entradaHuacal)
    {
        
    }
    private async Task AfectarTiposHuacales(Contexto contexto, DetallesEntradas[] detalles, TipoOperacion tipoOperacion)
    {
        
    }
    public async Task<ViajesEspaciales?> Buscar(int ViajeId)
    {
    }
    public async Task<bool> Eliminar(int ViajeId)
    {
        
    }*/
    public async Task<List<ViajesEspaciales>> Listar(Expression<Func<ViajesEspaciales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.ViajesEspaciales.Where(criterio).AsNoTracking().ToListAsync();
    }
}
public enum TipoOperacion
{
    Suma = 1,
    Resta = 2
}