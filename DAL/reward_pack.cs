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
    
    public partial class reward_pack
    {
        public long ID { get; set; }
        public long Money { get; set; }
        public float ArtifactXPMultiplier { get; set; }
        public byte ArtifactXPDifficulty { get; set; }
        public byte ArtifactCategoryID { get; set; }
        public long TitleID { get; set; }
        public long Unused { get; set; }
        public short VerifiedBuild { get; set; }
    }
}