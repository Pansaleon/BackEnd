namespace PedidosWebAPI.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }

        public string CompradorId { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
