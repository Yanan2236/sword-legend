namespace Game.Run
{
    /// <summary>
    /// キャラクター生成時に適用する人生履歴イベントを表すクラス。
    /// イベント名と、各ステータスへの補正情報を保持する。
    /// </summary>
    public class LifeHistoryEvent
    {
        /// <summary>
        /// イベント名。
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// このイベントが持つステータス補正一覧。
        /// </summary>
        private readonly StatusModifier[] modifiers;
        public StatusModifier[] Modifiers => (StatusModifier[])modifiers.Clone();

        /// <summary>
        /// 人生履歴イベントを生成する。
        /// </summary>
        /// <param name="name">イベント名。</param>
        /// <param name="modifiers">ステータス補正一覧。</param>
        public LifeHistoryEvent(string name, StatusModifier[] modifiers)
        {
            Name = name;
            this.modifiers = (StatusModifier[])modifiers.Clone();
        }
    }
}