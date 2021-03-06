﻿using System.Collections.Generic;

namespace ORMPerf.Core
{
    public interface IDBConnector
    {
        void AddRandomRows(int count);
        void AddRandomRowsOneByOne(int count);
        IEnumerable<SimpleModel> ReadAll();
        void DeleteAllRows();

        string Name { get; }
    }
}