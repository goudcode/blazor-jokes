using System.Collections;
using System.Collections.ObjectModel;

namespace JokesApp.Store.Jokes
{
    public class JokesState
    {
        public string CurrentJoke { get; }
        public ReadOnlyCollection<string> PastJokes { get; }
        public bool IsLoading { get; }

        public JokesState(bool isLoading, string joke, ReadOnlyCollection<string> pastJokes)
        {
            IsLoading = isLoading;
            CurrentJoke = joke;
            PastJokes = pastJokes;
        }
    }
}