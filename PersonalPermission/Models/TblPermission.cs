namespace PersonalPermission.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPermission()
        {
            this.TblPersonals = new HashSet<TblPersonal>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPersonal> TblPersonals { get; set; }
    }
}
