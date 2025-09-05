

namespace CargoApi.Domain.Enums
{
    public class TransaccionEnums
    {
        // Domain/Enums/TransaccionEnums.cs
        public enum TypeServices { TransportePaquete, RentaVehiculos }

        public enum StatusTransaccion { NoPagado, Pagado, Cancelado, Fallido }
    }
}
