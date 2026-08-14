using AutoMapper;
using Microsoft.AspNetCore.Http;


namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsetController : ControllerBase
    {
        private readonly IMapper _mapper;
        private static List<Aset> Assets = new List<Aset>()
        {
            new Aset
            {
                Nama = "Laptop DAC",
                Kategori = "Laptop",
                Nilai = 17_000_000,
                TanggalPerolehan = new DateOnly(2020,1,1)
            },
            new Aset
            {
                Nama = "Laptop Icherry",
                Kategori = "Laptop",
                Nilai = 15_000_000,
                TanggalPerolehan = new DateOnly(2019,12,1)
            },
            new Aset
            {
                Nama = "Mobil BYD",
                Kategori = "Kendaraan",
                Nilai = 300_000_000,
                TanggalPerolehan = new DateOnly(2026,1,1)
            }
        };

        public AsetController(
            IMapper mapper
            )
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSemuaAset()
        {
            return Ok(Assets);
        }

        [HttpGet("{id}")]
        public IActionResult GetAsetById(Guid id)
        {
            var aset = Assets.FirstOrDefault(a => a.Id == id);
            if (aset == null) return NotFound();
            return Ok(aset);
        }

        [HttpPost]
        public IActionResult CreateAset(AsetDto asetParam)
        {
            var aset = new Aset
            {
                Nama = asetParam.Nama,
                Kategori = asetParam.Kategori,
                Nilai = asetParam.Nilai,
                TanggalPerolehan = asetParam.TanggalPerolehan
            };
            Assets.Add(aset);
            return Ok(aset);
        }
    }
}




