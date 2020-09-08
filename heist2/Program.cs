using System;
using System.Collections.Generic;
using System.Linq;

namespace heist2
{
    class Program
    {
        static void Main(string[] args)
        {
            Hacker peacock = new Hacker()
            {
                Name = "Mrs. Peacock",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker white = new Hacker()
            {
                Name = "Mrs. White",
                SkillLevel = 50,
                PercentageCut = 10

            };
            Muscle plum = new Muscle()
            {
                Name = "Professor Plum",
                SkillLevel = 50,
                PercentageCut = 10

            };
            Muscle boddy = new Muscle()
            {
                Name = "Mr. Boddy",
                SkillLevel = 50,
                PercentageCut = 90
            };
            LockSpecialist mustard = new LockSpecialist()
            {
                Name = "Colonel Mustard",
                SkillLevel = 50,
                PercentageCut = 10

            };
            LockSpecialist scarlet = new LockSpecialist()
            {
                Name = "Miss Scarlet",
                SkillLevel = 50,
                PercentageCut = 10
            };
            List<IRobber> rolodex = new List<IRobber>()
            {
                peacock, plum, white, boddy, mustard, scarlet
            };

            string name = null;
            string speciality;
            int skillLevel;
            int cut;
            string selectedRecruit = null;
            Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex");

            while (name != "")
            {
                Console.WriteLine("Please a name for the new recruit, or submit a blank entry to proceed to selection");
                name = Console.ReadLine();
                if (name == "") break;
                Console.WriteLine("Please select a speciality for the new recuit:");
                Console.WriteLine("1) Hacker (Disables alarms)");
                Console.WriteLine("2) Muscle (Disarms guards)");
                Console.WriteLine("3) Lock Specialist (cracks vault)");
                speciality = Console.ReadLine();
                Console.WriteLine("Enter the recruits skill level:");
                skillLevel = Int32.Parse(Console.ReadLine());
                Console.WriteLine("What cut does the recruit demand for their services?");
                cut = Int32.Parse(Console.ReadLine());
                if (speciality == "1")
                {
                    Hacker newGuy = new Hacker();
                    newGuy.Name = name;
                    newGuy.SkillLevel = skillLevel;
                    newGuy.PercentageCut = cut;
                    rolodex.Add(newGuy);
                }
                else if (speciality == "2")
                {
                    Muscle newGuy = new Muscle();
                    newGuy.Name = name;
                    newGuy.SkillLevel = skillLevel;
                    newGuy.PercentageCut = cut;
                    rolodex.Add(newGuy);
                }
                else if (speciality == "3")
                {
                    LockSpecialist newGuy = new LockSpecialist();
                    newGuy.Name = name;
                    newGuy.SkillLevel = skillLevel;
                    newGuy.PercentageCut = cut;
                    rolodex.Add(newGuy);
                }

            }

            Bank targetBank = new Bank()
            {
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(50000, 10000000)
            };
            // Console.WriteLine($"Alarm: {targetBank.AlarmScore}");
            // Console.WriteLine($"Vault: {targetBank.VaultScore}");
            // Console.WriteLine($"Security: {targetBank.SecurityGuardScore}");
            targetBank.MostSecure();
            targetBank.LeastSecure();

            List<IRobber> crew = new List<IRobber>();
            while (selectedRecruit != "")
            {
                foreach (IRobber robber in rolodex.ToList())
                {
                    if (robber.PercentageCut > (100 - crew.Sum(item => item.PercentageCut)))
                    {
                        rolodex.Remove(robber);
                    }
                }
                for (int i = 0; i < rolodex.Count; i++)
                {
                    Console.WriteLine($"{i}) {rolodex[i].Name}");
                    Console.WriteLine($"Specialty: {rolodex[i].Specialty}");
                    Console.WriteLine($"Skill Level:{rolodex[i].SkillLevel}");
                    Console.WriteLine($"Percent cut of the take: {rolodex[i].PercentageCut}\n");

                }
                Console.WriteLine("Please select your recruit ID from the list above or submit a blank entry to start the heist.");
                selectedRecruit = Console.ReadLine();
                if (selectedRecruit == "") break;
                crew.Add(rolodex[Int32.Parse(selectedRecruit)]);
                rolodex.Remove(rolodex[Int32.Parse(selectedRecruit)]);
                Console.WriteLine($"Total appropriated cut is {crew.Sum(item => item.PercentageCut)}");
            }
            foreach (IRobber robber in crew)
            {
                robber.PerformSkill(targetBank);
                Console.WriteLine($"{robber.Name} used their {robber.Specialty} skills");
            }
            if (targetBank.IsSecure)
            {
                Console.WriteLine($"The bank resisted the attempt! AlarmScore: {targetBank.AlarmScore}, VaultScore: {targetBank.VaultScore}, SecurityGuardScore: {targetBank.SecurityGuardScore}");
            }
            else
            {
                Console.WriteLine($"The bank was robbed! AlarmScore: {targetBank.AlarmScore}, VaultScore: {targetBank.VaultScore}, SecurityGuardScore: {targetBank.SecurityGuardScore}");
                double myCut = ((100 - crew.Sum(item => item.PercentageCut)) * targetBank.CashOnHand) / 100;
                Console.WriteLine($"Your crew stole ${targetBank.CashOnHand}. After paying all of them you get ${myCut}");
            }

        }
    }
}