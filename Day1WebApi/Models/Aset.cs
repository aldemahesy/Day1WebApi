namespace Day1WebApi.Models
{
    public class Aset : BaseModel
    {
        public string Nama { get; set; } = string.Empty;
        public DateOnly TanggalPerolehan {  get; set; }
        public string Kategori { get; set; } = string.Empty;
        public int Nilai { get; set; }
    }
}
