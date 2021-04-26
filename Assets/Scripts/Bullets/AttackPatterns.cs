using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AttackPattern = System.Collections.Generic.List<Bullets.AttackStep>;

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
                #region AttackPattern Cross

                {
                        AttackPatternType.Cross, new List<AttackStep>
                        {
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(1f, 0f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(-1f, 0f), ProjectileType.Normal),
                                }, .7f),
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(0f, 1f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(0f, -1f), ProjectileType.Normal),
                                }, .7f),
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(1f, 0f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(-1f, 0f), ProjectileType.Normal),
                                }, .7f),
                                new AttackStep(new List<ProjectileAttack>
                                {
                                        new ProjectileAttack(new Vector2(0f, 1f), ProjectileType.Normal),
                                        new ProjectileAttack(new Vector2(0f, -1f), ProjectileType.Normal),
                                }, 4f),
                        }
                },

                #endregion

                #region AttackPattern WazerWall

                {
                        AttackPatternType.WazerWall, new List<AttackStep>
                        {
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 0.05f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(Vector2.zero, ProjectileType.WazerBeam, false)}, 7.2f),
                        }
                },

                #endregion

                #region AttackPattern FireSpiral

                {
                        AttackPatternType.FireSpiral, new List<AttackStep>
                        {
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(900), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(879), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(858), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(837), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(816), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(795), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(774), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(753), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(732), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(711), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(690), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(669), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(648), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(627), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(606), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(585), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(564), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(543), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(522), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(501), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(480), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(459), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(438), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(417), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(396), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(375), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(354), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(333), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(312), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(291), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(270), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(249), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(228), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(207), ProjectileType.FireBall)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(186), ProjectileType.FireBall)}, 11f),
                        }
                },

                #endregion

                #region AttackPattern CounterClockwiseOrbWall

                {
                        AttackPatternType.CounterClockwiseOrbWall, new List<AttackStep>
                        {
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(0), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(1), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(2), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(3), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(4), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(5), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(6), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(7), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(8), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(9), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(10), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(11), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(12), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(13), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(14), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(15), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(16), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(17), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(18), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(19), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(20), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(21), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(22), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(23), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(24), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(25), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(26), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(27), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(28), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(29), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(30), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(31), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(32), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(33), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(34), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(35), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(36), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(37), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(38), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(39), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(40), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(41), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(42), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(43), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(44), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(45), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(46), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(47), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(48), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(49), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(50), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(51), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(52), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(53), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(54), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(55), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(56), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(57), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(58), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(59), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(60), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(61), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(62), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(63), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(64), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(65), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(66), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(67), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(68), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(69), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(70), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(71), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(72), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(73), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(74), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(75), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(76), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(77), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(78), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(79), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(80), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(81), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(82), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(83), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(84), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(85), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(86), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(87), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(88), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(89), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(90), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(91), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(92), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(93), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(94), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(95), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(96), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(97), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(98), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(99), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(100), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(101), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(102), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(103), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(104), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(105), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(106), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(107), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(108), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(109), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(110), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(111), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(112), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(113), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(114), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(115), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(116), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(117), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(118), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(119), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(120), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(121), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(122), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(123), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(124), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(125), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(126), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(127), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(128), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(129), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(130), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(131), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(132), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(133), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(134), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(135), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(136), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(137), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(138), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(139), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(140), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(141), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(142), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(143), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(144), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(145), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(146), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(147), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(148), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(149), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(150), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(151), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(152), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(153), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(154), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(155), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(156), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(157), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(158), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(159), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(160), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(161), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(162), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(163), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(164), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(165), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(166), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(167), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(168), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(169), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(170), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(171), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(172), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(173), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(174), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(175), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(176), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(177), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(178), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(179), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(180), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(181), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(182), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(183), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(184), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(185), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(186), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(187), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(188), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(189), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(190), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(191), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(192), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(193), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(194), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(195), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(196), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(197), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(198), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(199), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(200), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(201), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(202), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(203), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(204), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(205), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(206), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(207), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(208), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(209), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(210), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(211), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(212), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(213), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(214), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(215), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(216), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(217), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(218), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(219), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(220), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(221), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(222), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(223), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(224), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(225), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(226), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(227), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(228), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(229), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(230), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(231), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(232), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(233), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(234), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(235), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(236), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(237), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(238), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(239), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(240), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(241), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(242), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(243), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(244), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(245), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(246), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(247), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(248), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(249), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(250), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(251), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(252), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(253), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(254), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(255), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(256), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(257), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(258), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(259), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(260), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(261), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(262), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(263), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(264), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(265), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(266), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(267), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(268), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(269), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(270), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(271), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(272), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(273), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(274), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(275), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(276), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(277), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(278), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(279), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(280), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(281), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(282), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(283), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(284), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(285), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(286), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(287), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(288), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(289), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(290), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(291), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(292), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(293), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(294), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(295), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(296), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(297), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(298), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(299), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(300), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(301), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(302), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(303), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(304), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(305), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(306), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(307), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(308), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(309), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(310), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(311), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(312), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(313), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(314), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(315), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(316), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(317), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(318), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(319), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(320), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(321), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(322), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(323), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(324), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(325), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(326), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(327), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(328), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(329), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(330), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(331), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(332), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(333), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(334), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(335), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(336), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(337), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(338), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(339), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(340), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(341), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(342), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(343), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(344), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(345), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(346), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(347), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(348), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(349), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(350), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(351), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(352), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(353), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(354), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(355), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(356), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(357), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(358), ProjectileType.Orb)}, 0.1f),
                                new AttackStep(new List<ProjectileAttack> {new ProjectileAttack(FromDegree(359), ProjectileType.Orb)}, 27f),
                        }
                },

                #endregion
        };

        private static Vector2 FromRadian(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }

        private static Vector2 FromDegree(float degree)
        {
            return FromRadian(degree * Mathf.Deg2Rad);
        }
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
        public Vector2 Trajectory { get; }
        public ProjectileType Type { get; }
        public bool PlayAudio { get; }

        public ProjectileAttack(Vector2 trajectory, ProjectileType type, bool playAudio = true)
        {
            Trajectory = trajectory;
            Type = type;
            PlayAudio = playAudio;
        }
    }
}
