namespace Domain.Actions.Core.ViewModels
{
    public class GenericItemViewModel<T> : ViewModelBase where T : class
    {
        public T Item { get; set; }
    }
}
