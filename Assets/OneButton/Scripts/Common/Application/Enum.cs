namespace OneButton.Common
{
    public enum SceneName
    {
        None,
        Boot,
        Main,
    }

    public enum LoadType
    {
        None,
        Direct,
        Fade,
    }

    public enum ExceptionType
    {
        None,
        Cancel,
        Retry,
        Reboot,
        Crash,
    }
}