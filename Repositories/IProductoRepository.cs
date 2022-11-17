using NetCore_Cafe_Soluble.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore_Cafe_Soluble.Data.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllProductos();
        Task<Producto> GetDetails(int id);
        Task<bool> InsertProducto(Producto producto);
        Task<bool> UpdateProducto(Producto producto);
        Task<bool> DeleteProducto(Producto producto);
    }
}
