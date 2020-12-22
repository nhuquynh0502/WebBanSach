//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBanSach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Order_Detail = new HashSet<Order_Detail>();
        }
    
        public int ID_Book { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> Release_Date { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Discription { get; set; }
        public Nullable<int> Age_Limit { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> ID_Genre { get; set; }
        public Nullable<int> ID_Publisher { get; set; }
        public Nullable<int> ID_Provider { get; set; }
    
        public virtual Genre Genre { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual Publisher Publisher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }
    }
}
