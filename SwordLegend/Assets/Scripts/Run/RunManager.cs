using UnityEngine;

namespace Game.Run
{
    /// <summary>
    /// RunState を更新して、ゲーム進行を管理するクラス。
    /// 今はデモ用として、季節を1つ進める最低限の処理だけ持つ。
    /// </summary>
    [System.Serializable]
    public class RunManager : MonoBehaviour
    {
        /// <summary>
        /// 現在のゲーム進行状態を保持するインスタンス。
        /// </summary>
        [SerializeField] private RunState currentRun = new();
        public RunState CurrentRun => currentRun;

        private void Start()
        {
            Debug.Log(
                $"開始時点: {CurrentRun.Year}年 {GetSeasonLabel(CurrentRun.Quarter)} / " +
                $"剣: {CurrentRun.Sword.Name} / " +
                $"伝説値: {CurrentRun.Sword.LegendPoints}"
            );

            for (int i = 0; i < 5; i++)
            {
                AdvanceQuarter();
                Debug.Log(
                    $"{i + 1}回目: {CurrentRun.Year}年 {GetSeasonLabel(CurrentRun.Quarter)} / " +
                    $"年表件数: {CurrentRun.Chronicle.Count}"
                );
            }

            Debug.Log($"最終的な年表件数: {CurrentRun.Chronicle.Count}");
        }

        /// <summary>
        /// 1クール進める。
        /// 春→夏→秋→冬→翌年の春、という順番で季節を進める。
        /// 今後、SeasonCycleクラスに切り出す予定だが、デモ段階ではここで完結させる。
        /// </summary>
        public void AdvanceQuarter()
        {
            switch (CurrentRun.Quarter)
            {
                case Season.Spring:
                    CurrentRun.SetQuarter(Season.Summer);
                    break;

                case Season.Summer:
                    CurrentRun.SetQuarter(Season.Autumn);
                    break;

                case Season.Autumn:
                    CurrentRun.SetQuarter(Season.Winter);
                    break;

                case Season.Winter:
                    CurrentRun.SetQuarter(Season.Spring);
                    CurrentRun.AddYear(1);
                    break;
            }

            // デモ用に、季節が進むたび年表ログを追加する
            CurrentRun.AddChronicle(
                $"{CurrentRun.Year}年 {GetSeasonLabel(CurrentRun.Quarter)} へ進んだ"
            );
        }

        /// <summary>
        /// Season enum を日本語表示用の文字列に変換する。
        /// </summary>
        private string GetSeasonLabel(Season season)
        {
            switch (season)
            {
                case Season.Spring:
                    return "春";

                case Season.Summer:
                    return "夏";

                case Season.Autumn:
                    return "秋";

                case Season.Winter:
                    return "冬";

                default:
                    return "";
            }
        }
    }
}