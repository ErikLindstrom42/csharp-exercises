using System;
namespace heist2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is fighting the guards. Decreased security {SkillLevel} points");
            if (bank.AlarmScore <= 0) Console.WriteLine($"{Name} has beaten the crap out of the guards!");
            else Console.WriteLine($"{Name} got beaten up by the guards and has failed.");
        }
    }
}