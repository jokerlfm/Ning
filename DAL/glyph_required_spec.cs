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
    
    public partial class glyph_required_spec
    {
        public long ID { get; set; }
        public int GlyphPropertiesID { get; set; }
        public int ChrSpecializationID { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
