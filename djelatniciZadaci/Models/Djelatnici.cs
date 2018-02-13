namespace djelatniciZadaci.Models
{
    using System.Collections.Generic;

    public partial class Djelatnici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Djelatnici()
        {
            this.RadniZadaci = new HashSet<RadniZadaci>();
        }

        public long Id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RadniZadaci> RadniZadaci { get; set; }
    }
}
