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
    
    public partial class chat_channels
    {
        public long ID { get; set; }
        public long Flags { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public byte FactionGroup { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
