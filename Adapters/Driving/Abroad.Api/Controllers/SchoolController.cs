using Abroad.Domain.Entities;
using Abroad.Domain.Extensions;
using Abroad.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Abroad.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IRepository<School, SchoolId> _repository;

        public SchoolController(IRepository<School, SchoolId> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public ActionResult<School> Post(string name)
        {
            School school = new(Guid.NewGuid(), name);

            if (school.Id.Equals(Guid.Empty))
                return Problem();

            var hashcode = school.Id.GetHashCode();

            school.AddCourse("Course " + hashcode);

            school.Id.MustBe();
            school.Id.MustNotBeNull();

            var result = _repository.Add(school);

            return Ok(result);
        }
    }
}