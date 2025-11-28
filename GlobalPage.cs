public abstract class GlobalPage : ContentPage, INotifyPropertyChanged
{
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion


    public static WebContext webContext { get; set; }
    private static StatusBarBehavior statusBar { get; set; }
    public Command BackActionCommand { get; set; }
    public double ScreenWidth { get; set; }
    public double ScreenHeight { get; set; }

      protected GlobalPage()
      {
          SetStatusBar();
          if (webContext == null)
              webContext = new WebContext();
          OpenVideoCommand = new Command(OpenVideoCommandExecute);
          ScreenHeight = (DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density);
          ScreenWidth = (DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
      }

      private void SetStatusBar()
      {
          if (statusBar == null)
          {
              statusBar = new StatusBarBehavior();
              statusBar.StatusBarColor = GetResourcesService.GetColorFromName("PrimaryBlue");
          }
          this.Behaviors.Add(statusBar);
      }

}
