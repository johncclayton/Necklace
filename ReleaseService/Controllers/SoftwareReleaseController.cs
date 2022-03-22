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

        public SoftwareReleaseController(ISoftwareReleaseRepository repo)
        {
            _repo = repo;
        }
        
        // GET: api/SoftwareRelease
        [HttpGet]
        public IEnumerable<SoftwareRelease> GetAll()
        {
            throw new NotImplementedException();
        }

        // GET: api/SoftwareRelease/5
        [HttpGet("{id}")]
        public async Task<SoftwareRelease> Get(Guid id) => await _repo.GetSoftwareRelease(id);

        // POST: api/SoftwareRelease
        [HttpPost]
        public async Task<SoftwareRelease> Create([FromBody] SoftwareRelease value) =>
            await _repo.UpdateSoftwareRelease(value);

        // PUT: api/SoftwareRelease/5
        [HttpPut("{id}")]
        public async Task<SoftwareRelease> Update(Guid id, [FromBody] SoftwareRelease value) =>
            await _repo.UpdateSoftwareRelease(value with { Id = id });

        // DELETE: api/SoftwareRelease/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _repo.DeleteSoftwareRelease(id);
    }
}
