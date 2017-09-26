using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSADesignPattern
{
    class Observer
    {
        private Dictionary<string, List<IObservable>> listeners;

        public Observer()
        {
            listeners = new Dictionary<string, List<IObservable>>();
        }

        //Register a listener for an input
        public void Register(string input, IObservable observable)
        {
            //If the listener list does contain the input
            if (!listeners.ContainsKey(input))
                //add a list for that input
                listeners.Add(input, new List<IObservable>());

            listeners.Single(p => p.Key == input).Value.Add(observable);
        }


        //Unregister a listener
        public void Unregister(string input, IObservable observable)
        {
            if (!listeners.ContainsKey(input))
                return;

            listeners.Single(p => p.Key == input).Value.Remove(observable);
        }

        public bool Trigger(string input)
        {
            List<IObservable> inputListeners = listeners.SingleOrDefault(p => p.Key == input).Value;

            if (inputListeners == null || inputListeners.Count == 0)
                return false;

            foreach (IObservable observable in inputListeners)
            {
                if (!observable.Execute())
                    return true;
            }

            return true;
        }
    }
}
