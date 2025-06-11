namespace cliente.Models;

public class ProductoDTO
{    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string ImagenUrl { get; set; } = "";
}

public class CompraDTO 
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public string NombreCliente { get; set; }
    public string ApellidoCliente { get; set; }
    public string EmailCliente { get; set; }
    public List<ItemCompraDTO> Items { get; set; } = new();
}

public class ItemCompraDTO
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public ProductoDTO Producto { get; set; }
}

public class ItemCarrito
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; } = "";
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }
    public decimal Subtotal => Precio * Cantidad;
}

public class OrdenCompraDTO
{
    public List<ItemOrdenDTO> Items { get; set; } = new();
}

public class ItemOrdenDTO
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}
