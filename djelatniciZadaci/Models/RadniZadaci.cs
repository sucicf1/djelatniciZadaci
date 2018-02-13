namespace djelatniciZadaci.Models
{
    public partial class RadniZadaci
    {
        public long Id { get; set; }
        public string naslov { get; set; }
        public string opis { get; set; }
        public long djelatnikId { get; set; }
    
        public virtual Djelatnici Djelatnici { get; set; }
    }
}
