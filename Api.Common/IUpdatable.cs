using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common
{
    public interface IUpdatable<T>
    {
        void UpdateFrom(T fromEntity);
    }
}
