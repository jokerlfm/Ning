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
    
    public partial class smart_scripts
    {
        public long entryorguid { get; set; }
        public byte source_type { get; set; }
        public int id { get; set; }
        public int link { get; set; }
        public byte event_type { get; set; }
        public byte event_phase_mask { get; set; }
        public byte event_chance { get; set; }
        public int event_flags { get; set; }
        public long event_param1 { get; set; }
        public long event_param2 { get; set; }
        public long event_param3 { get; set; }
        public long event_param4 { get; set; }
        public string event_param_string { get; set; }
        public byte action_type { get; set; }
        public long action_param1 { get; set; }
        public long action_param2 { get; set; }
        public long action_param3 { get; set; }
        public long action_param4 { get; set; }
        public long action_param5 { get; set; }
        public long action_param6 { get; set; }
        public byte target_type { get; set; }
        public long target_param1 { get; set; }
        public long target_param2 { get; set; }
        public long target_param3 { get; set; }
        public float target_x { get; set; }
        public float target_y { get; set; }
        public float target_z { get; set; }
        public float target_o { get; set; }
        public string comment { get; set; }
    }
}
