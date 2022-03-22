using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseService.Repositories;

namespace ReleaseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareReleaseController : ControllerBase
    {
        private readonly ISoftwareReleaseRepository _repo;
        private SoftwareRelease newValue;

        public SoftwareReleaseController(ISoftwareReleaseRepository repo)
        {
            _repo = repo;
        }
        
        // GET: api/SoftwareRelease
        [HttpGet]
        public IEnumerable<SoftwareRelease> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/SoftwareRelease/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await _repo.GetSoftwareRelease(id));
        }

        // POST: api/SoftwareRelease
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SoftwareRelease value)
        {
            return StatusCode(StatusCodes.Status201Created,
                await _repo.UpdateSoftwareRelease(value));
        }

        // PUT: api/SoftwareRelease/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SoftwareRelease value)
        {
            newValue = value with { Id = id };
            return StatusCode(StatusCodes.Status201Created, 
                await _repo.UpdateSoftwareRelease(newValue));
        }

        // DELETE: api/SoftwareRelease/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repo.DeleteSoftwareRelease(id);
        }
    }
}
