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
    
    public partial class spell_item_enchantment
    {
        public long ID { get; set; }
        public long EffectSpellID1 { get; set; }
        public long EffectSpellID2 { get; set; }
        public long EffectSpellID3 { get; set; }
        public string Name { get; set; }
        public float EffectScalingPoints1 { get; set; }
        public float EffectScalingPoints2 { get; set; }
        public float EffectScalingPoints3 { get; set; }
        public long TransmogCost { get; set; }
        public long TextureFileDataID { get; set; }
        public int EffectPointsMin1 { get; set; }
        public int EffectPointsMin2 { get; set; }
        public int EffectPointsMin3 { get; set; }
        public int ItemVisual { get; set; }
        public int Flags { get; set; }
        public int RequiredSkillID { get; set; }
        public int RequiredSkillRank { get; set; }
        public int ItemLevel { get; set; }
        public byte Charges { get; set; }
        public byte Effect1 { get; set; }
        public byte Effect2 { get; set; }
        public byte Effect3 { get; set; }
        public byte ConditionID { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }
        public sbyte ScalingClass { get; set; }
        public sbyte ScalingClassRestricted { get; set; }
        public long PlayerConditionID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
