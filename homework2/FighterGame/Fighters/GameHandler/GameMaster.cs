using Fighters.Models.Fighters;
using System.Diagnostics;

namespace Fighters.GameHandler
{
    public class GameMaster
    {
        public class WarriorCountException : Exception
        {
            public WarriorCountException() : base() { }

            public WarriorCountException(string message) : base(message) { }

            public WarriorCountException(string message, Exception innerException) : base(message, innerException) { }
        }

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
                CalculateAimsSelection( fighters);
                CalculateInitiative( fighters);
                CalculateStep( fighters);
                FightIteration( fighters);
                if (fighters.Count == 1)
                {
                    return fighters[0];
                }

                Console.WriteLine();
            }

            //throw new UnreachableException();
        }

        private void FightIteration( List<Fighter> fighters)
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
                int damage = fighters[posList[i].Item2].CalculateDamage(fighters[posList[i].Item2].CurrentInitiative / (fighters[fighters[posList[i].Item2].CurrentAim].CurrentInitiative - 1));
                bool alreadykilled = false;
                if (fighters[fighters[posList[i].Item2].CurrentAim].CurrentHealth == 0)
                {
                    alreadykilled = true;
                }
                fighters[fighters[posList[i].Item2].CurrentAim].TakeDamage(damage);
                if (fighters[fighters[posList[i].Item2].CurrentAim].CurrentHealth == 0 && !alreadykilled)
                {
                    killedList.Add(fighters[posList[i].Item2].CurrentAim);
                }
                Console.WriteLine(
                    $"Warrior {fighters[fighters[posList[i].Item2].CurrentAim].Name} get " +
                    $"{Math.Max(damage - fighters[fighters[posList[i].Item2].CurrentAim].MaxArmor, 1)} damage from {fighters[posList[i].Item2].Name}. " +
                    $"Remaining HP: {fighters[fighters[posList[i].Item2].CurrentAim].CurrentHealth} / {fighters[fighters[posList[i].Item2].CurrentAim].MaxHealth}");
            }
            killedList.Sort((k1, k2) => k2.CompareTo(k1));
            for (int i = 0; i < killedList.Count; i++)
            {
                fighters.RemoveAt(killedList[i]);
            }
        }

        private void CalculateStep( List<Fighter> fighters)
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

        private void CalculateInitiative( List<Fighter> fighters)
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

        private void CalculateAimsSelection( List<Fighter> fighters)
        {
            for (int i = 0; i < fighters.Count; i++)
            {
                if (fighters[i].CurrentHealth != 0)
                {
                    fighters[i].AimSelection(fighters.Count, i);
                }
            }
        }
    }
}