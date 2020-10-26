using System.Collections.Generic;

namespace ORMPerf
{
    public interface IDBConnector
    {
        void Connect();
        void AddRandomRows(int count);
        IEnumerable<SimpleModel> ReadAll();
        void DeleteAllRows();
        void Disconnect();
    }
}