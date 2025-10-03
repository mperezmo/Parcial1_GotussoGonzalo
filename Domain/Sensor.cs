using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Sensor
    {
        private readonly string _name;
        private readonly Random _random;
        private readonly List<IObserver> _observers;
        private readonly object _lock = new object();

        public Sensor(string name)
        {
            _name = name;
            _random = new Random();
            _observers = new List<IObserver>();
        }

        public void Subscribe(IObserver observer)
        {
            lock (_lock)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
            }
        }

        public void Unsubscribe(IObserver observer)
        {
            lock (_lock)
            {
                if (_observers.Contains(observer))
                {
                    _observers.Remove(observer);
                }
            }
        }

        public void Activate()
        {
            bool value1 = _random.Next(2) == 0;
            bool value2 = _random.Next(2) == 0;
            Console.WriteLine($"{_name} emitió valores: {value1} {value2}");
            NotifyObservers(value1, value2);
        }

        private void NotifyObservers(bool value1, bool value2)
        {
            List<IObserver> observersCopy;
            lock (_lock)
            {
                observersCopy = new List<IObserver>(_observers);
            }

            foreach (var observer in observersCopy)
            {
                observer.Update(value1, value2);
            }
        }
    }
}
