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
    
    public partial class map
    {
        public long ID { get; set; }
        public string Directory { get; set; }
        public long Flags1 { get; set; }
        public long Flags2 { get; set; }
        public float MinimapIconScale { get; set; }
        public float CorpsePosX { get; set; }
        public float CorpsePosY { get; set; }
        public string MapName { get; set; }
        public string MapDescription0 { get; set; }
        public string MapDescription1 { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int AreaTableID { get; set; }
        public int LoadingScreenID { get; set; }
        public short CorpseMapID { get; set; }
        public int TimeOfDayOverride { get; set; }
        public short ParentMapID { get; set; }
        public short CosmeticParentMapID { get; set; }
        public int WindSettingsID { get; set; }
        public byte InstanceType { get; set; }
        public byte unk5 { get; set; }
        public byte ExpansionID { get; set; }
        public byte MaxPlayers { get; set; }
        public byte TimeOffset { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
