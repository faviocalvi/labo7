using CommunityToolkit.Mvvm.Messaging;
using labo7.Models;

namespace labo7.Presentation;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;
    private readonly Database _database;
    private readonly Subject _notificationSubject;
    private readonly ErrorLogger logger;


    [ObservableProperty]
    private string? name;
    [ObservableProperty]
    private string? lastname;
    [ObservableProperty]
    private string? email;
    [ObservableProperty]
    private string? errorMessage;

    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator,
        Database database,
        Subject notificationSubject,
        ErrorLogger errorLogger)
    {
        _navigator = navigator;
        _database = database;
        _notificationSubject = notificationSubject;
        logger = errorLogger;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        GoToSecond = new AsyncRelayCommand(GoToSecondView);
        AddStudentCommand = new RelayCommand(AddStudent);
    }
    public string? Title { get; }

    public ICommand GoToSecond { get; }
    public ICommand AddStudentCommand { get; }

    private async Task GoToSecondView()
    {
        await _navigator.NavigateViewModelAsync<SecondViewModel>(this, data: new Entity(Name!));
    }
    private void AddStudent()
    {
        try
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Lastname) && !string.IsNullOrEmpty(Email))
            {
                var newStudent = new Student(Name, Lastname, Email);
                _database.addStudent(newStudent);
                Name = string.Empty;
                Lastname = string.Empty;
                Email = string.Empty;
                ErrorMessage = string.Empty;
                OnPropertyChanged(nameof(ErrorMessage));
                _notificationSubject.Notify($"Student {newStudent.Name} {newStudent.LastName} added.");
            }
            else
            {
                ErrorMessage = "All fields must be filled out.";
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Error adding student: {ex.Message}");
        }

    }

}


    
