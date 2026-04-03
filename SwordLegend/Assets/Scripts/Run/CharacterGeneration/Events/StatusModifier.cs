namespace Game.Run
{
     /// <summary>
     /// キャラクターのステータスに対する補正を表すクラス。
     /// </summary>
    public class StatusModifier
    {
        /// <summary>
        /// 補正を適用するステータスタイプ。
        /// </summary>
        public CharacterStatusType Type { get; }

        /// <summary>
        /// ステータス補正の値。
        /// </summary>
        public int Value { get; }

        public StatusModifier(CharacterStatusType type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}