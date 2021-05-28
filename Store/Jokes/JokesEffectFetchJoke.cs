using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Fluxor;
using JokesApp.Store.Jokes.Actions;

public class JokesEffects : Effect<FetchJoke>
{
    public class JokeResult
    {
        public string Id { get; set; }
        public string Joke { get; set; }
        public int Status { get; set; }
    }

    private readonly HttpClient client;

    public JokesEffects(HttpClient client)
    {
        this.client = client;
    }
    
    public override async Task HandleAsync(FetchJoke action, IDispatcher dispatcher)
    {
        var result = await client.GetFromJsonAsync<JokeResult>("https://icanhazdadjoke.com/");
        dispatcher.Dispatch(new SetLoading(){IsLoading = false});
        dispatcher.Dispatch(new AddJoke(){ Joke = result.Joke });
    }
}