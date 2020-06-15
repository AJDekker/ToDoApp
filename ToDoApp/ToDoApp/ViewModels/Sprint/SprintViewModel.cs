using System; 
using System.ComponentModel;
using TodoApp.Repository.Sprint;
using ToDoApp.Views;
using ToDoApp.Views.Sprint;
using Xamarin.Forms;

namespace ToDoApp.ViewModels.Sprint
{
    public class SprintViewModel : INotifyPropertyChanged
    {
        private Guid Id = new Guid("058ba2ce-121b-44fc-a806-e5c7764d5bf4");
        ISprintRepository _sprintRepository;

        public SprintViewModel(ISprintRepository sprintrepository)
        {
            _sprintRepository = sprintrepository;
        }

        public SprintViewModel(ISprintRepository sprintRepository, string name, int storyPoints)
        {
            _sprintRepository = sprintRepository;
            this.name = name;
            this.storyPoints = storyPoints;

        }


        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int storyPoints;
        public int StoryPoints
        {
            get { return storyPoints; }
            set
            {
                storyPoints = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Storypoints"));
            }
        }
        public Command SaveCommand
        {
            get
            {
                return new Command(() =>
                { 
                        AddSprint(); 
                });
            }
        }
        public async void AddSprint()
        { 

            if (string.IsNullOrEmpty(name))
            {
                //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            }
            else
            { 
                var Sprint = await _sprintRepository.AddSprint(Id, name, storyPoints); 

                if (Sprint)
                {
                    //await App.Current.MainPage.DisplayAlert("Save Sprint Success", "", "Ok");


                    //await App.Current.MainPage.Navigation.PushModalAsync(new SprintListPage());
                }
                else
                {
                    //await App.Current.MainPage.DisplayAlert("Error", "Save Sprint Fail", "OK");
                }
            }
        }

        public async void UpdateSprint()
        {


            if (string.IsNullOrEmpty(name))
            {
                //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            }
            else
            {

                var Sprint = await _sprintRepository.UpdateSprint(Id, name, storyPoints);

                if (Sprint)
                {
                    //await App.Current.MainPage.DisplayAlert("Save Sprint Success", "", "Ok");


                    //await App.Current.MainPage.Navigation.PushModalAsync(new SprintListPage());
                }
                else
                {
                    //await App.Current.MainPage.DisplayAlert("Error", "Save Sprint Fail", "OK");
                }
            }
        }

            public async void DeleteSprint()
            {


                if (string.IsNullOrEmpty(name))
                {
                    //await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
                }
                else
                {

                    var Sprint = await _sprintRepository.DeleteSprint(Id);

                    if (Sprint)
                    {
                        //await App.Current.MainPage.DisplayAlert("Save Sprint Success", "", "Ok");


                        //await App.Current.MainPage.Navigation.PushModalAsync(new SprintListPage());
                    }
                    else
                    {
                        //await App.Current.MainPage.DisplayAlert("Error", "Save Sprint Fail", "OK");
                    }
                }
            }
        }
}
            