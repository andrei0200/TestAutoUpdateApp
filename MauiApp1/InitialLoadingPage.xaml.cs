using System.Net.NetworkInformation;

namespace MauiApp1;

public partial class InitialLoadingPage : ContentPage
{
	string isConnected = "Fara conexiune";
	public InitialLoadingPage()
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

	public string IsConnected // Property to bind to the XAML
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                OnPropertyChanged(nameof(IsConnected)); // Notify XAML of property change
            }
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
}