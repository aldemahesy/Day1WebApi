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

        [ProducesResponseType(typeof(List<Aset>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetSemuaAset([FromQuery]AsetQueryParam query)
        {
            var resultAsets = Assets.ToList();
            if(query.Nama != null)
            {
                resultAsets = resultAsets.Where(x => x.Nama.ToLower().Contains
                    (query.Nama.ToLower())).ToList();
            }
            if (query.Kategori != null)
            {
                resultAsets = resultAsets.Where(x => x.Kategori.ToLower().Contains
                    (query.Kategori.ToLower())).ToList();
            }
            if (query.Tahun>0)
            {
                resultAsets = resultAsets.Where(x => x.TanggalPerolehan.Year ==
                    query.Tahun).ToList();
            }
            return Ok(resultAsets);
        }

        [ProducesResponseType(typeof(Aset), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult GetAsetById(Guid id)
        {
            var aset = Assets.FirstOrDefault(a => a.Id == id);
            if (aset == null) return NotFound();
            return Ok(aset);
        }

        [ProducesResponseType(typeof(Aset), StatusCodes.Status200OK)]
        [HttpPost]
        public IActionResult CreateAset([FromBody] AsetDto asetParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value.Errors));
            }
            var aset = _mapper.Map<Aset>(asetParam);
            Assets.Add(aset);
            return Ok(aset);
        }

        [ProducesResponseType(typeof(Aset), StatusCodes.Status200OK)]
        [HttpPut("{id}")]
        public IActionResult UpdateAset(Guid id, [FromBody] AsetDto asetParam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value.Errors));
            }
            var aset = Assets.FirstOrDefault(x => x.Id == id);
            if (aset == null) return NotFound();
            aset.Kategori = asetParam.Kategori;
            aset.Nama = asetParam.Nama;
            aset.Nilai = asetParam.Nilai;
            aset.TanggalPerolehan = asetParam.TanggalPerolehan;

            return Ok(aset);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [HttpDelete("{id}")]
        public IActionResult DeleteAset(Guid id)
        {
            var aset = Assets.FirstOrDefault(x => x.Id == id);
            if (aset == null) return NotFound();
            Assets.Remove(aset);
            return Ok("Aset berhasil dihapus");
        }
    }
}

