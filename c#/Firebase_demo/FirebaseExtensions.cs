using Firebase.Database;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataStorage
{
    public static class FirebaseExtensions
    {
        public static T ToModal<T>(this FirebaseObject<T> obj)
            where T : DataModel
        {
            obj.Object.Id = obj.Key;
            return obj.Object;
        }

        public static IEnumerable<T> ToModals<T>(this IEnumerable<FirebaseObject<T>> objs)
            where T : DataModel
        {
            foreach (var o in objs)
            {
                o.Object.Id = o.Key;
                yield return o.Object;
            }
        }

        public static ReadOnlyCollection<T> AsReadonly<T>(this IEnumerable<T> collection)
        {
            return new ReadOnlyCollection<T>(collection.ToList());
        }
    }
}
