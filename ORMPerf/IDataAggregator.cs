using System;
using System.Collections.Generic;

namespace ORMPerf
{
    enum TestType
    {
        Writing,
        WritingOneByOne,
        Reading,
        Deleting
    }

    interface IDataAggregator
    {
        void AddInfo(TestType test, TimeSpan elapsed);

        TimeSpan GetAverage(TestType type);

        IEnumerable<TimeSpan> GetData(TestType type);
    }
}
