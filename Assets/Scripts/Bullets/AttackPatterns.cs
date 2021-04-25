using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AttackPattern = System.Collections.Generic.IList<Bullets.AttackStep>;

namespace Bullets
{
    public static class AttackPatterns
    {
        public static AttackStep GetNextAttackStep(AttackPatternType pattern, int stepNumber)
        {
            if (!_attackPatterns.ContainsKey(pattern))
            {
                // ReSharper disable once StringLiteralTypo
                throw new ArgumentException($"Welp, you dun goofed. Ain't no such {pattern} pattern.");
            }
            AttackPattern attackPattern = _attackPatterns[pattern];
            return attackPattern[stepNumber % attackPattern.Count];
        }

        private static readonly IDictionary<AttackPatternType, AttackPattern> _attackPatterns = new Dictionary<AttackPatternType, AttackPattern>
        {
                {
                        AttackPatternType.Cross, new List<AttackStep>
                        {
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(1f, 0f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(-1f, 0f), ProjectileType.Normal),
                                }, 2),
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(0f, 1f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(0f, -1f), ProjectileType.Normal),
                                }, 10),
                        }
                },
        };
    }

    public readonly struct AttackStep
    {
        public IList<ProjectileAttack> ProjectileAttacks { get; }
        public float StepDelay { get; }

        public AttackStep(IList<ProjectileAttack> attackSteps, float stepDelay)
        {
            ProjectileAttacks = attackSteps.ToList();
            StepDelay = stepDelay;
        }
    }

    public readonly struct ProjectileAttack
    {
        public ProjectileAttack(Vector2 trajectory, ProjectileType type) { }
    }
}
