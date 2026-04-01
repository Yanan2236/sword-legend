using UnityEngine;
using System;

namespace Game.Run
{
    [Serializable]
    public class CharacterSkills
    {
        private Skill[] skills;

        public int Count => skills.Length;

        /// <summary>
        /// キャラクターが持つスキルの配列を取得するプロパティ。
        /// 外部からの変更を防ぐため、配列のコピーを返す。
        /// </summary>
        public Skill[] Skills
        {
            get
            {
                Skill[] copy = new Skill[skills.Length];
                Array.Copy(skills, copy, skills.Length);
                return copy;
            }
        }

        public CharacterSkills(Skill[] skills)
        {
            SetSkills(skills);
        }

        /// <summary>
        /// 指定したインデックスのスキルを取得するメソッド。
        /// </summary>
        /// <param name="index">取得するスキルのインデックス</param>
        /// <returns>指定したインデックスのスキル</returns>
        /// <exception cref="ArgumentOutOfRangeException">index が範囲外の場合</exception>
        public Skill GetSkill(int index)
        {
            if (index < 0 || index >= skills.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return skills[index];
        }

        /// <summary>
        /// キャラクターが特定のスキルを持っているかを確認するメソッド。
        /// </summary>
        /// <param name="skill">確認するスキル</param>
        /// <returns>スキルを持っている場合は true、持っていない場合は false</returns>
        /// <exception cref="ArgumentNullException">skill が null の場合</exception>
        public bool HasSkill(Skill skill)
        {
            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
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

        /// <summary>
        /// キャラクターのスキルを一括で設定するメソッド。
        /// </summary>
        /// <param name="newSkills">設定するスキルの配列</param>
        /// <exception cref="ArgumentNullException">newSkills が null の場合</exception>
        /// <exception cref="ArgumentException">newSkills の要素数が3でない場合、または要素に null が含まれる場合</exception>
        public void SetSkills(Skill[] newSkills)
        {
            if (newSkills == null)
            {
                throw new ArgumentNullException(nameof(newSkills));
            }

            if (newSkills.Length != 3)
            {
                throw new ArgumentException("skills は3つである必要があります。", nameof(newSkills));
            }

            for (int i = 0; i < newSkills.Length; i++)
            {
                if (newSkills[i] == null)
                {
                    throw new ArgumentException($"skills[{i}] が null です。", nameof(newSkills));
                }
            }

            skills = new Skill[3];
            Array.Copy(newSkills, skills, 3);
        }

        /// <summary>
        /// 指定したインデックスのスキルを設定するメソッド。
        /// </summary>
        /// <param name="index">設定するスキルのインデックス</param>
        /// <param name="skill">設定するスキル</param>
        /// <exception cref="ArgumentOutOfRangeException">index が範囲外の場合</exception>
        /// <exception cref="ArgumentNullException">skill が null の場合</exception>
        public void SetSkill(int index, Skill skill)
        {
            if (index < 0 || index >= skills.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            if (skill == null)
            {
                throw new ArgumentNullException(nameof(skill));
            }

            skills[index] = skill;
        }
    }
}