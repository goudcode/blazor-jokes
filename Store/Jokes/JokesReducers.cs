using System.Collections.Generic;
using Fluxor;
using JokesApp.Store.Jokes.Actions;
using System;
using System.Linq;
using System.Collections.ObjectModel;

namespace JokesApp.Store.Jokes
{
    public class JokesReducers
    {
        [ReducerMethod]
        public static JokesState ReduceAddJokeAction(JokesState state, AddJoke action)
        {
            var pastJokes = new List<string>(state.PastJokes);
            if (!string.IsNullOrWhiteSpace(state.CurrentJoke))
            {
                pastJokes.Insert(0, state.CurrentJoke);
                pastJokes = pastJokes.Take(10).ToList();
            }

            var newState = new JokesState(state.IsLoading, action.Joke, new ReadOnlyCollection<string>(pastJokes));
            return newState;
        }

        [ReducerMethod]
        public static JokesState ReduceSetLoading(JokesState state, SetLoading action)
            => new JokesState(action.IsLoading, state.CurrentJoke, state.PastJokes);
    }   
}