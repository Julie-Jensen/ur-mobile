namespace MauiAppUR;

public partial class MainPage : ContentPage
{
	private List<Robot> robots = new List<Robot>();

	int count = 0;

	public MainPage()
	{
        //Thread thread = new Thread(new ThreadStart(() => NotificationListener.ListenOnQueue()));
        //thread.IsBackground = true;
        //thread.Name = "Notification Listener Thread";
        //thread.Start();

        AddData();
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

	private void AddData()
	{
		robots.Add(new Robot()
		{
			Name = "Production Cobot 1",
			Model = "UR3e",
			Year = 2021,
			Status = "Ok",
			StatusChangedDate = DateTime.UtcNow.AddMonths(-3).AddDays(-5)
		});

        robots.Add(new Robot()
        {
            Name = "Production Cobot 2",
            Model = "UR3e",
            Year = 2022,
            Status = "Ok",
            StatusChangedDate = DateTime.UtcNow.AddMonths(-5)
        });

        robots.Add(new Robot()
        {
            Name = "Production Cobot 3",
            Model = "UR5e",
            Year = 2022,
            Status = "Protective Stop",
            StatusChangedDate = DateTime.UtcNow.AddHours(-1)
        });

        robots.Add(new Robot()
        {
            Name = "Packaging Cobot 1",
            Model = "UR16e",
            Year = 2022,
            Status = "Ok",
            StatusChangedDate = DateTime.UtcNow.AddMonths(-5)
        });

        robots.Add(new Robot()
        {
            Name = "Packaging Cobot 1",
            Model = "UR10e",
            Year = 2022,
            Status = "Ok",
            StatusChangedDate = DateTime.UtcNow.AddMonths(-5)
        });

        robots.Add(new Robot()
        {
            Name = "Terminator",
            Model = "UR20",
            Year = 2022,
            Status = "Ok",
            StatusChangedDate = DateTime.UtcNow.AddMonths(-5)
        });
    }
}

public class Robot
{
	public string Name { get; set; }
	public string Model { get; set; }
	public int Year { get; set; }
	public string Status { get; set; }
	public DateTime StatusChangedDate { get; set; }
}

