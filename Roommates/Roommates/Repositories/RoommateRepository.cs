using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Roommates.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Roommates.Repositories
{
    public class RoommateRepository : BaseRepository
    {
        public RoommateRepository(string connectionString) : base(connectionString) { }
        public List<Roommate> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandText = "SELECT Id, Firstname, Lastname, RentPortion, MoveInDate, RoomId FROM Roommate";
                    //cmd.CommandText = "SELECT rm.Id, Firstname, Lastname, RentPortion, MoveInDate, r.Name FROM Roommate rm LEFT JOIN Room r on rm.RoomId = r.Id";
                    cmd.CommandText = @"
                        SELECT rm.Id, Firstname, Lastname, RentPortion, MoveInDate, r.Name, r.MaxOccupancy, rm.RoomId
                        FROM Roommate rm
                        LEFT JOIN Room r ON rm.RoomId = r.Id";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Roommate> roommates = new List<Roommate>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("Firstname");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);

                        int lastNameColumnPosition = reader.GetOrdinal("Lastname");
                        string lastNameValue = reader.GetString(lastNameColumnPosition);

                        int rentPortionColumnPosition = reader.GetOrdinal("RentPortion");
                        int rentPortionValue = reader.GetInt32(rentPortionColumnPosition);

                        int moveInDateColumnPosition = reader.GetOrdinal("MoveInDate");
                        DateTime moveInDateValue = reader.GetDateTime(moveInDateColumnPosition);

                        int roomIdColumnPosition = reader.GetOrdinal("RoomId");
                        int roomIdValue = reader.GetInt32(roomIdColumnPosition);

                        int maxOccupancyPosition = reader.GetOrdinal("MaxOccupancy");
                        int maxOccupancyValue = reader.GetInt32(maxOccupancyPosition);

                        int namePosition = reader.GetOrdinal("Name");
                        string nameValue = reader.GetString(namePosition);


                        Roommate roommate = new Roommate()
                        {
                            Id = idValue,
                            Firstname = firstNameValue,
                            Lastname = lastNameValue,
                            RentPortion = rentPortionValue,
                            MovedInDate = moveInDateValue,
                        Room = new Room()
                        {
                            Name = nameValue,
                            MaxOccupancy = maxOccupancyValue,
                            Id = roomIdValue
                        }
                        

                        };
                        roommates.Add(roommate);
                    }
                    reader.Close();

                    return roommates;
                }
            }
        }
        public Roommate GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT rm.Id, Firstname, Lastname, RentPortion, MoveInDate, r.Name, r.MaxOccupancy, rm.RoomId
                        FROM Roommate rm
                        LEFT JOIN Room r ON rm.RoomId = r.Id 
                        WHERE rm.Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Roommate roommate = null;
                    

                    if (reader.Read())
                    {
                       Room room = new Room
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("RoomId")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            MaxOccupancy = reader.GetInt32(reader.GetOrdinal("MaxOccupancy"))
                        };
                        roommate = new Roommate
                        {
                            Id = id,
                            Firstname = reader.GetString(reader.GetOrdinal("Firstname")),
                            Lastname = reader.GetString(reader.GetOrdinal("Lastname")),
                            RentPortion = reader.GetInt32(reader.GetOrdinal("RentPortion")),
                            MovedInDate = reader.GetDateTime(reader.GetOrdinal("MoveInDate")),
                            Room = room
                        };
                    }
                    reader.Close();
                    return roommate;
                }
            }
        }

        public void Insert(Roommate roommate)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Roommate (Firstname, Lastname, RentPortion, MoveInDate, RoomId)
                    OUTPUT INSERTED.Id
                    VALUES (@firstname, @lastname, @rentPortion, @moveInDate, @roomId)";
                    cmd.Parameters.AddWithValue("@firstname", roommate.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", roommate.Lastname);
                    cmd.Parameters.AddWithValue("@rentPortion", roommate.RentPortion);
                    cmd.Parameters.AddWithValue("@moveInDate", roommate.MovedInDate);
                    cmd.Parameters.AddWithValue("@roomId", roommate.Room.Id);
                    int id = (int)cmd.ExecuteScalar();
                    roommate.Id = id;
                }
            }
        }
        public void Update(Roommate roommate)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Roommate
                        SET FirstName = @firstname,
                            LastName = @lastname,
                            RentPortion = @rentPortion,
                            MoveInDate = @moveInDate,
                            RoomId = @roomid
                            WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@firstname", roommate.Firstname);
                    cmd.Parameters.AddWithValue("@lastname", roommate.Lastname);
                    cmd.Parameters.AddWithValue("@rentPortion", roommate.RentPortion);
                    cmd.Parameters.AddWithValue("@moveInDate", roommate.MovedInDate);
                    cmd.Parameters.AddWithValue("@roomid", roommate.Room.Id);
                    cmd.Parameters.AddWithValue("@id", roommate.Id);

                    cmd.ExecuteNonQuery();


                }
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Roommate
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}