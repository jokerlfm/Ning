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
    
    public partial class logs_ip_actions
    {
        public long id { get; set; }
        public long account_id { get; set; }
        public decimal character_guid { get; set; }
        public byte type { get; set; }
        public string ip { get; set; }
        public string systemnote { get; set; }
        public long unixtime { get; set; }
        public System.DateTime time { get; set; }
        public string comment { get; set; }
    }
}
