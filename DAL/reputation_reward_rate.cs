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
    
    public partial class reputation_reward_rate
    {
        public int faction { get; set; }
        public float quest_rate { get; set; }
        public float quest_daily_rate { get; set; }
        public float quest_weekly_rate { get; set; }
        public float quest_monthly_rate { get; set; }
        public float quest_repeatable_rate { get; set; }
        public float creature_rate { get; set; }
        public float spell_rate { get; set; }
    }
}
