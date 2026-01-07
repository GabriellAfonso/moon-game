using System;
using System.Collections.Generic;

public class MatchmakingClient : BaseClient
{
    private readonly Dictionary<string, Action<string>> handlers;

    public MatchmakingClient(string baseUrl)
        : base(baseUrl)
    {
        handlers = new Dictionary<string, Action<string>>
        {
            { "match_found", HandleStartMatch }
            // adicione outros tipos aqui
        };
    }

    protected override void Handle(string type, string payload)
    {
        if (handlers.TryGetValue(type, out var handler))
        {
            handler(payload);
        }
        else
        {
            Console.WriteLine($"No handler for type: {type}");
        }
    }

    private void HandleStartMatch(string payload)
    {
        // starta a cena de versus
        //manda conectar o matchClient ao matchcConsumer
    }
}
