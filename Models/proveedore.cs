//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GESTOR_SERVICIO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class proveedore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proveedore()
        {
            this.productos = new HashSet<producto>();
        }
    
        public int id_proveedor { get; set; }
        public string nombre_proveedor { get; set; }
        public string descripcion_proveedor { get; set; }
        public long telefono_proveedor { get; set; }
        public string correo_proveedor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto> productos { get; set; }
    }
}
