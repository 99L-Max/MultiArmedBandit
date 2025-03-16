namespace MultiArmedBandit
{
    static class Notificator
    {
        public static void ShowNotification(string text)
        {
            var notification = new Notification();
            notification.ShowNotification(text);
        }
    }
}
