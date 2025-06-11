using System.Net.Http.Json;
using cliente.Models;

namespace cliente.Services;

public class ProductosService
{
    private readonly HttpClient _httpClient;

    public ProductosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductoDTO>> ObtenerProductosAsync(string? busqueda = null)
    {
        try
        {
            var url = "/api/productos";
            if (!string.IsNullOrEmpty(busqueda))
            {
                url += $"?busqueda={Uri.EscapeDataString(busqueda)}";
            }

            var productos = await _httpClient.GetFromJsonAsync<List<ProductoDTO>>(url);
            return productos ?? new List<ProductoDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener productos: {ex.Message}");
            return new List<ProductoDTO>();
        }
    }
}
