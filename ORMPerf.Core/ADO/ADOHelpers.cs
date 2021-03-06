﻿using System.Data.Common;

namespace ORMPerf.Core.ADO
{
    static class ADOHelpers
    {
        public static SimpleModel ReadModel(this DbDataReader reader)
        {
            var result = new SimpleModel();

            result.Id = reader.GetInt32(0);
            result.Name = reader.GetString(1);
            result.Birth = reader.GetDateTime(2);
            result.About = reader.GetString(3);

            return result;
        }
    }
}
