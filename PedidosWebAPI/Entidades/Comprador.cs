namespace PedidosWebAPI.Entidades
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public List<Producto> Productos { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }

}
