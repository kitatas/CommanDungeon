namespace OneButton.InGame.Domain.UseCase
{
    public sealed class ScoreUseCase
    {
        public int score { get; private set; }

        public ScoreUseCase()
        {
            score = 0;
        }

        public void Add(int value)
        {
            score += value;
        }
    }
}