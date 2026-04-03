namespace Game.Run
{
    /// <summary>
    /// 高校生期の人生履歴イベント定義をまとめるクラス。
    /// 具体的なイベントは今後ここに追加していく。
    /// </summary>
    public static class TeenEvents
    {
        private static readonly LifeHistoryEvent[] events;
        /// <summary>
        /// 高校生期イベントの一覧。
        /// 外部から直接配列を変更できないように、クローンを返す。
        /// </summary>
        public static LifeHistoryEvent[] Events => (LifeHistoryEvent[])events.Clone();

        /// <summary>
        /// 高校生期イベントを一覧化する。
        /// </summary>
        static TeenEvents()
        {
            events = new LifeHistoryEvent[]
            {
                new LifeHistoryEvent(
                    "魔導院で基礎術式を学んだ",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.MagicAttack, 10),
                        new StatusModifier(CharacterStatusType.MagicDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "騎士見習いとして城で鍛えられた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.PhysicalAttack, 10),
                        new StatusModifier(CharacterStatusType.PhysicalDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "神殿で奉仕を続けた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.MagicDefense, 10),
                        new StatusModifier(CharacterStatusType.MaxHp, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "遺跡調査隊の下働きをしていた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.Speed, 10),
                        new StatusModifier(CharacterStatusType.MagicDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "剣闘士として戦い続けた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.PhysicalAttack, 10),
                        new StatusModifier(CharacterStatusType.MaxHp, 5),
                        new StatusModifier(CharacterStatusType.MagicDefense, -5)
                    }
                )
            };
        }

        /// <summary>
        /// ランダムに高校生期イベントを取得する。
        /// </summary>
        /// <param name="random">ランダム生成器</param>
        /// <returns>ランダムに選ばれた高校生期イベント</returns>
        public static LifeHistoryEvent GetRandomEvent(System.Random random)
        {
            int index = random.Next(0, Events.Length);
            return Events[index];
        }
    }
}