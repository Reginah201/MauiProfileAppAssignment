using Microsoft.Maui;
using System.Text.Json;

namespace MauiProfileAppAssignment.Pages;

public partial class ProfilePage : ContentPage
{
    private const string FileName = "profile.json";
    private string FilePath => Path.Combine(FileSystem.AppDataDirectory, FileName);

    public ProfilePage()
    {
        InitializeComponent();
        LoadProfile();
    }

    private void LoadProfile()
    {
        if (File.Exists(FilePath))
        {
            try
            {
                string json = File.ReadAllText(FilePath);
                var profile = JsonSerializer.Deserialize<Profile>(json);
                if (profile != null)
                {
                    nameEntry.Text = profile.Name;
                    surnameEntry.Text = profile.Surname;
                    emailEntry.Text = profile.Email;
                    bioEditor.Text = profile.Bio;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "Failed to load profile", "OK");
            }
        }
    }

    private void SaveProfile(object sender, EventArgs e)
    {
        var profile = new Profile
        {
            Name = nameEntry.Text,
            Surname = surnameEntry.Text,
            Email = emailEntry.Text,
            Bio = bioEditor.Text
        };

        try
        {
            string json = JsonSerializer.Serialize(profile);
            File.WriteAllText(FilePath, json);
            DisplayAlert("Success", "Profile saved successfully!", "OK");
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", "Failed to save profile", "OK");
        }
    }
}

public class Profile
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
}