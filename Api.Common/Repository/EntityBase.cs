using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Common.Repository
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        protected void UpdateFrom(EntityBase fromEntity)
        {
            Id = fromEntity.Id;
            var toSortable = this as ISortable;
            var fromSortable = fromEntity as ISortable;
            if (toSortable != null && fromSortable != null)
            {
                toSortable.Position = fromSortable.Position;
            }
        }
    }
}
