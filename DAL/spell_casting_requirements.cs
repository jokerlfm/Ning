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
    
    public partial class spell_casting_requirements
    {
        public long ID { get; set; }
        public long SpellID { get; set; }
        public int MinFactionID { get; set; }
        public int RequiredAreasID { get; set; }
        public int RequiresSpellFocus { get; set; }
        public byte FacingCasterFlags { get; set; }
        public byte MinReputation { get; set; }
        public byte RequiredAuraVision { get; set; }
        public short VerifiedBuild { get; set; }
    }
}