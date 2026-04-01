using UnityEngine;

namespace Game.Run
{
    /// <summary>
    /// キャラクターの基本状態を管理するクラス。
    /// </summary>
    [System.Serializable]
    public class CharacterState : MonoBehaviour
    {
        [SerializeField] private string characterName = "名無しのキャラクター";
        [SerializeField] private bool isAlive = true;
        [SerializeField] private int baseMaxHp = 0;
        [SerializeField] private int basePhysicalAttack = 0;
        [SerializeField] private int baseMagicAttack = 0;
        [SerializeField] private int basePhysicalDefense = 0;
        [SerializeField] private int baseMagicDefense = 0;
        [SerializeField] private int baseSpeed = 0;
        [SerializeField] private int age = 0;
        [SerializeField] private Skill[] skills = new Skill[3];

        public string CharacterName => characterName;
        public bool IsAlive => isAlive;
        public int BaseMaxHp => baseMaxHp;
        public int BasePhysicalAttack => basePhysicalAttack;
        public int BaseMagicAttack => baseMagicAttack;
        public int BasePhysicalDefense => basePhysicalDefense;
        public int BaseMagicDefense => baseMagicDefense;
        public int BaseSpeed => baseSpeed;
        public int Age => age;
        public int SkillCount => skills.Length;

        // 外部から直接 skills 配列を変更できないように、コピーを返すようにしている。
        // 配列ではなく個別に返す仕様も要検討。
        public Skill[] Skills
        {
            get
            {
                Skill[] copy = new Skill[skills.Length];
                System.Array.Copy(skills, copy, skills.Length);
                return copy;
            }
        }

        public Skill GetSkill(int index)
        {
            if (index < 0 || index >= skills.Length)
            {
                throw new System.ArgumentOutOfRangeException(nameof(index));
            }

            return skills[index];
        }

        public bool HasSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new System.ArgumentNullException(nameof(skill));
            }

            for (int i = 0; i < skills.Length; i++)
            {
                if (skills[i] == skill)
                {
                    return true;
                }
            }

