using servidor.Models;
using Microsoft.EntityFrameworkCore;

namespace servidor.Data;

public static class DbInitializer
{
    public static void Initialize(TiendaContext context)
    {
        // Asegurarse que la base de datos está creada
        context.Database.EnsureCreated();

        // Si ya hay productos, no hacer nada
        if (context.Productos.Any())
        {
            return;
        }

        var productos = new Producto[]
        {
            new Producto
            {
                Nombre = "Smartphone Galaxy S23",
                Descripcion = "Samsung Galaxy S23 Ultra, 256GB, 12GB RAM, Cámara 200MP",
                Precio = 999.99M,
                Stock = 15,
                ImagenUrl = "https://images.samsung.com/is/image/samsung/p6pim/ar/2202/gallery/ar-galaxy-s22-ultra-s908-sm-s908ezwlaro-thumb-530964422"
            },
            new Producto
            {
                Nombre = "MacBook Pro 14",
                Descripcion = "MacBook Pro 14 M2 Pro, 16GB RAM, 512GB SSD",
                Precio = 1999.99M,
                Stock = 8,
                ImagenUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp14-spacegray-select-202301?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1671304673229"
            },
            new Producto
            {
                Nombre = "iPad Air",
                Descripcion = "iPad Air 5ta gen, 64GB, WiFi, Chip M1",
                Precio = 599.99M,
                Stock = 20,
                ImagenUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/ipad-air-select-wifi-blue-202203?wid=940&hei=1112&fmt=png-alpha&.v=1645065732688"
            },
            new Producto
            {
                Nombre = "AirPods Pro",
                Descripcion = "AirPods Pro 2da gen, Cancelación activa de ruido",
                Precio = 249.99M,
                Stock = 30,
                ImagenUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/MQD83?wid=1144&hei=1144&fmt=jpeg&qlt=90&.v=1660803972361"
            },
            new Producto
            {
                Nombre = "Monitor Gaming",
                Descripcion = "Monitor Gaming 27' 2K 165Hz IPS HDR",
                Precio = 399.99M,
                Stock = 12,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_893314-MLA52042061799_102022-F.jpg"
            },
            new Producto
            {
                Nombre = "Teclado Mecánico",
                Descripcion = "Teclado Mecánico RGB, Switches Blue, Layout ESP",
                Precio = 89.99M,
                Stock = 25,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_941244-MLA52783557258_122022-F.jpg"
            },
            new Producto
            {
                Nombre = "Mouse Gaming",
                Descripcion = "Mouse Gaming 16000 DPI, RGB, 6 botones programables",
                Precio = 49.99M,
                Stock = 40,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_792338-MLA45385615857_032021-F.jpg"
            },
            new Producto
            {
                Nombre = "Auriculares Gaming",
                Descripcion = "Auriculares Gaming 7.1, micrófono retráctil, RGB",
                Precio = 79.99M,
                Stock = 18,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_833619-MLA52222140195_102022-F.jpg"
            },
            new Producto
            {
                Nombre = "Webcam HD",
                Descripcion = "Webcam 1080p 60fps, micrófono dual, enfoque automático",
                Precio = 69.99M,
                Stock = 22,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_841787-MLA44208174733_112020-F.jpg"
            },
            new Producto
            {
                Nombre = "SSD 1TB",
                Descripcion = "SSD NVMe M.2 1TB, lectura 3500MB/s",
                Precio = 129.99M,
                Stock = 35,
                ImagenUrl = "https://http2.mlstatic.com/D_NQ_NP_2X_859399-MLA45629747769_042021-F.jpg"
            }
        };

        // Agregar productos a la base de datos
        context.Productos.AddRange(productos);
        context.SaveChanges();
    }
}
