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
    
    public partial class mail
    {
        public long id { get; set; }
        public byte messageType { get; set; }
        public sbyte stationery { get; set; }
        public int mailTemplateId { get; set; }
        public decimal sender { get; set; }
        public decimal receiver { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public byte has_items { get; set; }
        public long expire_time { get; set; }
        public long deliver_time { get; set; }
        public decimal money { get; set; }
        public decimal cod { get; set; }
        public byte @checked { get; set; }
    }
}