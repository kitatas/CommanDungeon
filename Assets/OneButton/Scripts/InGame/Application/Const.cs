namespace OneButton.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.None;
    }

    public sealed class StageConfig
    {

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
    }

    public sealed class SlotConfig
    {
        public const int REEL_COUNT = 3;
        public const float PATTERN_INTERVAL = 0.1f;
    }
}