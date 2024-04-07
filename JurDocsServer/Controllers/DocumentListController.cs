using DbModel;
using JurDocs.Common.Loggers;
using JurDocs.Server.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace JurDocs.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentListController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public DocumentListController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        [SwaggerOperation("Получение всех файлов, доступных пользователю")]
        public ActionResult<DocumentListResponse[]> GetAllFiles()
        {

            List<DocumentListResponse> list = [];


            //foreach (var catalog in catalogs)
            //{
            //    var files = Directory.GetFiles(catalog.Path);
            //    foreach (var file in files)
            //        list.Add(new DocumentListResponse(catalog.Name, Path.GetFileName(file)));

            //}

            return Ok(list);
        }

        [HttpPost]
        [SwaggerOperation("Получение всех файлов вида docName, доступных пользователю")]
        public ActionResult<DocumentListResponse[]> Get([SwaggerParameter("Вид документа", Required = true)][FromBody] DocumentListRequest documentListRequest)
        {


            List<DocumentListResponse> list = [];

            //if (docNameInfo.Length == 1)
            //{
            //    var files = Directory.GetFiles(docNameInfo.First().Path);
            //    foreach (var file in files)
            //        list.Add(new DocumentListResponse(documentListRequest.DocName, Path.GetFileName(file)));
            //}

            return Ok(list);
        }

        public record DocumentListRequest([SwaggerParameter("Вид документа", Required = true)] string DocName, [SwaggerParameter("ID пользователя", Required = true)] int UserId);
        public record DocumentListResponse([SwaggerParameter("Вид документа", Required = true)] string DocName, [SwaggerParameter("Имя Файла", Required = true)] string FileName);
    }
}
