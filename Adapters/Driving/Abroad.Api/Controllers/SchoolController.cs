using Abroad.Domain.Entities;
using Abroad.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Abroad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRepository<School, SchoolId> _repository;

        private readonly IUnityOfWork _unityOfWork;

        public SchoolController(IRepository<School, SchoolId> repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<School>> Post(string name)
        {
            School school = new(Guid.NewGuid(), name);

            if (school.Id.Equals(Guid.Empty))
                return Problem();

            var hashcode = school.Id.GetHashCode();

            school.AddCourse("Course " + hashcode);

            var result = await _repository.Add(school);

            await _unityOfWork.Commit();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _repository.GetAll();

            var x = result.ToList();

            return Ok(result);
        }
    }
}