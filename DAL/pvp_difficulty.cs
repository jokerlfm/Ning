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
    
    public partial class pvp_difficulty
    {
        public long ID { get; set; }
        public int MapID { get; set; }
        public byte BracketID { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
