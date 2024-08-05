

namespace labo7.Models;
public class NotificationObserver : IObserver
{
    private TextBlock _notificationArea;

    public NotificationObserver(TextBlock notificationArea)
    {
        _notificationArea = notificationArea;
    }

    public void Update(string message)
    {
        _notificationArea.Text = message;
    }
}
