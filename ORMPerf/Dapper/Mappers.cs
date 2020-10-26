using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ORMPerf.Dapper
{
    class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid guid)
        {
            parameter.Value = guid.ToString();
        }

        public override Guid Parse(object value)
        {
            if (value is String str)
                return new Guid(str);
            else if (value is Guid id)
                return id;
            else
                return new Guid((byte[])value);
        }
    }
}
