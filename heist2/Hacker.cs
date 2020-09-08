using System;
namespace heist2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Hacker";
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points");
            if (bank.AlarmScore <= 0) Console.WriteLine($"{Name} has disabled the alarm system!");
            else Console.WriteLine($"{Name} has failed to disable the alarm system.");
        }
    }
}