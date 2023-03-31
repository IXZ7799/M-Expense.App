namespace M_Expense;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void searchTrip_SearchButtonPressed(object sender, EventArgs e)
    {

    }

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {

    }

    private void btnDeleteAll_Clicked(object sender, EventArgs e)
    {

    }
}

