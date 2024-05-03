using JurDocs.Common;
using JurDocs.Common.Loggers;
using JurDocs.DbModel;
using JurDocs.Server.Controllers.Base;
using JurDocs.Server.Model;
using JurDocs.Server.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace JurDocs.Server.Controllers1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LetterDocumentController : JurDocsControllerBase
    {
        private readonly JurDocsDbContext _dbContext;

        public LetterDocumentController(JurDocsDbContext dbContext, IConfiguration configuration, ILogger<LogFile> logger)
            : base(configuration, logger)
        {
            _dbContext = dbContext;
        }

        [SwaggerOperation("Получить список писем")]
        [HttpGet]
        [ProducesResponseType(typeof(DataResponse<LetterDocument[]>), 200)]
        [ProducesResponseType(typeof(DataResponse<LetterDocument[]>), 400)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await GetCurrentUser();

                var pIdList = await GetAvailableProjectIdList(user.Id);

                var letters = await _dbContext.Set<JurDocLetter>()
                                .AsNoTracking()
                                .Where(x => pIdList.Contains(x.ProjectId))
                                .ToArrayAsync();

                var letterDocuments = new List<LetterDocument>();

                foreach (var item in letters)
                    letterDocuments.Add(await ToLetterDocument(item));

                return Ok(new DataResponse<LetterDocument[]>([.. letterDocuments]));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return Ok(new DataResponse<LetterDocument[]>(StatusDataResponse.BAD, "Ошибка")
                {
                    Errors = [e.Message, e.ToString()]
                });
            }
        }

        [SwaggerOperation("Получить письма по Id проекта")]
        [HttpGet("{projectId}")]
        [ProducesResponseType(typeof(DataResponse<LetterDocument[]>), 200)]
        [ProducesResponseType(typeof(DataResponse<LetterDocument[]>), 400)]
        public async Task<IActionResult> Get(int projectId)
        {
            try
            {
                var user = await GetCurrentUser();

                var pIdList = (await GetAvailableProjectIdList(user.Id)).Where(x => x == projectId).ToArray();

                if (!pIdList.Any())
                    return Ok(new DataResponse<LetterDocument[]>(StatusDataResponse.BAD, "Недостаточно прав"));

                var letters = await _dbContext.Set<JurDocLetter>()
                                .AsNoTracking()
                                .Where(x => pIdList.Contains(x.ProjectId))
                                .ToArrayAsync();

                var letterDocuments = new List<LetterDocument>();

                foreach (var item in letters)
                    letterDocuments.Add(await ToLetterDocument(item));

                return Ok(new DataResponse<LetterDocument[]>([.. letterDocuments]));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return Ok(new DataResponse<LetterDocument[]>(StatusDataResponse.BAD, "Ошибка")
                {
                    Errors = [e.Message, e.ToString()]
                });
            }
        }


        [HttpPost]
        [SwaggerOperation("Создать письмо", "Создать письмо")]
        [ProducesResponseType(typeof(DataResponse<LetterDocument>), 200)]
        [ProducesResponseType(typeof(DataResponse<LetterDocument>), 400)]
        public async Task<IActionResult> Post(int projectId)
        {
            try
            {
                var user = await GetCurrentUser();

                var pIdList = await GetAvailableProjectIdList(user.Id);

                if (!pIdList.Contains(projectId))
                    return Ok(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Недостаточно прав для создания письма в текущем проекте"));

                var letter = new JurDocLetter { ProjectId = projectId };

                var newLetter = await _dbContext.AddAsync(letter);
                await _dbContext.SaveChangesAsync();

                return Ok(new DataResponse<LetterDocument>(await ToLetterDocument(letter)));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<LetterDocument>(StatusDataResponse.BAD, "Непредвиденная ошибка") { Errors = [e.ToString()] });
            }
        }

        [HttpPut]
        [SwaggerOperation("Изменить письмо", "Изменить письмо")]
        [ProducesResponseType(typeof(DataResponse<LetterDocument>), 200)]
        [ProducesResponseType(typeof(DataResponse<LetterDocument>), 400)]
        public async Task<IActionResult> Put([FromBody] LetterDocument letterDoc)
        {
            try
            {
                var docUser = await GetCurrentUser();
                var pIdList = await GetAvailableProjectIdList(docUser.Id);

                if (!pIdList.Contains(letterDoc.ProjectId))
                    return BadRequest(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Нет прав для изменения данного письма"));


                var oldLetter = await _dbContext.Set<JurDocLetter>().FirstAsync(x => x.Id == letterDoc.Id);

                oldLetter.Name = letterDoc.Name;
                oldLetter.ExecutivePerson = letterDoc.ExecutivePerson;
                oldLetter.NumberOutgoing = letterDoc.NumberOutgoing;
                oldLetter.NumberIncoming = letterDoc.NumberIncoming;
                oldLetter.DateOutgoing = letterDoc.DateOutgoing;
                oldLetter.DateIncoming = letterDoc.DateIncoming;

                await _dbContext.SaveChangesAsync();

                foreach (var item in letterDoc.Sender)
                {
                    _dbContext.Add(new JurDocLetterAttributes
                    {
                        JurDocLetterId = letterDoc.Id,
                        AttributeType = AppConstCommon.Sender,
                        AttributeValue = item
                    });
                }

                foreach (var item in letterDoc.Recipient)
                {
                    _dbContext.Add(new JurDocLetterAttributes
                    {
                        JurDocLetterId = letterDoc.Id,
                        AttributeType = AppConstCommon.Recipient,
                        AttributeValue = item
                    });
                }

                await _dbContext.SaveChangesAsync();


                return Ok(new DataResponse<LetterDocument>(letterDoc));
            }
            catch (DbUpdateException e)
            {
                _logger?.LogError(e, message: null);
                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD, "Ошибка при обновлении письма"));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD)
                {
                    Errors = [e.ToString()]
                });
            }
        }

        [HttpDelete]
        [SwaggerOperation("Удалить письмо", "Удалить письмо")]
        [ProducesResponseType(typeof(void), 200)]
        public async Task<IActionResult> Delete([FromBody] int letterId)
        {
            try
            {
                var docUser = await GetCurrentUser();
                var pIdList = await GetAvailableProjectIdList(docUser.Id);

                var letter = await _dbContext.Set<JurDocLetter>().FirstAsync(x => x.Id == letterId);

                if (!pIdList.Contains(letter.ProjectId))
                    return BadRequest(new DataResponse<JurDocLetter>(StatusDataResponse.BAD, "Нет прав для изменения данного письма"));

                _dbContext.Remove(letter);
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateException e)
            {
                _logger?.LogError(e, message: null);
                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD, "Ошибка при удалении письма"));
            }
            catch (Exception e)
            {
                _logger?.LogError(e, message: null);

                return BadRequest(new DataResponse<JurDocProject>(StatusDataResponse.BAD, "Ошибка при удалении письма")
                {
                    Errors = [e.Message, e.ToString()]
                });
            }
        }

        private async Task<LetterDocument> ToLetterDocument(JurDocLetter dbLetter)
        {
            var ld = new LetterDocument
            {
                Id = dbLetter.Id,
                Name = dbLetter.Name,
                DateIncoming = dbLetter.DateIncoming,
                DateOutgoing = dbLetter.DateOutgoing,
                DocType = Common.EnumTypes.JurDocType.Справка,
                ExecutivePerson = dbLetter.ExecutivePerson,
                IsDeleted = dbLetter.IsDeleted,
                NumberIncoming = dbLetter.NumberIncoming,
                NumberOutgoing = dbLetter.NumberOutgoing,
                ProjectId = dbLetter.ProjectId
            };

            var attr = await _dbContext.Set<JurDocLetterAttributes>().Where(x => x.JurDocLetterId == ld.Id).ToArrayAsync();

            foreach (var attrItem in attr)
            {
                if (attrItem.AttributeType == AppConstCommon.Sender)
                    ld.Sender.Add(attrItem.AttributeValue!);

                if (attrItem.AttributeType == AppConstCommon.Recipient)
                    ld.Recipient.Add(attrItem.AttributeValue!);
            }

            return ld;
        }

        private async Task<JurDocUser> GetCurrentUser()
        {
            var login = GetUserLogin();
            return await _dbContext.Set<JurDocUser>().FirstAsync(x => x.Login == login);
        }

        private async Task<int[]> GetAvailableProjectIdList(int userId)
        {
            var projectRights = await _dbContext.Set<ProjectRights>()
                .AsNoTracking()
                .Where(x => x.DocType == "Справка")
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .Distinct()
                .ToArrayAsync();

            var availableProjectList = await _dbContext.Set<JurDocProject>()
                .AsNoTracking()
                .Where(x => !x.IsDeleted)
                .Where(x => x.OwnerId == userId || projectRights.Contains(x.Id))
                .Select(x => x.Id)
                .Distinct()
                .ToArrayAsync();

            return availableProjectList;
        }

    }
}
