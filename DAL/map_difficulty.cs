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
    
    public partial class map_difficulty
    {
        public long ID { get; set; }
        public string Message { get; set; }
        public int MapID { get; set; }
        public byte DifficultyID { get; set; }
        public byte RaidDurationType { get; set; }
        public byte MaxPlayers { get; set; }
        public byte LockID { get; set; }
        public byte Flags { get; set; }
        public byte ItemBonusTreeModID { get; set; }
        public long Context { get; set; }
        public short VerifiedBuild { get; set; }
    }
}