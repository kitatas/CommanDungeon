namespace OneButton.Common
{
    public sealed class AppConfig
    {
        public const int MAJOR_VERSION = 1;
        public const int MINOR_VERSION = 1;
        public static readonly string APP_VERSION = $"{MAJOR_VERSION.ToString()}.{MINOR_VERSION.ToString()}";
    }

    public sealed class ExceptionConfig
    {
        public const string UNKNOWN_ERROR = "UNKNOWN_ERROR";
        public const string NOT_FOUND_STATE = "NOT_FOUND_STATE";
        public const string NOT_FOUND_REEL = "NOT_FOUND_REEL";
        public const string NOT_FOUND_MOVE_TYPE = "NOT_FOUND_MOVE_TYPE";
        public const string NOT_FOUND_ITEM_TYPE = "NOT_FOUND_ITEM_TYPE";
        public const string NOT_FOUND_LOAD_TYPE = "NOT_FOUND_LOAD_TYPE";
        public const string NOT_FOUND_REEL_DATA = "NOT_FOUND_REEL_DATA";
        public const string NOT_FOUND_BGM = "NOT_FOUND_BGM";
        public const string NOT_FOUND_SE = "NOT_FOUND_SE";
        public const string NOT_FOUND_DATA = "NOT_FOUND_DATA";
        public const string NOT_FOUND_RANKING_TYPE = "NOT_FOUND_RANKING_TYPE";
        public const string UNMATCHED_USER_NAME_RULE = "UNMATCHED_USER_NAME_RULE";
        public const string FAILED_LOGIN = "FAILED_LOGIN";
        public const string FAILED_UPDATE_DATA = "FAILED_UPDATE_DATA";
        public const string FAILED_DESERIALIZE_MASTER = "FAILED_DESERIALIZE_MASTER";
        public const string FAILED_RESPONSE_DATA = "FAILED_RESPONSE_DATA";
    }

    public sealed class SceneConfig
    {
        public const float FADE_TIME = 0.5f;
    }

    public sealed class UiConfig
    {
        public const float POPUP_TIME = 0.25f;
        public const float PRESS_TIME = 0.1f;

        public const float MAIN_BUTTON_TEXT_DEFAULT_HEIGHT = 33.5f;
        public const float MAIN_BUTTON_TEXT_PRESS_HEIGHT = 15.5f;
    }

    public sealed class SaveConfig
    {
        public const string ES3_KEY = "";
    }

    public sealed class PlayFabConfig
    {
        public const string TITLE_ID = "";
        public const string USER_PLAY_RECORD_KEY = "";
        public const string RANKING_COIN_KEY = "";
        public const string MASTER_APP_VERSION_KEY = "";

        public const int SHOW_MAX_RANKING = 50;
        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 10;
    }

    public sealed class SoundConfig
    {
        public const float INIT_VOLUME = 0.5f;
    }

    public sealed class UrlConfig
    {
        public const string APP = "";
    }
}