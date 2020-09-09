using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {
            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");

            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            bathroom.MaxOccupancy = 3;
            roomRepo.Update(bathroom);

            Room bathroomFromDb = roomRepo.GetById(bathroom.Id);
            Console.WriteLine($"{bathroomFromDb.Id} {bathroomFromDb.Name} {bathroomFromDb.MaxOccupancy}");
            
            Console.WriteLine("-------------------------------");
            roomRepo.Delete(bathroom.Id);

            allRooms = roomRepo.GetAll();
            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }

            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);
            Console.WriteLine("Getting All Roommates:");
            Console.WriteLine();

            List<Roommate> allRoommates = roommateRepo.GetAll();

            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room.Name} {roommate.Room.MaxOccupancy} RoomId:{roommate.Room.Id}");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 1");

            Roommate singleRoommate = roommateRepo.GetById(1);

            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room.Name} {singleRoommate.Room.MaxOccupancy} RoomId:{singleRoommate.Room.Id}");

            Roommate johnny = new Roommate
            {
                Firstname = "Johnny",
                Lastname = "Walker",
                RentPortion = 20,
                MovedInDate = DateTime.Parse("Jan 1, 2020"),
                Room = roomRepo.GetById(1)
            };

            roommateRepo.Insert(johnny);
            Console.WriteLine("Before update");
            singleRoommate = roommateRepo.GetById(johnny.Id);
            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room.Name} {singleRoommate.Room.MaxOccupancy} RoomId:{singleRoommate.Room.Id}");

            johnny.Lastname = "Appleseed";
            roommateRepo.Update(johnny);
            Console.WriteLine("After Update");
            singleRoommate = roommateRepo.GetById(johnny.Id);
            Console.WriteLine($"{singleRoommate.Id} {singleRoommate.Firstname} {singleRoommate.Lastname} {singleRoommate.RentPortion} {singleRoommate.MovedInDate} {singleRoommate.Room.Name} {singleRoommate.Room.MaxOccupancy} RoomId:{singleRoommate.Room.Id}");
            
            roommateRepo.Delete(johnny.Id);

            allRoommates = roommateRepo.GetAll();
            Console.WriteLine("After Delete");
            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room.Name} {roommate.Room.MaxOccupancy} RoomId:{roommate.Room.Id}");
            }
        }
    }
}