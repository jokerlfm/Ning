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
    
    public partial class difficulty
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int GroupSizeHealthCurveID { get; set; }
        public int GroupSizeDmgCurveID { get; set; }
        public int GroupSizeSpellPointsCurveID { get; set; }
        public byte FallbackDifficultyID { get; set; }
        public byte InstanceType { get; set; }
        public byte MinPlayers { get; set; }
        public byte MaxPlayers { get; set; }
        public sbyte OldEnumValue { get; set; }
        public byte Flags { get; set; }
        public byte ToggleDifficultyID { get; set; }
        public byte ItemBonusTreeModID { get; set; }
        public byte OrderIndex { get; set; }
        public short VerifiedBuild { get; set; }
    }
}