
namespace CargoApi.Domain.Enums
{
    public class DocumentEnums
    {
        // Domain/Enums/DocumentEnums.cs
        public enum DocumentTypeVehicle
        {
            RUAT, TituloPropiedad, CartaAlguiler, SOAT, ITV, PolizaSeguro,
            Fotografias, Otro
        }

        public enum DocumentTypeCompany
        {
            CertificadoOperadorTransportePublico, PoderLegal,SEPREC, PoderGeneral, Ci, FacturaSB,
            Documentacion,DocFinanciera, DeclaracionJurada, ExtractoBancario, DeclaracionJurImp,
            MatriculaComercio, NIT, ExtratoBancario
        }

        public enum DocumentTypeDriver
        {
            CI, LicenciaConducir, CurriculumVitae, Formulario, FotografiaPerfil, Otro
        }

        public enum MimeType { pdf, word, excel,txt, jpg, png, otro }

    }


   
}
