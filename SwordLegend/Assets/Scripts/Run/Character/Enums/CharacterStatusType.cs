namespace Game.Run
{
    /// <summary>
    /// キャラクターのステータスタイプを表す列挙型。
    /// これを使って、CharacterState の AddStatus メソッドで使用。
    /// </summary>
    public enum CharacterStatusType
    {
        MaxHp,
        PhysicalAttack,
        MagicAttack,
        PhysicalDefense,
        MagicDefense,
        Speed
    }
}