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
        CharacterGenerator generator = new CharacterGenerator();
        CharacterState character = generator.GenerateCharacter();

        Debug.Log(BuildCharacterSummary(character));
    }

    private string BuildCharacterSummary(CharacterState character)
    {
        return
            $"Name: {character.CharacterName}\n" +
            $"Age: {character.Age}\n" +
            $"MaxHp: {character.Stats.MaxHp}\n" +
            $"PhysicalAttack: {character.Stats.PhysicalAttack}\n" +
            $"MagicAttack: {character.Stats.MagicAttack}\n" +
            $"PhysicalDefense: {character.Stats.PhysicalDefense}\n" +
            $"MagicDefense: {character.Stats.MagicDefense}\n" +
            $"Speed: {character.Stats.Speed}\n" +
            $"Childhood: {character.ChildhoodEvent.Name}\n" +
            $"Teen: {character.TeenEvent.Name}";
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