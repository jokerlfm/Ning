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
    
    public partial class group_member
    {
        public long guid { get; set; }
        public decimal memberGuid { get; set; }
        public byte memberFlags { get; set; }
        public byte subgroup { get; set; }
        public byte roles { get; set; }
    }
}