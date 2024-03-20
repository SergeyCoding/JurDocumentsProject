using JurDocsServer.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JurDocsServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentListController : ControllerBase
    {
        private readonly SecurityInfoReader _reader;

        public DocumentListController(SecurityInfoReader reader)
        {
            _reader = reader;
        }

        [HttpGet]
        [SwaggerOperation("Получение всех файлов, доступных пользователю")]
        public ActionResult<DocumentListResponse[]> GetAllFiles([SwaggerParameter("ID пользователя", Required = true)][FromQuery] int userId)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var catalogs = securityInfo!.Catalogs!.Where(x => x.Read.Contains(userId)).ToArray();

            List<DocumentListResponse> list = [];


            foreach (var catalog in catalogs)
            {
                var files = Directory.GetFiles(catalog.Path);
                foreach (var file in files)
                    list.Add(new DocumentListResponse(catalog.Name, Path.GetFileName(file)));

            }

            return Ok(list);
        }

        [HttpPost]
        [SwaggerOperation("Получение всех файлов вида docName, доступных пользователю")]
        public ActionResult<DocumentListResponse[]> Get([SwaggerParameter("Вид документа", Required = true)][FromBody] DocumentListRequest documentListRequest)
        {
            var securityInfo = _reader.GetSecurityInfo();

            var docNameInfo = securityInfo!.Catalogs!.Where(x => x.Name == documentListRequest.DocName && x.Read.Contains(documentListRequest.UserId)).ToArray();

            List<DocumentListResponse> list = [];

            if (docNameInfo.Length == 1)
            {
                var files = Directory.GetFiles(docNameInfo.First().Path);
                foreach (var file in files)
                    list.Add(new DocumentListResponse(documentListRequest.DocName, Path.GetFileName(file)));
            }

            return Ok(list);
        }

        public record DocumentListRequest([SwaggerParameter("Вид документа", Required = true)] string DocName, [SwaggerParameter("ID пользователя", Required = true)] int UserId);
        public record DocumentListResponse([SwaggerParameter("Вид документа", Required = true)] string DocName, [SwaggerParameter("Имя Файла", Required = true)] string FileName);
    }
}
