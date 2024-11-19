using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoobyObserver
{
    public interface IObserver
    {
        void Update(int affectionPoints, bool lockoutStatus, bool Shaginteraction, bool Daphinteraction, bool Fredinteraction);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void UnregisteredObserver(IObserver observer);
        void NotifyObservers();
    }
}