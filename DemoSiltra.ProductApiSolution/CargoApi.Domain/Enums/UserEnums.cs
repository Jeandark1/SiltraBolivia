

namespace CargoApi.Domain.Enums
{
    public class UserEnums
    {
        // Domain/Enums/UserEnums.cs
        public enum UserStatus 
        { Activo, Pendiente, Inactivo, Suspendido, Rechazado }
        public enum VerificationStatus 
        { Pendiente, Aprobado, Rechazado, RequiereInformación }
        public enum UserType
        { Indefinido, Cliente, Chofer, Empresa }
    }
}
