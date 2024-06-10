using FileHelpers;

namespace API.Minimal.Utilities.ModelHelpers
{
    [DelimitedRecord("|")]
    public class ColimaCodesModel
    {
        public string CodigoPostal { get; set; }
        public string Asenta { get; set; }
        public string TipoAsenta { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostalDescripcion { get; set; }
        public string CodigoEstado { get; set; }
        public string CodigoOficina { get; set; }
        public string TipoAsentaCodigo { get; set; }
        public string CodigoMunicipio { get; set; }
        public string AsentaCodigoPostalConstId { get; set; }
        public string Zona { get; set; }
        public string? CiudadClave { get; set; }
        public string? CodigoCP { get; set; }
    }
}
