using System;

namespace OneButton.Common
{
    public static class CustomExtension
    {
        public static string ToKey(this RankingType type)
        {
            return type switch
            {
                RankingType.Coin => PlayFabConfig.RANKING_COIN_KEY,
                _ => throw new Exception(ExceptionConfig.NOT_FOUND_RANKING_TYPE),
            };
        }
    }
}