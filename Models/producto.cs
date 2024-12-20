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
    
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            this.productos_carritos = new HashSet<productos_carritos>();
            this.productos_ventas = new HashSet<productos_ventas>();
        }
    
        public int id_producto { get; set; }
        public string nombre_producto { get; set; }
        public string caracteristicas_producto { get; set; }
        public Nullable<long> stock { get; set; }
        public string descripcion { get; set; }
        [JsonIgnore]
        public Nullable<int> id_precio { get; set; }
        [JsonIgnore]
        public Nullable<int> id_categoria { get; set; }
        [JsonIgnore]
        public Nullable<int> id_proveedor { get; set; }
        [JsonIgnore]
        public virtual categoria categoria { get; set; }
        [JsonIgnore]
        public virtual precio precio { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<productos_carritos> productos_carritos { get; set; }
        [JsonIgnore]
        public virtual proveedore proveedore { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        
        public virtual ICollection<productos_ventas> productos_ventas { get; set; }
    }
}
