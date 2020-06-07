
namespace ToDoApp.ViewModels.Sprint
{
    public class SprintDetailViewModel : BaseViewModel
    {
        public ToDoApp.Models.Sprint Item { get; set; }
        public SprintDetailViewModel(ToDoApp.Models.Sprint item = null)
        {
            Title = item?.Name;
            Item = item;
        }
    }
}
