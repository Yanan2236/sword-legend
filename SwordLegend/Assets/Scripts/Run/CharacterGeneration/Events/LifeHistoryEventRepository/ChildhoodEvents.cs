namespace Game.Run
{
    /// <summary>
    /// 幼少期の人生履歴イベント定義をまとめるクラス。
    /// 具体的なイベントは今後ここに追加していく。
    /// </summary>
    public static class ChildhoodEvents
    {
        private static readonly LifeHistoryEvent[] events;
        /// <summary>
        /// 幼少期イベントの一覧。
        /// 外部から直接配列を変更できないように、クローンを返す。
        /// </summary>
        public static LifeHistoryEvent[] Events => (LifeHistoryEvent[])events.Clone();

        /// <summary>
        /// 幼少期イベント定を一覧化する。
        /// </summary>
        static ChildhoodEvents()
        {
            events = new LifeHistoryEvent[]
            {
                new LifeHistoryEvent(
                    "魔物の影に怯える辺境の村で育った",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.MaxHp, 10),
                        new StatusModifier(CharacterStatusType.Speed, 5),
                        new StatusModifier(CharacterStatusType.MagicDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "神殿の孤児院で育てられた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.MagicDefense, 10),
                        new StatusModifier(CharacterStatusType.PhysicalDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "魔導書庫に忍び込んでは本を読んでいた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.MagicAttack, 15),
                        new StatusModifier(CharacterStatusType.MaxHp, -5)
                    }
                ),
                new LifeHistoryEvent(
                    "行商隊とともに各地を渡り歩いた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.Speed, 10),
                        new StatusModifier(CharacterStatusType.PhysicalDefense, 5)
                    }
                ),
                new LifeHistoryEvent(
                    "家畜と畑を守るため木剣を振っていた",
                    new StatusModifier[]
                    {
                        new StatusModifier(CharacterStatusType.PhysicalAttack, 10),
                        new StatusModifier(CharacterStatusType.MaxHp, 5)
                    }
                ),
            };
        }

        /// <summary>
        /// ランダムに幼少期イベントを取得する。
        /// </summary>
        /// <param name="random">ランダム生成器</param>
        /// <returns>ランダムに選ばれた幼少期イベント</returns>
        /// 
        public static LifeHistoryEvent GetRandomEvent(System.Random random)
        {
            int index = random.Next(0, Events.Length);
            return Events[index];
        }
    }
}