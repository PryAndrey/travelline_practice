using Fighters.Models.Fighters;

namespace Fighters.GameHandler
{
    public class WarriorCountException : Exception
    {
        public WarriorCountException() : base() { }

        public WarriorCountException(string message) : base(message) { }

        public WarriorCountException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class GameMaster
    {
        public IFighter PlayAndGetWinner(List<Fighter> fighters)
        {
            if (fighters.Count == 0)
            {
                throw new WarriorCountException($"There are no participants");
            }
            if (fighters.Count == 1)
            {
                return fighters[0];
            }
            int round = 1;
            while (true)
            {
                Console.WriteLine($"Round {round++}.");

                CalculateAimsSelection(fighters);

                CalculateInitiative(fighters);

                CalculateStep(fighters);

                FightIteration(fighters);

                if (fighters.Count == 1)
                {
                    return fighters[0];
                }

                Console.WriteLine();
            }
        }

        private void FightIteration(List<Fighter> fighters)
        {
            List<int> killedList = new List<int>();
            List<Tuple<int, int>> posList = new List<Tuple<int, int>>();
            for (int i = 0; i < fighters.Count; i++)
            {
                posList.Add(Tuple.Create(fighters[i].CurrentInitiative, i));
            }
            posList.Sort((p1, p2) => p1.Item1.CompareTo(p2.Item1));

            for (int i = 0; i < posList.Count; i++)
            {
                if (fighters[posList[i].Item2].CurrentHealth == 0)
                {
                    continue;
                }
                IFighter fighter = fighters[posList[i].Item2];
                IFighter fighterAim = fighters[fighter.CurrentAim];

                int aimInitiative = fighterAim.CurrentInitiative - 1;
                int coeffOfDifference = fighter.CurrentInitiative / aimInitiative;
                int damage = fighter.CalculateDamage(coeffOfDifference);

                bool alreadykilled = false;
                if (fighterAim.CurrentHealth == 0)
                {
                    alreadykilled = true;
                }

                fighterAim.TakeDamage(damage);
                if (fighterAim.CurrentHealth == 0 && !alreadykilled)
                {
                    killedList.Add(fighter.CurrentAim);
                }

                Console.WriteLine(
                    $"Warrior {fighterAim.Name} get " +
                    $"{Math.Max(damage - fighterAim.MaxArmor, 1)} damage from {fighter.Name}. " +
                    $"Remaining HP: {fighterAim.CurrentHealth} / {fighterAim.MaxHealth}");
            }
            killedList.Sort((k1, k2) => k2.CompareTo(k1));
            for (int i = 0; i < killedList.Count; i++)
            {
                fighters.RemoveAt(killedList[i]);
            }
        }

        private void CalculateStep(List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].CurrentHealth == 0)
                {
                    continue;
                }
                int xEnemy = fighters[fighters[i].CurrentAim].X;
                int yEnemy = fighters[fighters[i].CurrentAim].Y;
                fighters[i].CalculateCoords(xEnemy, yEnemy);
            }
        }

        private void CalculateInitiative(List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].CurrentHealth == 0)
                {
                    continue;
                }
                int xEnemy = fighters[fighters[i].CurrentAim].X;
                int yEnemy = fighters[fighters[i].CurrentAim].Y;
                int x = fighters[i].X;
                int y = fighters[i].Y;
                double distance = Math.Sqrt(Math.Pow(x - xEnemy, 2) + Math.Pow(y - yEnemy, 2));
                fighters[i].CalculateInitiative(distance);
            }
        }

        private void CalculateAimsSelection(List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].CurrentHealth != 0)
                {
                    fighters[i].SelectionAim(fighters.Count, i);
                }
            }
        }
    }
}