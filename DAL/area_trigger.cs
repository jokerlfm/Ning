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
    
    public partial class area_trigger
    {
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Radius { get; set; }
        public float BoxLength { get; set; }
        public float BoxWidth { get; set; }
        public float BoxHeight { get; set; }
        public float BoxYaw { get; set; }
        public int MapID { get; set; }
        public int PhaseID { get; set; }
        public int PhaseGroupID { get; set; }
        public int ShapeID { get; set; }
        public int AreaTriggerActionSetID { get; set; }
        public byte PhaseUseFlags { get; set; }
        public byte ShapeType { get; set; }
        public byte Flag { get; set; }
        public long ID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}