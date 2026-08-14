using System.ComponentModel.DataAnnotations;

namespace Day1WebApi.Dto
{
    public class AsetDto
    {
        [Required]
        [MaxLength(20)]
        public string? Nama { get; set; }
        public DateOnly TanggalPerolehan { get; set; }
        public string? Kategori { get; set; }
        [Range(1, int.MaxValue)]
        public int Nilai { get; set; }

    }
}
