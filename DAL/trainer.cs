//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class trainer
    {
        public long Id { get; set; }
        public byte Type { get; set; }
        public string Greeting { get; set; }
        public Nullable<short> VerifiedBuild { get; set; }
    }
}