

namespace labo7.Presentation;

public sealed partial class SecondPage : Page
{
    public SecondPage()
    {
        this.InitializeComponent();
        var notificationSubject = (Application.Current as App)?.NotificationSubject;
        var observer = new NotificationObserver(NotificationArea);
        notificationSubject?.Attach(observer);
    }
}

