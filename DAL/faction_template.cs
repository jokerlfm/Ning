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
    
    public partial class faction_template
    {
        public long ID { get; set; }
        public int Faction { get; set; }
        public int Flags { get; set; }
        public int Enemies1 { get; set; }
        public int Enemies2 { get; set; }
        public int Enemies3 { get; set; }
        public int Enemies4 { get; set; }
        public int Friends1 { get; set; }
        public int Friends2 { get; set; }
        public int Friends3 { get; set; }
        public int Friends4 { get; set; }
        public byte Mask { get; set; }
        public byte FriendMask { get; set; }
        public byte EnemyMask { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
