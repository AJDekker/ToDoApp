using System; 
using System.ComponentModel;
using ToDoApp.Views;
using ToDoApp.Views.Sprint;
using Xamarin.Forms;

namespace ToDoApp.ViewModels.Sprint
{
    public class SprintViewModel : INotifyPropertyChanged
    {
        private Guid Id = new Guid("058ba2ce-121b-44fc-a806-e5c7764d5bf4");


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
                        SignUp(); 
                });
            }
        }
        private async void SignUp()
        {
            //null or empty field validation, check weather email and password is null or empty

            if (string.IsNullOrEmpty(Name) )
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Name and Description", "OK");
            else
            {
                //call AddUser function which we define in Firebase helper class
                var Sprint = await SprintFirebaseHelper.AddSprint(Id, Name, StoryPoints );
                //AddUser return true if data insert successfuly 
                if (Sprint)
                {
                    await App.Current.MainPage.DisplayAlert("Save Sprint Success", "", "Ok");
                    //Navigate to Wellcom page after successfuly SignUp
                    //pass user email to welcom page
                    await App.Current.MainPage.Navigation.PushModalAsync(new SprintListPage());
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Save Sprint Fail", "OK");
            }
        }
    }
}
            