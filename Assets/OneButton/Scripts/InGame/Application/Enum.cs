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
}