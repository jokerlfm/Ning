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
    
    public partial class broadcast_text_locale
    {
        public long ID { get; set; }
        public string locale { get; set; }
        public string MaleText_lang { get; set; }
        public string FemaleText_lang { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
