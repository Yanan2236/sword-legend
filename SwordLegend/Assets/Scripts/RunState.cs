using System.Collections.Generic;

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
    public int Year = 1;
    /// <summary>
    /// 現在の季節。1クール1イベント制の進行単位。
    /// </summary>
    public Season Quarter = Season.Spring;

    /// <summary>
    /// 騎士の現在の体力。
    /// </summary> 
    public int KnightHp = 10;
    /// <summary> 
    /// 騎士が生きているかどうか。体力が 0 になったら false にする。 
    /// 今後は HP から自動計算に寄せてもよいが、最初は明示的に持っておく。
    /// </summary>
    public bool IsKnightAlive = true;

    /// <summary>
    /// 剣の年表ログ。
    /// 例: 「3年目春：ダンジョン3層にてネクロマンサーを討伐」
    /// </summary>
    public List<string> Chronicle = new List<string>();
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