using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class GenericMethod
    {
        /// <summary>
        /// View all the properties of a class of type T
        /// </summary>

        public static void ViewProperties<T>(T obj) where T : class, new()
        {
            List<string> properties = obj.GetType().GetProperties().Select(p => p.Name).ToList();

            foreach (var item in properties)
            {
                Console.WriteLine($"Field: {item}");
            }
        }

        /// <summary>
        /// Create an instance of a list.
        /// Example usage: List<People> listPeople = Add.ListInstance<People>();
        /// </summary>

        public static List<T> ListInstance<T>() where T : class, new()
        {
            Type listType = GetGenerciListType<T>();
            List<T> list = (List<T>)Activator.CreateInstance(listType);
            list.Add(new T { });

            return list;
        }

        private static Type GetGenerciListType<T>()
        {
            Type objTyp = typeof(T);
            var defaultListType = typeof(List<>);

            Type[] itemTypes = { objTyp };
            Type listType = defaultListType.MakeGenericType(itemTypes);

            return listType;
        }
    }
}
