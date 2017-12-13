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
    
    public partial class battlenet_accounts
    {
        public battlenet_accounts()
        {
            this.accounts = new HashSet<account>();
            this.battlenet_item_appearances = new HashSet<battlenet_item_appearances>();
            this.battlenet_item_favorite_appearances = new HashSet<battlenet_item_favorite_appearances>();
        }
    
        public long id { get; set; }
        public string email { get; set; }
        public string sha_pass_hash { get; set; }
        public System.DateTime joindate { get; set; }
        public string last_ip { get; set; }
        public long failed_logins { get; set; }
        public byte locked { get; set; }
        public string lock_country { get; set; }
        public System.DateTime last_login { get; set; }
        public byte online { get; set; }
        public byte locale { get; set; }
        public string os { get; set; }
        public long LastCharacterUndelete { get; set; }
        public string LoginTicket { get; set; }
        public Nullable<long> LoginTicketExpiry { get; set; }
    
        public virtual ICollection<account> accounts { get; set; }
        public virtual ICollection<battlenet_item_appearances> battlenet_item_appearances { get; set; }
        public virtual ICollection<battlenet_item_favorite_appearances> battlenet_item_favorite_appearances { get; set; }
    }
}
