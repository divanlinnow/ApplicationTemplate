using System;

public class ListViewModel<T> : ViewModelBase where T : class
{
    public ListViewModel()
    {
        Items = new List<T>();
    }

    public IEnumerable<T> Items { get; set; }

    public int Total { get; set; }
}
