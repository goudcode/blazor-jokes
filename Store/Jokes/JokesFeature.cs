using System.Collections.Generic;
using System.Collections.ObjectModel;
using Fluxor;

namespace JokesApp.Store.Jokes
{
    public class JokesFeature : Feature<JokesState>
    {
        public override string GetName()
            => "JokesStore";

        protected override JokesState GetInitialState()
            => new JokesState(false, "", new ReadOnlyCollection<string>(new List<string>()));
    }
}