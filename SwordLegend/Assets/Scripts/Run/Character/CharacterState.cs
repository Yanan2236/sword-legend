using System;

namespace Game.Run
{
    /// <summary>
    /// キャラクターの基本状態を管理するクラス。
    /// </summary>
    [Serializable]
    public class CharacterState
    {
        private string characterName;
        private int age;
        private CharacterStats stats;
        private CharacterSkills skills;

        public string CharacterName => characterName;
        public int Age => age;
        public CharacterStats Stats => stats;
        public CharacterSkills Skills => skills;

        public CharacterState(
            string characterName,
            int age,
            CharacterStats stats,
            CharacterSkills skills)
        {
            if (stats == null)
            {
                throw new ArgumentNullException(nameof(stats));
            }

            if (skills == null)
            {
                throw new ArgumentNullException(nameof(skills));
            }

            this.characterName = characterName;
            this.age = Math.Max(0, age);
            this.stats = stats;
            this.skills = skills;
        }

        public void SetCharacterName(string newName)
        {
            characterName = newName;
        }
        
        public void AddAge(int value)
        {
            age = Math.Max(0, age + value);
        }
    }
}