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
    
    public partial class mount_capability
    {
        public long RequiredSpell { get; set; }
        public long SpeedModSpell { get; set; }
        public int RequiredRidingSkill { get; set; }
        public int RequiredArea { get; set; }
        public short RequiredMap { get; set; }
        public byte Flags { get; set; }
        public long ID { get; set; }
        public long RequiredAura { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
