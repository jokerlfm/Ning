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
    
    public partial class dungeon_encounter
    {
        public string Name { get; set; }
        public long CreatureDisplayID { get; set; }
        public int MapID { get; set; }
        public byte DifficultyID { get; set; }
        public byte Bit { get; set; }
        public byte Flags { get; set; }
        public long ID { get; set; }
        public int OrderIndex { get; set; }
        public long TextureFileDataID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
