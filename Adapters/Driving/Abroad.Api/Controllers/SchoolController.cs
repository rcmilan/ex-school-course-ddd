using Abroad.Domain.Entities;
using Abroad.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Abroad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRepository<School, Guid> _repository;

        private readonly IUnityOfWork _unityOfWork;

        public SchoolController(IRepository<School, Guid> repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<School>> Post(string name)
        {
            School school = new(Guid.NewGuid(), name);

            school.AddCourse("Course 123");
            school.AddCourse("Course 456");
            school.AddCourse("Course 789");

            await _repository.Add(school);
            await _unityOfWork.Commit();

            return Ok(school);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _repository.GetAll(includes: s => s.Courses);

            return Ok(result);
        }
    }
}