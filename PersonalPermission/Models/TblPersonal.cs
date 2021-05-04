namespace PersonalPermission.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblPersonal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
        public Nullable<int> PermissionId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual TblPermission TblPermission { get; set; }
    }
}
