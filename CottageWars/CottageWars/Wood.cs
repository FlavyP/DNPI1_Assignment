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
    
    public partial class Wood
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Wood()
        {
            this.PPH = 1;
            this.cost = 5;
            this.level = 0;
        }
    
        public int Id { get; set; }
        public short PPH { get; set; }
        public short cost { get; set; }
        public short level { get; set; }
    
        public virtual Buildings Building { get; set; }
    }
}
