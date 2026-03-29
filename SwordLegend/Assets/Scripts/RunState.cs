using System.Collections.Generic;
using UnityEngine;

namespace Game.Run
    {
    /// <summary>
    /// 1プレイ中の進行状態をまとめて保持するクラス。
    /// 年・季節・騎士の状態・剣の年表ログをここで管理する。
    /// </summary>
    [System.Serializable]
    public class RunState
    {
        /// <summary>
        /// 現在が何年目か。デモでは 1 年目から開始する。
        /// </summary>
        [SerializeField] private int year = 1;
        public int Year => year;

        /// <summary>
        /// 現在の季節。1クール1イベント制の進行単位。
        /// </summary>
        [SerializeField] private Season quarter = Season.Spring;
        public Season Quarter => quarter;

        /// <summary>
        /// このランの主人公である剣。
        /// 将来的には性質や称号などもここに追加していく想定。
        /// </summary>
        [SerializeField] private SwordState sword = new SwordState();
        public SwordState Sword => sword;

        /// <summary>
        /// 騎士の現在の体力。
        /// 今後、キャラクタークラスに切り出す
        /// </summary>
        [SerializeField] private int knightHp = 10;
        public int KnightHp => knightHp;

        /// <summary>
        /// 騎士が生きているかどうか。体力が 0 になったら false にする。
        /// 今後は HP から自動計算に寄せてもよいが、最初は明示的に持っておく。
        /// </summary>
        [SerializeField] private bool isKnightAlive = true;
        public bool IsKnightAlive => isKnightAlive;

        /// <summary>
        /// 剣の年表ログ。
        /// 例: 「3年目春：ダンジョン3層にてネクロマンサーを討伐」
        ///
        /// 現段階では Run 全体の記録として保持する。
        /// 将来的には Chronicle クラスへの切り出しも検討する。
        /// </summary>
        [SerializeField] private List<string> chronicle = new();
        public List<string> Chronicle => chronicle;

        /// <summary>
        /// 季節を更新する。
        /// 状態の更新責務は基本的に RunManager 側に寄せるが、
        /// 値の代入自体はこのクラス内に閉じておく。
        /// </summary>
        public void SetQuarter(Season nextQuarter)
        {
            quarter = nextQuarter;
        }

        /// <summary>
        /// 年数を加算する。
        /// </summary>
        public void AddYear(int amount)
        {
            year += amount;
        }

        /// <summary>
        /// 年表ログを追加する。
        /// 空文字や null は追加しない。
        /// </summary>
        public void AddChronicle(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            chronicle.Add(text);
        }
    }

    /// <summary>
    /// 季節の列挙型。
    /// </summary>
    public enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
}