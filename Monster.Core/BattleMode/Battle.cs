using Monster.Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Monster.Core.Models
{
    public enum AttackType
    {
        Attack1,   // 100% chance, 20 damage
        Attack2,   // 50% chance, 40 damage
        Attack3     // 20% chance, 80 damage
    }

    public class BattleResult
    {
        public bool WasHit { get; set; }
        public int DamageDealt { get; set; }
        public int EnemyHP { get; set; }
        public bool EnemyCountered { get; set; }
        public int CounterDamage { get; set; }
        public int MyMonsterHP { get; set; }
    }

    public class BattleOutcome
    {
        public bool Victory { get; set; }
        public required List<Item> Rewards { get; set; }
        public int MyMonsterHP { get; set; }
        public int EnemyHP { get; set; }
        public int ExperienceGained { get; set; }
    }

    public class Battle
    {
        private Random _random = new Random();
        private List<Item> _possibleRewards;

        public Monster MyMonster { get; }
        public Monster Enemy { get; }

        public Battle(Monster myMonster, Monster enemy)
        {
            MyMonster = myMonster ?? throw new ArgumentNullException(nameof(myMonster));
            Enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _possibleRewards = Inventory.LoadItems();
        }

        public BattleResult ExecuteAttack(AttackType attackType)
        {
            int damage = 0;
            bool hit = false;
            string attackMessage = "";
            bool enemyCountered = false;
            int counterDamage = 0;

            switch (attackType)
            {
                case AttackType.Attack1:
                    damage = 20;
                    hit = true;
                    attackMessage = $"{MyMonster.Name} roars at {Enemy.Name}!";
                    break;

                case AttackType.Attack2:
                    if (_random.NextDouble() <= 0.5)
                    {
                        damage = 40;
                        hit = true;
                        attackMessage = $"{MyMonster.Name} breathes fire on {Enemy.Name}!";
                    }
                    else
                    {
                        attackMessage = $"{MyMonster.Name}'s fire attack missed!";
                    }
                    break;

                case AttackType.Attack3:
                    if (_random.NextDouble() <= 0.2)
                    {
                        damage = 80;
                        hit = true;
                        attackMessage = $"{MyMonster.Name} swoops down on {Enemy.Name}!";
                    }
                    else
                    {
                        attackMessage = $"{MyMonster.Name}'s fly attack missed!";
                    }
                    break;
            }

            if (hit)
            {
                double reactionRoll = _random.NextDouble();

                switch (attackType)
                {
                    case AttackType.Attack1:
                        Enemy.HP -= damage;
                        break;

                    case AttackType.Attack2:
                        if (reactionRoll <= 0.5)
                        {
                            Enemy.HP -= damage;
                        }
                        else
                        {
                            Enemy.HP -= (int)(damage * 0.5);
                            counterDamage = (int)(damage * 0.25);
                            MyMonster.HP -= counterDamage;
                            enemyCountered = true;
                        }
                        break;

                    case AttackType.Attack3:
                        if (reactionRoll <= 0.3)
                        {
                            Enemy.HP -= damage;
                        }
                        else
                        {
                            Enemy.HP -= (int)(damage * 0.3);
                            counterDamage = (int)(damage * 0.35);
                            MyMonster.HP -= counterDamage;
                            enemyCountered = true;
                        }
                        break;
                }

                if (Enemy.HP < 0) Enemy.HP = 0;
                if (MyMonster.HP < 0) MyMonster.HP = 0;

                attackMessage += $" It deals {damage} damage!";

                if (enemyCountered)
                {
                    attackMessage += $"\n{Enemy.Name} counter-attacks for {counterDamage} damage!";
                }
            }

            return new BattleResult
            {
                WasHit = hit,
                DamageDealt = damage,
                EnemyHP = Enemy.HP,
                EnemyCountered = enemyCountered,
                CounterDamage = counterDamage,
                MyMonsterHP = MyMonster.HP
            };
        }

        public bool IsBattleOver()
        {
            return Enemy.HP <= 0 || MyMonster.HP <= 0;
        }

        public string GetBattleStatus()
        {
            return $"{MyMonster.Name}: HP {MyMonster.HP}\n" +
                   $"{Enemy.Name}: HP {Enemy.HP}";
        }

        public BattleOutcome ConcludeBattle()
        {
            bool victory = Enemy.HP <= 0;
            var rewards = victory ? GetBattleRewards() : new List<Item>();
            int expGained = 0;

            if (victory)
            {
                expGained = CalculateAndApplyExperienceGained(); 
            }

            return new BattleOutcome
            {
                Victory = victory,
                Rewards = rewards,
                MyMonsterHP = MyMonster.HP,
                EnemyHP = Enemy.HP,
                ExperienceGained = expGained 
            };
        }

        private List<Item> GetBattleRewards()
        {
            var rewards = new List<Item>();
            var tempRewardPool = new List<Item>();

            // First check for energy drink (10% chance)
            var energyDrink = _possibleRewards.FirstOrDefault(i =>
                i.Name.Equals("energy drink", StringComparison.OrdinalIgnoreCase));
            if (energyDrink != null && _random.NextDouble() <= 0.1)
            {
                rewards.Add(energyDrink.Clone());
            }

            // Categorize other items by their effect strength
            foreach (var item in _possibleRewards)
            {
                if (item.Name.Equals("energy drink", StringComparison.OrdinalIgnoreCase))
                    continue;

                int effectSum = item.Effects.Values.Sum();

                if (effectSum == 10 && _random.NextDouble() <= 0.9)
                {
                    tempRewardPool.Add(item.Clone());
                }
                else if (effectSum == 20 && _random.NextDouble() <= 0.7)
                {
                    tempRewardPool.Add(item.Clone());
                }
                else if (effectSum == 50 && _random.NextDouble() <= 0.25)
                {
                    tempRewardPool.Add(item.Clone());
                }
            }

            // Shuffle and select up to 4 items (including energy drink if present)
            var shuffled = tempRewardPool.OrderBy(x => _random.Next()).ToList();
            int maxToTake = Math.Min(4 - rewards.Count, shuffled.Count);

            rewards.AddRange(shuffled.Take(maxToTake));

            return rewards;
        }

        private int CalculateAndApplyExperienceGained()
        {
            // Calculate XP (base 50 + 20% of enemy's max HP)
            int gainedXP = 50 + (int)(Enemy.HP * 0.2);

            // Add to monster's experience
            MyMonster.ExperiencePoints += gainedXP;

            // Return the amount for display purposes
            return gainedXP;
        }
    }
}