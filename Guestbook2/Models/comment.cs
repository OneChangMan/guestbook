//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Guestbook2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public Nullable<int> continent { get; set; }
        public string message { get; set; }
        public byte[] date { get; set; }
        public Nullable<System.DateTime> edited { get; set; }
        public bool deleted { get; set; }
    }
}
