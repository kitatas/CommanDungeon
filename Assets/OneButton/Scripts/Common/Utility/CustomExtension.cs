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

        public static string ToName(this RankingType type)
        {
            return type switch
            {
                RankingType.Coin => "大富豪の地下遺跡",
                _ => throw new Exception(ExceptionConfig.NOT_FOUND_RANKING_TYPE),
            };
        }
    }
}