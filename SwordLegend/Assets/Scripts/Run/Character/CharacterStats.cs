using System;

namespace Game.Run
{
    /// <summary>
    /// キャラクターの基本ステータスを管理するクラス。
    /// </summary>
    [Serializable]
    public class CharacterStats
    {
        private int maxHp;
        private int physicalAttack;
        private int magicAttack;
        private int physicalDefense;
        private int magicDefense;
        private int speed;

        public int MaxHp => maxHp;
        public int PhysicalAttack => physicalAttack;
        public int MagicAttack => magicAttack;
        public int PhysicalDefense => physicalDefense;
        public int MagicDefense => magicDefense;
        public int Speed => speed;

        public CharacterStats(
            int maxHp,
            int physicalAttack,
            int magicAttack,
            int physicalDefense,
            int magicDefense,
            int speed)
        {
            SetAllStats(
                maxHp,
                physicalAttack,
                magicAttack,
                physicalDefense,
                magicDefense,
                speed
            );
        }

        /// <summary> 
        /// ステータスを直接設定するためのメソッド。
        /// </summary>
        /// <param name="type">設定するステータスの種類</param>
        /// <param name="value">設定する値</param>
        public void SetStatus(CharacterStatusType type, int value)
        {
            switch (type)
            {
                case CharacterStatusType.MaxHp:
                    SetMaxHp(value);
                    break;
                case CharacterStatusType.PhysicalAttack:
                    SetPhysicalAttack(value);
                    break;
                case CharacterStatusType.MagicAttack:
                    SetMagicAttack(value);
                    break;
                case CharacterStatusType.PhysicalDefense:
                    SetPhysicalDefense(value);
                    break;
                case CharacterStatusType.MagicDefense:
                    SetMagicDefense(value);
                    break;
                case CharacterStatusType.Speed:
                    SetSpeed(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// ステータスを加算するためのメソッド。
        /// </summary>
        /// <param name="type">加算するステータスの種類</param>
        /// <param name="value">加算する値</param>
        public void AddStatus(CharacterStatusType type, int value)
        {
            switch (type)
            {
                case CharacterStatusType.MaxHp:
                    AddMaxHp(value);
                    break;
                case CharacterStatusType.PhysicalAttack:
                    AddPhysicalAttack(value);
                    break;
                case CharacterStatusType.MagicAttack:
                    AddMagicAttack(value);
                    break;
                case CharacterStatusType.PhysicalDefense:
                    AddPhysicalDefense(value);
                    break;
                case CharacterStatusType.MagicDefense:
                    AddMagicDefense(value);
                    break;
                case CharacterStatusType.Speed:
                    AddSpeed(value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// ステータスを一括で設定するメソッド。
        /// キャラクター生成時やロード時など、複数のステータスをまとめて反映したい場合に使用する。
        /// </summary>
        private void SetAllStats(
            int maxHp,
            int physicalAttack,
            int magicAttack,
            int physicalDefense,
            int magicDefense,
            int speed)
        {
            SetMaxHp(maxHp);
            SetPhysicalAttack(physicalAttack);
            SetMagicAttack(magicAttack);
            SetPhysicalDefense(physicalDefense);
            SetMagicDefense(magicDefense);
            SetSpeed(speed);
        }

        private void SetMaxHp(int value)
        {
            maxHp = Math.Max(0, value);
        }

        private void AddMaxHp(int value)
        {
            SetMaxHp(maxHp + value);
        }

        private void SetPhysicalAttack(int value)
        {
            physicalAttack = Math.Max(0, value);
        }

        private void AddPhysicalAttack(int value)
        {
            SetPhysicalAttack(physicalAttack + value);
        }

        private void SetMagicAttack(int value)
        {
            magicAttack = Math.Max(0, value);
        }

        private void AddMagicAttack(int value)
        {
            SetMagicAttack(magicAttack + value);
        }

        private void SetPhysicalDefense(int value)
        {
            physicalDefense = Math.Max(0, value);
        }

        private void AddPhysicalDefense(int value)
        {
            SetPhysicalDefense(physicalDefense + value);
        }

        private void SetMagicDefense(int value)
        {
            magicDefense = Math.Max(0, value);
        }

        private void AddMagicDefense(int value)
        {
            SetMagicDefense(magicDefense + value);
        }

        private void SetSpeed(int value)
        {
            speed = Math.Max(0, value);
        }

        private void AddSpeed(int value)
        {
            SetSpeed(speed + value);
        }
    }
}