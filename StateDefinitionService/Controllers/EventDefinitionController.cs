using System.Web.Http;

namespace StateDefinitionService.Controllers
{
    [RoutePrefix("data")]
    public class EventDefinitionController : ApiController
    {
        [Route("saveeventdata")]
        [HttpGet]
        public string SaveEventData(string input)
        {
            string result = saveeventdata.Receiver.getStatusCode(input);

            saveeventdata.Answer.Map(result);
            saveeventdata.Answer.POST(result);
            return result;
        }
        
    }
}
