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
    
    public partial class wmo_area_table
    {
        public int WMOGroupID { get; set; }
        public string AreaName { get; set; }
        public short WMOID { get; set; }
        public int AmbienceID { get; set; }
        public int ZoneMusic { get; set; }
        public int IntroSound { get; set; }
        public int AreaTableID { get; set; }
        public int UWIntroSound { get; set; }
        public int UWAmbience { get; set; }
        public sbyte NameSet { get; set; }
        public byte SoundProviderPref { get; set; }
        public byte SoundProviderPrefUnderwater { get; set; }
        public byte Flags { get; set; }
        public long ID { get; set; }
        public long UWZoneMusic { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
