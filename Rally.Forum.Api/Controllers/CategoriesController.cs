using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rally.Forum.Api.DTO;
using Rally.Forum.Domain.Entity;
using Rally.Forum.Infra.Repository.Contracts;
using System.Net;

namespace Rally.Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        public CategoriesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listarTop10")]
        public async Task<ActionResult> GetCategoriesTop10([FromServices] IRepository<Category> _repo)
        {
            var list = await _repo.GetTop10();
            var mappedList = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            if (mappedList == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mappedList);
        }
        [HttpGet]
        [Route("listarTop25")]
        public async Task<ActionResult> GetCategoriesTop25([FromServices] IRepository<Category> _repo)
        {
            var list = await _repo.GetTop25();
            var mappedList = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            if (mappedList == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mappedList);
        }

        [HttpGet]
        [Route("listarTop50")]
        public async Task<ActionResult> GetCategoriesTop50([FromServices] IRepository<Category> _repo)
        {
            var list = await _repo.GetTop50();
            var mappedList = _mapper.Map<IEnumerable<CategoryDTO>>(list);
            if (mappedList == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mappedList);
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<ActionResult> Insert([FromServices] IRepository<Category> _repo, [FromBody] CategoryDTO categoryDTO)
        {
            var entity = _mapper.Map<Category>(categoryDTO);
            var insertResponse = await _repo.Insert(entity);
            if (insertResponse)
            {
                return Ok("Cadastrado");
            }
            return StatusCode(StatusCodes.Status500InternalServerError);

        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update([FromServices] IRepository<Category> _repo,
            [FromHeader] string Guid,
            [FromBody] CategoryDTO categoryDTO)
        {
            var exists = await _repo.Get(Guid);
            if(exists == null)
            {
                return BadRequest();
            }
            exists.Category_Name = categoryDTO.Category_Name;
            exists.Updated_At = DateTime.Now;
            var updated = await _repo.Update(exists);
            if (updated)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError);


        }
    }
}