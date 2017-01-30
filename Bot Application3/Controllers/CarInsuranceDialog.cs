using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace Bot_Application3.Controllers
{
[Serializable]
public class CarInsuranceDialog : IDialog<object>
{
    protected string registrationNumber { get; set; }
    protected string startDate { get; set; }

    public async Task StartAsync(IDialogContext context)
    {
        context.Wait(MessageReceivedStartConversation); // State transition: wait for user to start conversation
    }

    public async Task MessageReceivedStartConversation(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        await context.PostAsync("What's your registration number?");
        context.Wait(MessageReceivedRegistrationNumber); // State transition: wait for user to provide registration number
    }

    public async Task MessageReceivedRegistrationNumber(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        this.registrationNumber = (await argument).Text;
        await context.PostAsync("When do you want cover to start?");
        context.Wait(MessageReceivedCoverStart); // State transition: wait for user to provide cover start date
    }

    public async Task MessageReceivedCoverStart(IDialogContext context, IAwaitable<IMessageActivity> argument)
    {
        this.startDate = (await argument).Text;
        // do your search/aggregation here
        await context.PostAsync($"OK, I found these deals for {registrationNumber} starting {startDate}...");
        context.Done<object>(new object()); // Signal completion
    }
}
}