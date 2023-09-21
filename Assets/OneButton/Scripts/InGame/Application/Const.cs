namespace OneButton.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.None;
    }

    public sealed class StageConfig
    {
        public const float HIDE_STEP_HEIGHT = 9.0f;

        public const float SHOW_HEIGHT = 0.5f;
        public const float HIDE_HEIGHT_MIN = -10.5f;
        public const float HIDE_HEIGHT_MAX = HIDE_STEP_HEIGHT + 0.5f;

        public const float TWEEN_TIME = 0.5f;
    }

    public sealed class PlayerConfig
    {
        public const float MOVE_SPEED = 0.25f;
        public const float MOVE_INTERVAL = 0.15f;
        public const float VIBRATE_TIME = 0.05f;

        // 移動範囲
        public const float MIN_X = -3.6625f;
        public const float MAX_X = 3.6625f;
        public const float MIN_Y = -1.35f;
        public const float MAX_Y = 3.85f;

        // HP
        public const int MIN_HP = 0;
        public const int MAX_HP = 15;
    }

    public sealed class SlotConfig
    {
        public const int REEL_COUNT = 3;
        public const float PATTERN_INTERVAL = 0.1f;

        public const int THRESHOLD_TITLE = 0;
        public const int THRESHOLD_EASY = 5;
        public const int THRESHOLD_NORMAL = 10;
        public const int THRESHOLD_HARD = 15;
    }

    public sealed class ScoreConfig
    {
        public const float SHOW_TIME = 0.5f;

        public const int FLOOR_RATE = 10000;
        public const int COIN_RATE = 100;
        public const int SLOT_MATCH_RATE = 1000;
    }
}