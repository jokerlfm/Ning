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
    
    public partial class achievement_dbc
    {
        public long ID { get; set; }
        public int requiredFaction { get; set; }
        public int mapID { get; set; }
        public long points { get; set; }
        public long flags { get; set; }
        public long count { get; set; }
        public long refAchievement { get; set; }
    }
}