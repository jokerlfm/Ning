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
    
    public partial class modifier_tree
    {
        public long ID { get; set; }
        public long Asset1 { get; set; }
        public long Asset2 { get; set; }
        public int Parent { get; set; }
        public byte Type { get; set; }
        public byte Unk700 { get; set; }
        public byte Operator { get; set; }
        public byte Amount { get; set; }
        public short VerifiedBuild { get; set; }
    }
}