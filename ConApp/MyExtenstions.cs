using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    public static class MyExtensions
    {
        /// <summary>
        /// Generic method to check the occurence of a type value in an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool In<T>(this T val, params T[] arr)
        {
            return arr.Contains<T>(val);
        }

        /// <summary>
        /// check the occurence of an object in an array of objects
        /// </summary>
        /// <param name="val"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool In(this object val, params object[] arr)
        {
            bool hasValue = false;
            foreach (var item in arr)
            {
                if (item.Equals(val))
                {
                    hasValue = true;
                    break;
                }
            }
            return hasValue;
        }

        /// <summary>
        /// generic method to return the index of a type value in an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <param name="arr"></param>
        /// <returns>-1 if not found</returns>
        public static int Pos<T>(this T val, params T[] arr)
        {
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(val))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// returns the index of an object in an array of objects
        /// </summary>
        /// <param name="val"></param>
        /// <param name="arr"></param>
        /// <returns>-1 if not found</returns>
        public static int Pos(this object val, params object[] arr)
        {
            int index = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(val))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
