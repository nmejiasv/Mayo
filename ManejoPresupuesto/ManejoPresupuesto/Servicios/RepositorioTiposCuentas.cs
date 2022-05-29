using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicios
{

    public interface IRepositorioTiposCuentas
    {
        Task Actualizar(TipoCuenta tipoCuenta);
        Task Borrar(int id);
        Task Crear(TipoCuenta tipoCuenta);
        Task<bool> Existe(string nombre, int usuarioId);
        Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId);
        Task<TipoCuenta> ObtenerPorId(int id, int usuarioId);
        Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados);
    }

    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;
        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(TipoCuenta tipoCuenta)
        {
            using var connection = new SqlConnection(connectionString);
            //var id = await connection.QuerySingleAsync<int>($@"INSERT INTO TiposCuentas (Nombre, UsuarioId, Orden)
            //                                        Values  (@Nombre, @UsuarioId, 0);
            //                                        SELECT SCOPE_IDENTITY();", tipoCuenta);

            var id = await connection.QuerySingleAsync<int>
                                                ("TiposCuentas_Insertar",
                                                new
                                                {
                                                    usuarioId = tipoCuenta.UsuarioId,
                                                    nombre = tipoCuenta.Nombre
                                                },
                                                commandType: System.Data.CommandType.StoredProcedure);

            tipoCuenta.Id = id;
        }

        public async Task<bool> Existe (string nombre, int usuarioId) 
        { 
            using var connection= new SqlConnection(connectionString);
            var existe = await connection.QuerySingleOrDefaultAsync<int>(
                @"select 1
                FROM TiposCuentas
                WHERE Nombre = @Nombre and UsuarioId=@UsuarioId;",
                new { nombre, usuarioId });
            return existe == 1;
        }

        public async Task<IEnumerable<TipoCuenta>> Obtener(int usuarioId)
        {
            using var conecction = new SqlConnection(connectionString);
            return await conecction.QueryAsync<TipoCuenta>(@"select id, nombre, orden
                                                            from TiposCuentas
                                                            where UsuarioId = @UsuarioId
                                                            order by orden",
                                                            new { usuarioId });
        }

        public async Task Actualizar(TipoCuenta tipoCuenta)
        {
            using var conecction = new SqlConnection(connectionString);
            await conecction.ExecuteAsync(@"UPDATE TiposCuentas
                                            SET Nombre=@Nombre       
                                            where Id = @Id", tipoCuenta);
        }
         
        public async Task<TipoCuenta> ObtenerPorId(int id, int usuarioId)
        {
            using var conecction = new SqlConnection(connectionString);
            return await conecction.QueryFirstOrDefaultAsync<TipoCuenta>(@"SELECT Id, Nombre, Orden
                                               FROM TiposCuentas
                                               Where Id = @Id AND UsuarioId = usuarioId",
                                               new { id, usuarioId });
        }

        public async Task Borrar(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("DELETE TiposCuentas WHERE Id = @Id", new { id });
        }

        public async Task Ordenar(IEnumerable<TipoCuenta> tipoCuentasOrdenados)
        {
            var query = "UPDATE TiposCuentas SET Orden = @Orden Where Id = @Id;";
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, tipoCuentasOrdenados);
        }

    }
}
