using Bot_Application3.Controllers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace dialogs_basic
{
[BotAuthentication]
public class MessagesController : ApiController
{
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
        {
            // Transition into the CarInsuranceDialog
            await Conversation.SendAsync(activity, () => new CarInsuranceDialog());
        }

        return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
    }
}
}