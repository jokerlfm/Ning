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
    
    public partial class quest_greeting
    {
        public int ID { get; set; }
        public byte Type { get; set; }
        public int GreetEmoteType { get; set; }
        public long GreetEmoteDelay { get; set; }
        public string Greeting { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
