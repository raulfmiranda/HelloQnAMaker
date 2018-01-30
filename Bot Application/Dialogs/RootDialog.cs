using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace Bot_Application.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            //int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            //await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            var message = activity.CreateReply();

            if(activity.Text.Equals("animationcard", StringComparison.InvariantCultureIgnoreCase))
            {
                var animationCard = new AnimationCard();
                animationCard.Title = "Título do Animation Card";
                animationCard.Subtitle = "Subtítulo do Animation Card";
                animationCard.Autostart = true;
                animationCard.Autoloop = false;
                animationCard.Media = new List<MediaUrl>
                {
                    new MediaUrl("https://78.media.tumblr.com/8b4fbc136beb037c31a2f95a0fb71b51/tumblr_otho3igenw1toamj8o1_400.gif")
                };
                message.Attachments.Add(animationCard.ToAttachment());
            }
            else if(activity.Text.Equals("herocard", StringComparison.InvariantCultureIgnoreCase))
            {
                var heroCard = new HeroCard();
                heroCard.Title = "Título";
                heroCard.Text = "Esse é o texto do meu HeroCard. Bla bla bla bla bla bla.";
                message.Attachments.Add(heroCard.ToAttachment());
            }

            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }
    }
}