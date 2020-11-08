namespace PReardon.HueController.Configuration.Model
{
    public enum UpdateState
    {
        NoUpdateAvailable = 0,
        DownloadingAvailableUpdates = 1,
        UpdatesAreReadyToBeInstalled = 2,
        InstallingUpdates = 3
    }
}