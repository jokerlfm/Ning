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
    
    public partial class transmog_set
    {
        public string Name { get; set; }
        public int BaseSetID { get; set; }
        public int UIOrder { get; set; }
        public byte ExpansionID { get; set; }
        public long ID { get; set; }
        public int Flags { get; set; }
        public int QuestID { get; set; }
        public int ClassMask { get; set; }
        public int ItemNameDescriptionID { get; set; }
        public long TransmogSetGroupID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}