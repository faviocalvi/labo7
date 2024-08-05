namespace labo7.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        var notificationSubject = (Application.Current as App)?.NotificationSubject;
        var observer = new NotificationObserver(NotificationArea);
        notificationSubject?.Attach(observer);
    }
}
