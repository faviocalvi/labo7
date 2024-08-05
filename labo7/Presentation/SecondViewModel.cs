using System.Collections.ObjectModel;

namespace labo7.Presentation;


public partial class SecondViewModel : ObservableObject
{
    private readonly Database _database;
    private readonly Subject _notificationSubject;
    private readonly ErrorLogger _errorLogger;
    [ObservableProperty]
    private ObservableCollection<Student> students;

    [ObservableProperty]
    private string searchTerm;

    [ObservableProperty]
    private string searchOption;
    [ObservableProperty]
    private string totalStudents;

    public ICommand SearchCommand { get; }
    public ICommand SortAscendingCommand {  get; }
    public ICommand SortDescendingCommand { get; }
    public ICommand ShowErrorsCommand { get; }


    public SecondViewModel(Database database, Subject notificationSubject, ErrorLogger errorLogger)
    {
        _database = database;
        _notificationSubject = notificationSubject;
        _errorLogger = errorLogger;
        Students = new ObservableCollection<Student>(_database.GetStudents());
        SearchCommand = new RelayCommand(SearchStudents);
        SortAscendingCommand = new RelayCommand(SortAscending);
        SortDescendingCommand = new RelayCommand(SortDescending);
        searchOption = "Name";
        UpdateTotalStudents();
    }

    private void SearchStudents()
    {
        try
        {
            var filteredStudents = _database.GetStudents().AsQueryable();
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                filteredStudents = searchOption switch
                {
                    "Name" => filteredStudents.Where(student => student.Name.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)),
                    "Lastname" => filteredStudents.Where(student => student.LastName.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)),
                    "Email" => filteredStudents.Where(student => student.Email.Contains(SearchTerm, System.StringComparison.OrdinalIgnoreCase)),
                    _ => filteredStudents
                };
            }
            Students = new ObservableCollection<Student>(filteredStudents.ToList());
            UpdateTotalStudents();
            _notificationSubject.Notify($"Search completed using {searchOption} with term '{SearchTerm}'.");
        }
        catch (Exception ex)
        {
            _errorLogger.LogError($"Error searching students: {ex.Message}");
        }
    }

    private void SortAscending()
    {
        try
            {
            Students = new ObservableCollection<Student>(Students.OrderBy(student => student.Name).ToList());
            UpdateTotalStudents();
            _notificationSubject.Notify($"Students sorted in ascending order by {searchOption}.");
        }
            catch (Exception ex)
            {
            _errorLogger.LogError($"Error sorting students: {ex.Message}");
        }
    }

    private void SortDescending()
    {
        try
        {
            Students = new ObservableCollection<Student>(Students.OrderByDescending(student => student.Name).ToList());
            UpdateTotalStudents();
            _notificationSubject.Notify($"Students sorted in descending order by {searchOption}.");
        }
        catch (Exception ex)
        {
            _errorLogger.LogError($"Error sorting students: {ex.Message}");
        }
    }

    private void UpdateTotalStudents()
    {
        TotalStudents = $"Total Students: {Students.Count}";
        OnPropertyChanged(nameof(TotalStudents));
    }
}
