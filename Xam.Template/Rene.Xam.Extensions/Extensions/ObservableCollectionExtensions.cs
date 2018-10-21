using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;

// ReSharper disable once CheckNamespace
namespace Rene.Xam.Extensions.Extensions
{
    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Añade varios elementos a un observableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colleccion"></param>
        /// <param name="items"></param>
        public static void AddRange<T>(this ObservableCollection<T> colleccion, IEnumerable<T> items)
        {
            if (colleccion == null)
            {
                colleccion = new ObservableCollection<T>(items);
                return;
            }

            items.ForEach(colleccion.Add);
        }

        /// <summary>
        /// Añade varios elementos a un observableCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colleccion"></param>
        /// <param name="items"></param>
        public static void Add<T>(this List<T> colleccion, IEnumerable<T> items)
        {
            if (colleccion == null)
            {
                colleccion = new List<T>(items);
                return;
            }

            items.ForEach(colleccion.Add);
        }
    }
}
