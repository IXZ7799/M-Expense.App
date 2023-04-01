using Microsoft.Maui.Controls;

namespace M_Expense;

public partial class UserDetails : ContentPage
{
    private bool isUpdated;
    public UserDetails(User cust, bool isUpdated)
    {
        InitializeComponent();
        this.isUpdated = isUpdated;

        this.pckImage.Items.Clear();
        this.pckImage.ItemsSource = UserSQLiteDatabase.imageNames;

        App thisApp = Application.Current as App;
        thisApp.selectedUser = cust;
        this.gridUser.BindingContext = thisApp.selectedUser;

        if (cust != null)
            this.pckImage.SelectedItem = cust.ImageName;
    }

    private void pckImage_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.imgPic.Source = this.pckImage.SelectedItem as string;
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        string selectedImage = UserSQLiteDatabase.DEFAULT_IMAGE;
        string tripName = this.txtTripName.Text;
        string destination = this.txtDestination.Text;
        string tripDate = this.txtTripDate.Text;
        string riskAssessment = this.txtRiskAssessment.Text;
        string tripDesc = this.txtTripDesc.Text;
        int peopleAttending = int.Parse(this.txtPeopleAttending.Text);
        string transportation = this.txtTransportation.Text;

        if (this.pckImage.SelectedItem != null)
            selectedImage = this.pckImage.SelectedItem as string;

        if (isUpdated)
        {
            App thisApp = Application.Current as App;

            thisApp.selectedUser.TripName = tripName;
            thisApp.selectedUser.Destination = destination;
            thisApp.selectedUser.TripDate = tripDate;
            thisApp.selectedUser.RiskAssessment = riskAssessment;
            thisApp.selectedUser.TripDesc = tripDesc;
            thisApp.selectedUser.PeopleAttending = peopleAttending;
            thisApp.selectedUser.Transportation = transportation;
            thisApp.selectedUser.ImageName = selectedImage;

            App.UserDatabase.SaveUser(thisApp.selectedUser);
        }
        else
        {
            User newCust = new User(tripName, destination, tripDate, riskAssessment, tripDesc, peopleAttending, transportation, 0, selectedImage);
            App.UserDatabase.SaveUser(newCust);
            Navigation.PopModalAsync();
        }
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        App thisApp = Application.Current as App;
        App.UserDatabase.DeleteUser(thisApp.selectedUser);
        Navigation.PopModalAsync();
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}