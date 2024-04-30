using Microsoft.AspNetCore.Mvc;

namespace modul9_1302223154.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : Controller
    {
        public class Mahasiswa
        {
            public String Nama { get; set; }
            public String Nim { get; set; }
            public List<String> Course { get; set; }
            public int Year { get; set; }
        }

        

        private static Mahasiswa[] mahasiswa = new Mahasiswa[]
        {
                new Mahasiswa{Nama = "Darryl Rambi",Nim = "1302223154", Course = new List<string>() {"KPL", "PBO", "BD"}, Year = 2022 },
                new Mahasiswa{Nama = "Dafa Raimi",Nim = "1302223156", Course = new List<string>() {"KPL", "PBO", "BD"}, Year = 2022 },
                new Mahasiswa{Nama = "Haikal Risnandar",Nim = "1302221050", Course = new List<string>() {"KPL", "PBO", "BD"}, Year = 2022 },
        };

        [HttpGet]
        public IEnumerable<Mahasiswa> GetMahasiswa()
        {
            return mahasiswa;
        }

        [HttpGet("id")]
        public Mahasiswa Get(int id)
        {
            return mahasiswa[id];
        }

        [HttpPost]
        public IActionResult Post([FromBody] Mahasiswa input)
        {
            Mahasiswa newMahasiswa = new Mahasiswa
            {
                Nama = input.Nama,
                Nim = input.Nim,
                Course = input.Course,
                Year = input.Year
            };
            Mahasiswa[] newMahasiswas = new Mahasiswa[mahasiswa.Length + 1];

            for (int i = 0; i < mahasiswa.Length; i++)
            {
                newMahasiswas[i] = mahasiswa[i];
            }
            newMahasiswas[mahasiswa.Length] = newMahasiswa;
            mahasiswa = newMahasiswas;

            return CreatedAtAction(nameof(GetMahasiswa), newMahasiswa);
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= mahasiswa.Length)
            {
                return NotFound("Invalid");
            }

            for (int i = id; i < mahasiswa.Length - 1; i++)
            {
                mahasiswa[i] = mahasiswa[i + 1];
            }
            Array.Resize(ref mahasiswa, mahasiswa.Length - 1);

            return NoContent();
        }
    }
}
