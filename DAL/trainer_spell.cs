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
    
    public partial class trainer_spell
    {
        public long TrainerId { get; set; }
        public long SpellId { get; set; }
        public long MoneyCost { get; set; }
        public long ReqSkillLine { get; set; }
        public long ReqSkillRank { get; set; }
        public long ReqAbility1 { get; set; }
        public long ReqAbility2 { get; set; }
        public long ReqAbility3 { get; set; }
        public byte ReqLevel { get; set; }
        public Nullable<short> VerifiedBuild { get; set; }
    }
}