            return false;
        }

        public void SetCharacterName(string newName)
        {
            characterName = newName;
        }

        public void SetAge(int newAge)
        {
            age = Mathf.Max(0, newAge);
        }

        public void AddAge(int value)
        {
            SetAge(age + value);
        }

        public void SetAlive(bool value)
        {
            isAlive = value;
        }

        /// <summary> 
        /// キャラクターのステータスを直接設定するためのメソッド。
        /// type でどのステータスを設定するかを指定し、value で設定値を指定する。
        /// 例えば、SetStatus(CharacterStatusType.MaxHp, 10) と呼び出すと、最大HPが10に設定される。
        /// ステータスが0未満にならないように、最低値を0に設定する。
        /// </summary>
        public void SetStatus(CharacterStatusType type, int value)
        {
            switch (type)
            {
                case CharacterStatusType.MaxHp:
                    SetBaseMaxHp(value);
                    break;
                case CharacterStatusType.PhysicalAttack:
                    SetBasePhysicalAttack(value);
                    break;
                case CharacterStatusType.MagicAttack:
                    SetBaseMagicAttack(value);
                    break;
                case CharacterStatusType.PhysicalDefense:
                    SetBasePhysicalDefense(value);
                    break;
                case CharacterStatusType.MagicDefense:
                    SetBaseMagicDefense(value);
                    break;
                case CharacterStatusType.Speed:
                    SetBaseSpeed(value);
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary> 
        /// キャラクターのステータスを増減させるためのメソッド。
        /// 例えば、アイテムやイベントの効果でステータスが変化する場合に使用する。
        /// type でどのステータスを変化させるかを指定し、value で増減量を指定する。
        /// 例えば、AddStatus(CharacterStatusType.MaxHp, 10) と呼び出すと、最大HPが10増加する。
        /// ステータスが0未満にならないように、減少する場合は最低値を0に設定する。
        /// </summary>
        public void AddStatus(CharacterStatusType type, int value)
        {
            switch (type)
            {
                case CharacterStatusType.MaxHp:
                    AddBaseMaxHp(value);
                    break;
                case CharacterStatusType.PhysicalAttack:
                    AddBasePhysicalAttack(value);
                    break;
                case CharacterStatusType.MagicAttack:
                    AddBaseMagicAttack(value);
                    break;
                case CharacterStatusType.PhysicalDefense:
                    AddBasePhysicalDefense(value);
                    break;
                case CharacterStatusType.MagicDefense:
                    AddBaseMagicDefense(value);
                    break;
                case CharacterStatusType.Speed:
                    AddBaseSpeed(value);
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// 基本ステータスを一括で設定するメソッド。
        /// キャラクター生成時やロード時など、複数の基本ステータスをまとめて反映したい場合に使用する。
        /// </summary>
        public void SetBaseStats(
            int maxHp,
            int physicalAttack,
            int magicAttack,
            int physicalDefense,
            int magicDefense,
            int speed)
        {
            SetBaseMaxHp(maxHp);
            SetBasePhysicalAttack(physicalAttack);
            SetBaseMagicAttack(magicAttack);
            SetBasePhysicalDefense(physicalDefense);
            SetBaseMagicDefense(magicDefense);
            SetBaseSpeed(speed);
        }

        private void SetBaseMaxHp(int value)
        {
            baseMaxHp = Mathf.Max(0, value);
        }

        private void AddBaseMaxHp(int value)
        {
            SetBaseMaxHp(baseMaxHp + value);
        }

        private void SetBasePhysicalAttack(int value)
        {
            basePhysicalAttack = Mathf.Max(0, value);
        }

        private void AddBasePhysicalAttack(int value)
        {
            SetBasePhysicalAttack(basePhysicalAttack + value);
        }

        private void SetBaseMagicAttack(int value)
        {
            baseMagicAttack = Mathf.Max(0, value);
        }

        private void AddBaseMagicAttack(int value)
        {
            SetBaseMagicAttack(baseMagicAttack + value);
        }

        private void SetBasePhysicalDefense(int value)
        {
            basePhysicalDefense = Mathf.Max(0, value);
        }

        private void AddBasePhysicalDefense(int value)
        {
            SetBasePhysicalDefense(basePhysicalDefense + value);
        }

        private void SetBaseMagicDefense(int value)
        {
            baseMagicDefense = Mathf.Max(0, value);
        }

        private void AddBaseMagicDefense(int value)
        {
            SetBaseMagicDefense(baseMagicDefense + value);
        }

        private void SetBaseSpeed(int value)
        {
            baseSpeed = Mathf.Max(0, value);
        }

        private void AddBaseSpeed(int value)
        {
            SetBaseSpeed(baseSpeed + value);
        }

        /// <summary>
        /// skills 配列全体を新しい配列で置き換えるメソッド。
        /// newSkills は必ず3つの Skill オブジェクトを含む配列でなければならない。
        /// </summary>
        /// <param name="newSkills">設定する3つのスキル配列</param>
        /// <exception cref="System.ArgumentNullException">newSkills が null の場合</exception>
        /// <exception cref="System.ArgumentException">newSkills の要素数が3でない場合、または要素のいずれかが null の場合</exception>
        public void SetSkills(Skill[] newSkills)
        {
            if (newSkills == null)
            {
                throw new System.ArgumentNullException(nameof(newSkills));
            }

            if (newSkills.Length != 3)
            {
                throw new System.ArgumentException("skills は3つである必要があります。", nameof(newSkills));
            }

            for (int i = 0; i < newSkills.Length; i++)
            {
                if (newSkills[i] == null)
                {
                    throw new System.ArgumentException($"skills[{i}] が null です。", nameof(newSkills));
                }
            }

            skills = new Skill[3];
            System.Array.Copy(newSkills, skills, 3);
        }

        /// <summary>
        /// skills 配列全体を3つのスキルで設定するメソッド。
        /// </summary>
        /// <param name="skill1">1つ目のスキル</param>
        /// <param name="skill2">2つ目のスキル</param>
        /// <param name="skill3">3つ目のスキル</param>
        /// <exception cref="System.ArgumentNullException">いずれかのスキルが null の場合</exception>
        public void SetSkills(Skill skill1, Skill skill2, Skill skill3)
        {
            if (skill1 == null)
            {
                throw new System.ArgumentNullException(nameof(skill1));
            }

            if (skill2 == null)
            {
                throw new System.ArgumentNullException(nameof(skill2));
            }

            if (skill3 == null)
            {
                throw new System.ArgumentNullException(nameof(skill3));
            }

            skills = new Skill[3] { skill1, skill2, skill3 };
        }

        /// <summary>
        /// skills 配列の特定の要素を設定するメソッド。
        /// index で指定した位置に skill を設定する。
        /// </summary>
        /// <param name="index">設定するスキルのインデックス</param>
        /// <param name="skill">設定するスキル</param>
        /// <exception cref="System.ArgumentOutOfRangeException">index が範囲外の場合</exception>
        /// <exception cref="System.ArgumentNullException">skill が null の場合</exception>
        public void SetSkill(int index, Skill skill)
        {
            if (index < 0 || index >= skills.Length)
            {
                throw new System.ArgumentOutOfRangeException(nameof(index));
            }

            if (skill == null)
            {
                throw new System.ArgumentNullException(nameof(skill));
            }

            skills[index] = skill;
        }
    }
}