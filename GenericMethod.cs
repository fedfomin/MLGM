using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class GenericMethod
    {
        public static void ViewProperties<T>(T obj) where T : class, new()
        {
            List<string> properties = obj.GetType().GetProperties().Select(p => p.Name).ToList();

            for (int i = 0; i < properties.Count; i++)
            {
                Console.WriteLine($"Field {i}: {properties[i]}"); // View properties of a class of type T
            }
        }
    }
}
