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
    
    public partial class criteria_tree
    {
        public long ID { get; set; }
        public long Amount { get; set; }
        public string Description { get; set; }
        public int Parent { get; set; }
        public int Flags { get; set; }
        public byte Operator { get; set; }
        public long CriteriaID { get; set; }
        public int OrderIndex { get; set; }
        public short VerifiedBuild { get; set; }
    }
}