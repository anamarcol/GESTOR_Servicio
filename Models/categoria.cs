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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Web.Helpers;

    public partial class categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categoria()
        {
            this.productos = new HashSet<producto>();
        }
    
        public int id_categoria { get; set; }
        public string nombre_categorias { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_estado { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }

        [JsonIgnore]
        public virtual estado estado { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        
        public virtual ICollection<producto> productos { get; set; }
    }
}
