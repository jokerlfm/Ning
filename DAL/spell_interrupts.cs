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
    
    public partial class spell_interrupts
    {
        public long ID { get; set; }
        public long SpellID { get; set; }
        public long AuraInterruptFlags1 { get; set; }
        public long AuraInterruptFlags2 { get; set; }
        public long ChannelInterruptFlags1 { get; set; }
        public long ChannelInterruptFlags2 { get; set; }
        public int InterruptFlags { get; set; }
        public byte DifficultyID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
