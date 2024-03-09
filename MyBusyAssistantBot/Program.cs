using MyBusyAssistantBot;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;


internal class Program
{
    private static void Main(string[] args)
    {
        var client = new TelegramBotClient(APIKeys.bot_token);
        client.StartReceiving(Update, Error);
        Console.ReadLine();

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message.Text != null)
            {
                Console.WriteLine($"{message.Chat.FirstName}    |    {message.Text}");
                if (message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Ну привет");
                    return;
                }
            }
        }

        Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}




//https://aka.ms/new-console-template