
namespace CargoApi.Domain.Enums
{
    public class GeneralEnums
    {

        // PriorityType.cs
        public enum PriorityType
        {
            Alta,
            Media,
            Baja
        }


        // StatusService Agriment
        public enum StatusService
        {
            Activo,
            Suspendido,
            Terminado
        }

        // ServiceType.cs
        public enum ServiceType
        {
            CargaCompleta,
            CargaCompartida,
            AlquilerVehiculo
        }

        // RentalStatus.cs
        public enum RentalStatus
        {
            Reservado,
            Activo,
            Completado,
            Cancelado
        }

        // AgreementType.cs
        public enum AgreementType
        {
            ServicioLogistica,
            AlquilerFlota,
            TransporteDedicado
        }

        // SharingStatus.cs   
        public enum SharingStatus
        {
            Formando,
            Confirmado,
            EnRuta,
            Completado
        }

        // RatingType.cs
        public enum RatingType
        {
            Driver,
            Client,
            Service
        }

        // FeedbackType.cs
        public enum FeedbackType
        {
            Sugerencia,
            Queja,
            Alabanza
        }

        public enum StatusFeed
        {
            Terminado,
            Resuelto,
            SinResolver
        }

        // ConversationType.cs
        public enum ConversationType
        {
            Fallido,
            Completado,
            sinCerrar
        }

        

    }
}
