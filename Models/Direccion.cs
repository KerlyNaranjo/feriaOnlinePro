//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginArtesanos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            this.FormaEntrega = new HashSet<FormaEntrega>();
            this.Pedidos = new HashSet<Pedidos>();
        }
    
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Barrio { get; set; }
        public string CallePrincipal { get; set; }
        public string CalleSecundaria { get; set; }
        public string NumeroCasa { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormaEntrega> FormaEntrega { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}