//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EticaretMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Picture
    {
        public int ID { get; set; }
        public bool IsDefault { get; set; }
        public string Path { get; set; }
        public Nullable<int> Product_ID { get; set; }
    
        public virtual Product Product { get; set; }
    }
}