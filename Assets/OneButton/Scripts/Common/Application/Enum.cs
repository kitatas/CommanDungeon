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

    public enum BgmType
    {
        None,
        Title,
        Main,
        Result,
    }

    public enum SeType
    {
        None,
        Decision,
        MainButton,
        Move,
        GetCoin,
        GetHeart,
        NextFloor,
        Result,
        LastScore,
        PopView,
        Fade,
    }

    public enum RankingType
    {
        None,
        Coin,
    }
}