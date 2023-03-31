﻿namespace M_Expense;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void searchTrip_SearchButtonPressed(object sender, EventArgs e)
    {
        string keyword = this.searchUser.Text;

        if (keyword == null || keyword.Length == 0)
        {
            populateUserData();
        }
        else
        {
            collectionView.ItemsSource = App.UserDatabase.SearchUserByName(keyword);
        }
    }

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        User selectedCust = (e.CurrentSelection.FirstOrDefault() as User);
        Navigation.PushModalAsync(new UserDetails(selectedCust, true), true);
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        User newCust = new User("", "", 0, UserCollection.DEFAULT_IMAGE);
        Navigation.PushModalAsync(new UserDetails(newCust, false), true);
    }

    private void btnDeleteAll_Clicked(object sender, EventArgs e)
    {
        App.UserDatabase.DeleteAllUsers();
        populateUserData();
    }
}

