using System.Collections.Generic;

namespace Domain.ViewModels
{
    public class GenericListViewModel<T> : ViewModelBase where T : class
    {
        public GenericListViewModel()
        {
            Items = new List<T>();
        }

        public IEnumerable<T> Items { get; set; }

        public int Total { get; set; }
    }
}
