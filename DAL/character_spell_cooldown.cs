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
    
    public partial class character_spell_cooldown
    {
        public decimal guid { get; set; }
        public long spell { get; set; }
        public long item { get; set; }
        public long time { get; set; }
        public long categoryId { get; set; }
        public long categoryEnd { get; set; }
    }
}