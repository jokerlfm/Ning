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
    
    public partial class spell_loot_template
    {
        public int Entry { get; set; }
        public int Item { get; set; }
        public int Reference { get; set; }
        public float Chance { get; set; }
        public bool QuestRequired { get; set; }
        public int LootMode { get; set; }
        public byte GroupId { get; set; }
        public byte MinCount { get; set; }
        public byte MaxCount { get; set; }
        public string Comment { get; set; }
    }
}
