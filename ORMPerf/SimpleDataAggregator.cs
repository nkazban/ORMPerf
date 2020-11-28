using ORMPerf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORMPerf
{
    class SimpleDataAggregator : IDataAggregator
    {
        Dictionary<TestType, List<TimeSpan>> _data;
        public SimpleDataAggregator()
        {
            _data = new Dictionary<TestType, List<TimeSpan>>();
        }

        public void AddInfo(TestType test, TimeSpan elapsed)
        {
            if(!_data.ContainsKey(test))
            {
                _data.Add(test, new List<TimeSpan>());
            }
            _data[test].Add(elapsed);
        }

        public TimeSpan GetAverage(TestType type)
        {
            if (!_data.ContainsKey(type))
                return new TimeSpan();
            var averageTicks = (long)_data[type].Average(x=>x.Ticks);
            return new TimeSpan(averageTicks);
        }

        public IEnumerable<TimeSpan> GetData(TestType type)
        {
            return _data[type];
        }
    }
}
