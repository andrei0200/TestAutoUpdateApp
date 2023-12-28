using System.Net.NetworkInformation;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;
	string isConnected = "Fara conexiune";

	public MainPage()
	{
		InitializeComponent();
		if (CheckInternetConnection())
            {
				isConnected = "Cu internet";
            }
            else
            {
                
            }
		this.BindingContext = this;
	}

	public static bool CheckInternetConnection()
	{
		try
		{
			Ping ping = new Ping();
			PingReply reply = ping.Send("www.google.com");
			return reply.Status == IPStatus.Success;
		}
		catch (PingException)
		{
			return false;
		}
	}

	public string IsConnected // Property to bind to the XAML
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                OnPropertyChanged(nameof(IsConnected)); // Notify XAML of property change
            }
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
}

