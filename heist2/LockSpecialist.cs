using System;
namespace heist2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public string Specialty { get; } = "Lock Specialist";

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is trying to open the vault. Decreased security {SkillLevel} points");
            if (bank.VaultScore <= 0) Console.WriteLine($"{Name} has cracked the safe!");
            else Console.WriteLine($"{Name} can't open the damn safe.");
        }
    }
}