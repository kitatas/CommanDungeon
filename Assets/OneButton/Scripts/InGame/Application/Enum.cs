namespace OneButton.InGame
{
    public enum GameState
    {
        None,
        Slot,
        Move,
        Step,
        Finish,
        Result,
        Ranking,
    }

    public enum PatternType
    {
        None,
        Coin,
        Heart,
    }

    public enum MoveType
    {
        None,
        Up,
        Down,
        Left,
        Right,
        DoubleUp,
        DoubleDown,
        DoubleLeft,
        DoubleRight,
    }

    public enum Difficulty
    {
        None,
        Title,
        Easy,
        Normal,
        Hard,
    }
}