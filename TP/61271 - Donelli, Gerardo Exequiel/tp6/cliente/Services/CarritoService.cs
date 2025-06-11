using System.Net.Http.Json;
using cliente.Models;

namespace cliente.Services;

public class CarritoService
{
    private readonly HttpClient _httpClient;
    private List<ItemCarrito> _items = new();
    
    public event Action? OnChange;

    public CarritoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IReadOnlyList<ItemCarrito> ObtenerItems() => _items.AsReadOnly();

    public int ObtenerCantidadTotal() => _items.Sum(x => x.Cantidad);

    public decimal ObtenerTotal() => _items.Sum(x => x.Subtotal);

    public void AgregarItem(ProductoDTO producto, int cantidad = 1)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == producto.Id);
        
        if (item == null)
        {
            item = new ItemCarrito
            {
                ProductoId = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Cantidad = Math.Min(cantidad, producto.Stock)
            };
            _items.Add(item);
        }
        else
        {
            ActualizarCantidad(producto.Id, Math.Min(item.Cantidad + cantidad, producto.Stock));
        }

        NotificarCambios();
    }

    public void ActualizarCantidad(int productoId, int cantidad)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            if (cantidad <= 0)
            {
                _items.Remove(item);
            }
            else
            {
                item.Cantidad = cantidad;
            }
            NotificarCambios();
        }
    }

    public void EliminarItem(int productoId)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            _items.Remove(item);
            NotificarCambios();
        }
    }

    public void LimpiarCarrito()
    {
        _items.Clear();
        NotificarCambios();
    }

    public async Task<bool> ProcesarCompraAsync(string nombre, string apellido, string email)
    {
        if (!_items.Any()) return false;

        try
        {
            var orden = new OrdenCompraDTO
            {
                Items = _items.Select(x => new ItemOrdenDTO 
                { 
                    ProductoId = x.ProductoId,
                    Cantidad = x.Cantidad
                }).ToList()
            };

            var response = await _httpClient.PostAsJsonAsync("/api/compras", new
            {
                Items = orden.Items,
                NombreCliente = nombre,
                ApellidoCliente = apellido,
                EmailCliente = email
            });

            if (response.IsSuccessStatusCode)
            {
                LimpiarCarrito();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar la compra: {ex.Message}");
            return false;
        }
    }

    private void NotificarCambios() => OnChange?.Invoke();
}
