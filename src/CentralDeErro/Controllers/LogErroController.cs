using Microsoft.AspNetCore.Mvc;

namespace CentralDeErro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogErroController : ControllerBase
    {
       // private readonly IMapper _mapper;
       // private readonly ILogErroRepository _logErroRepository;


       // //TODO Passar token via authorization
       // public LogErroController(
       //     ILogErroRepository logErroRepository,
       //     IMapper mapper
       //     )
       // {
       //     _mapper = mapper;
       //     _logErroRepository = logErroRepository;
       // }

       // [HttpGet]
       // public IActionResult Get()
       // {
       //     return Ok(new LogErro());
       // }

       // //get: api/logerro
       // //TODO adicionar query - apenas pelo token do usuário.
       //[HttpGet("all-logs")]
       // public ActionResult<IEnumerable<LogErroDto>> GetAllLog()
       // {
            
       //     var allLogs = _logErroRepository.GetAllLogs();
       //     return Ok(_mapper.Map<IEnumerable<LogErroDto>>(allLogs));
       // }

       //// GET: api/LogErro/5
       // [HttpGet("{id}", Name = "GetLogById")]
       // public ActionResult<LogErroDto> GetLogById(int id)
       // {
       //     var log = _logErroRepository.GetLogById(id);
       //     if (log != null)
       //     {
       //         return Ok(_mapper.Map<LogErroDto>(log));
       //     }
       //     return NotFound();
       // }

       // [HttpPost]
       // public ActionResult<LogErroDto> CreateLog([FromHeader] string Authorization,LogErroDto logErro)
       // {
       //     var logModel = _mapper.Map<LogErro>(logErro);
       //     logModel.UserToken = Authorization;

       //     _logErroRepository.CreateLog(logModel);
       //     _logErroRepository.SaveChanges();

       //     var outLogModel = _mapper.Map<LogErroDto>(logModel);

       //     return CreatedAtRoute(nameof(GetLogById), new { Id = outLogModel.Title }, outLogModel);
       // }

       // // TODO
       // [HttpPut("{id}")]
       // public ActionResult UpdateCommand(int id, LogErroDto logErro)
       // {
       //     var logErroById = _logErroRepository.GetLogById(id);

       //     if (logErroById == null)
       //     {
       //         return NotFound();
       //     }

       //     _mapper.Map(logErro, logErroById);

       //     _logErroRepository.UpdateLog(logErroById);
       //     _logErroRepository.SaveChanges();

       //     return NoContent();
       // }

       // //patch?

       // // DELETE: api/ApiWithActions/5
       // [HttpDelete("{id}")]
       // public ActionResult Delete(int id)
       // {
       //     var logErroById = _logErroRepository.GetLogById(id);
       //     if (logErroById == null)
       //     {
       //         return NotFound();
       //     }

       //     _logErroRepository.DeleteLog(logErroById);
       //     _logErroRepository.SaveChanges();

       //     return Ok("Deletado com sucesso.");
       // }
    }
}
