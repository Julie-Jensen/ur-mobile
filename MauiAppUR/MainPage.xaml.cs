using Android.OS;
using MauiAppUR.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace MauiAppUR;

public partial class MainPage : ContentPage
{
    private string _deviceToken;
	private List<Robot> robots = new List<Robot>();

	public MainPage()
	{
        AddData();
		InitializeComponent();

        var deviceTokenPref = "DeviceToken";

        if (Preferences.ContainsKey(deviceTokenPref))
            _deviceToken = Preferences.Get(deviceTokenPref, "");
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

