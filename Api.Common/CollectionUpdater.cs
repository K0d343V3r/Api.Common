using Api.Common.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Common
{
    public static class CollectionUpdater<T> where T: EntityBase, IUpdatable<T>
    {
        public static void Update(List<T> toEntities, List<T> fromEntities)
        {
            // remove or update existing entities
            var sourceEntities = new List<T>(fromEntities);
            var index = 0;
            while (index < toEntities.Count)
            {
                T foundEntity = sourceEntities.Find(e => e.Id == toEntities[index].Id);
                if (foundEntity == null)
                {
                    // entity not found in new list, remove it
                    toEntities.RemoveAt(index);
                }
                else
                {
                    // entity found in new list, update it
                    toEntities[index].UpdateFrom(foundEntity);

                    // remove so that we do not add it later on
                    sourceEntities.Remove(foundEntity);

                    // advance to next entity
                    index++;
                }
            }

            // add any new entities, resetting Ids to avoid exceptions
            sourceEntities.ForEach(e =>
                {
                    if (e.Id != 0)
                    {
                        e.Id = 0;
                    }

                    toEntities.Add(e);
                }
            );
        }
    }
}
