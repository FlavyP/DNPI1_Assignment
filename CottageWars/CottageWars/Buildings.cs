//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CottageWars
{
    using System;
    using System.Collections.Generic;
    
    public partial class Buildings
    {
        public int Id { get; set; }
        public short clayAmount { get; set; }
        public short woodAmount { get; set; }
        public short ironAmount { get; set; }
    
        public virtual User User { get; set; }
        public virtual Barracks Barrack { get; set; }
        public virtual Clay Clay { get; set; }
        public virtual Iron Iron { get; set; }
        public virtual Wood Wood { get; set; }
        public virtual Storage Storage { get; set; }
        public virtual Townhall Townhall { get; set; }
    }
}
