namespace OneButton.InGame
{
    public sealed class GameConfig
    {
        public const GameState INIT_STATE = GameState.None;
    }

    public sealed class StageConfig
    {
        public const float MIN_X = -3.6f;
        public const float MAX_X = 3.6f;

        public const float MIN_Y = -1.6f;
        public const float MAX_Y = 3.6f;
    }

    public sealed class PlayerConfig
    {
        public const float MOVE_SPEED = 0.25f;
        public const float MOVE_INTERVAL = 0.15f;
    }

    public sealed class SlotConfig
    {
        public const int REEL_COUNT = 3;
        public const float PATTERN_INTERVAL = 0.1f;
    }
}