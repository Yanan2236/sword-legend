using UnityEngine;

namespace Game.Run
{
    /// <summary>
    /// このランにおける「剣」の状態を保持するクラス。
    ///
    /// デモ段階では、最小データだけを持たせる。
    ///
    /// 将来的にはここに、
    /// - 二つ名 / 称号
    /// - スキル / パッシブスキル
    /// - ステータス
    /// - 伝説度以外の成長指標
    /// - 歴代所有者との関係
    /// などを追加していく想定。
    /// </summary>
    [System.Serializable]
    public class SwordState
    {
        /// <summary>
        /// 剣の名前
        /// 今後、プレイヤーが変更できるようにする
        /// </summary>
        [SerializeField] private string name = "名無しの剣";

        /// <summary>
        /// 剣の伝説度。
        /// 現段階では最も単純な成長指標として扱う
        /// 今後、複数の成長指標に分解する
        /// </summary>
        [SerializeField] private int legendPoints = 0;

        public string Name => name;
        public int LegendPoints => legendPoints;

        public SwordState()
        {
        }

        public SwordState(string name, int legendPoints = 0)
        {
            this.name = name;
            this.legendPoints = Mathf.Max(0, legendPoints);
        }

        /// <summary>
        /// 伝説度を増加させる。
        /// 現状は負の値を許可せず、0未満にもならないようにしている。
        /// </summary>
        public void AddLegendPoints(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            legendPoints += amount;
        }

        /// <summary>
        /// 伝説度を減少させる。
        /// 現状は負の値を許可せず、0未満にもならないようにしている。
        /// </summary>
        public void RemoveLegendPoints(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            legendPoints = Mathf.Max(0, legendPoints - amount);
        }

        /// <summary>
        /// 剣名の変更。
        /// </summary>
        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            name = newName;
        }
    }
}
