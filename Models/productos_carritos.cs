//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GESTOR_SERVICIO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos_Carritos
    {
        public int id_productos_carritos { get; set; }
        public Nullable<int> id_carrito { get; set; }
        public Nullable<int> id_producto { get; set; }
        public Nullable<int> cantidad_producto_carrito { get; set; }
    
        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
