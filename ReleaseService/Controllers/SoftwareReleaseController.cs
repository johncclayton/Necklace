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
        public IEnumerable<SoftwareRelease> Get()
        {
            throw new NotImplementedException();
        }

        // GET: api/SoftwareRelease/5
        [HttpGet("{id}")]
        public SoftwareRelease Get(Guid id)
        {
            return _repo.GetSoftwareRelease(id);
        }

        // POST: api/SoftwareRelease
        [HttpPost]
        public void Post([FromBody] SoftwareRelease value)
        {
            _repo.UpdateSoftwareRelease(value);
        }

        // PUT: api/SoftwareRelease/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] SoftwareRelease value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/SoftwareRelease/5
        [HttpDelete("{id}")]
        public void Delete(SoftwareRelease id)
        {
            throw new NotImplementedException();
        }
    }
}
