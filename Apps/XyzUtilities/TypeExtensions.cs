using System;
using System.Collections.Generic;
using System.Text;

namespace XyzUtilities
{
    public static class TypeExtensions
    {
        public static TypeDescription GetDescription (this Type type)
        {
            return new TypeDescription
            {
                AssembyQualifiedName = type.AssemblyQualifiedName,
                FullName = type.FullName
            };
        }
    }


    public class TypeDescription
    {
        public string FullName { get; set; }
        public string  AssembyQualifiedName { get; set; }
    }
}
