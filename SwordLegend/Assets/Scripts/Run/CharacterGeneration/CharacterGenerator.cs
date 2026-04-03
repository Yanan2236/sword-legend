using UnityEngine;
using System;

namespace Game.Run
{
    /// <summary>
    /// キャラクターの状態を生成するためのクラス。
    /// キャラクターの名前、年齢、ステータス、スキルなどをまとめて管理する。
    /// キャラクター生成時に必要な情報を引数として受け取り、CharacterState オブジェクトを生成する。
    /// </summary>
    public class CharacterGenerator
    {
        /// <summary>
        /// キャラクター生成に使用するランダム生成器。
        /// </summary>
        private System.Random random = new System.Random();

        /// <summary>
        /// キャラクターの状態を生成する。
        /// </summary>
        /// <returns>生成されたキャラクターの状態</returns>
        public CharacterState GenerateCharacter()
        {
            CharacterStats stats = GenerateBaseStats();
            CharacterSkills skills = new CharacterSkills(
                new Skill[]
                {
                    // 開発前のため、スキルは空のスキルオブジェクトを使用
                    new Skill(),
                    new Skill(),
                    new Skill()
                }
            );
            LifeHistoryEvent childhoodEvent = DrawChildhoodEvent();
            LifeHistoryEvent teenEvent = DrawTeenEvent();

            ApplyEvent(stats, childhoodEvent);
            ApplyEvent(stats, teenEvent);

            return new CharacterState(
                characterName: "主人公", // 開発前のため、名前は固定の値を使用
                age: 18,                // 開発前のため、年齢は固定の値を使用
                stats: stats,
                skills: skills,
                childhoodEvent: childhoodEvent,
                teenEvent: teenEvent
            );
        }

        /// <summary>
        /// キャラクターの基本ステータスを生成する。
        /// 現段階では、固定の値を返すだけの簡単な実装になっている。
        /// </summary>
        private CharacterStats GenerateBaseStats()
        {
            return new CharacterStats(
                maxHp: 100,
                physicalAttack: 10,
                magicAttack: 10,
                physicalDefense: 3,
                magicDefense: 3,
                speed: 10
            );
        }

        /// <summary>
        /// 履歴イベントをキャラクターのステータスに適用する。
        /// </summary>
        /// <param name="stats">適用先のキャラクターステータス。</param>
        /// <param name="lifeHistoryEvent">適用する履歴イベント。</param>
        private void ApplyEvent(CharacterStats stats, LifeHistoryEvent lifeHistoryEvent)
        {
            foreach (StatusModifier modifier in lifeHistoryEvent.Modifiers)
            {
                stats.AddStatus(modifier.Type, modifier.Value);
            }
        }

        /// <summary>
        /// 幼少期イベントを抽選する。
        /// </summary>
        /// <returns>抽選された幼少期イベント</returns>
        private LifeHistoryEvent DrawChildhoodEvent()
        {
            return ChildhoodEvents.GetRandomEvent(random);
        }

        /// <summary>
        /// 高校生期イベントを抽選する。
        /// </summary>
        /// <returns>抽選された高校生期イベント</returns>
        private LifeHistoryEvent DrawTeenEvent()
        {
            return TeenEvents.GetRandomEvent(random);
        }
    }
}