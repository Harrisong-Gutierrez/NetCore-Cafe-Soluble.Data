using Dapper;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using NetCore_Cafe_Soluble.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_Cafe_Soluble.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public ProductoRepository(MySQLConfiguration ConnectionString)
        {
            _connectionString = ConnectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async  Task<bool> DeleteProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @"DELETE FROM cafesoluble WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = producto.Id });


            return result > 0;
        }

        public async Task<IEnumerable<Producto>> GetAllProductos()
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, contenido, peso, color, cantidad, descripcion
                FROM cafesoluble";

            return await db.QueryAsync<Producto>(sql, new { });
        }

        public  async Task<Producto> GetDetails(int id)
        {
            var db = dbConnection();

            var sql = @" SELECT id, nombre, contenido, peso, color, cantidad, descripcion
                FROM cafesoluble
                WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Producto>(sql, new { Id = id });
        }

        public async Task<bool> InsertProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @" INSERT INTO cafesoluble(nombre, contenido, peso, color, cantidad, descripcion)
                VALUES(@Nombre, @Contenido, @Peso, @Color, @Cantidad, @Descripcion)";
               

            var result = await db.ExecuteAsync(sql, new 
            { producto.Nombre, producto.Contenido, producto.Peso, producto.Color, producto.Cantidad, producto.Descripcion });

            return result > 0;
        }

        public async Task<bool> UpdateProducto(Producto producto)
        {
            var db = dbConnection();

            var sql = @" UPDATE cafesoluble
                        SET  nombre = @Nombre,
                             contenido = @Contenido,
                             peso = @Peso,
                             color = @Color,
                             cantidad = @Cantidad,
                             descripcion = @Descripcion
                             WHERE id =@Id";


            var result = await db.ExecuteAsync(sql, new
            { producto.Nombre, producto.Contenido, producto.Peso, producto.Color, producto.Cantidad, producto.Descripcion, producto.Id });

            return result > 0;
        }
    }
}
