using DogGo.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalkRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Walk> GetAllWalks()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Date, Duration, WalkerId, DogId
                        FROM Walk
                    ";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Walk> owners = new List<Walk>();
                    while (reader.Read())
                    {
                        Walk owner = new Walk
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId"))
                        };

                        owners.Add(owner);
                    }

                    reader.Close();

                    return owners;
                }
            }
        }

        public List<Walk> GetWalksByWalkerId (int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT w.Id, Date, Duration, WalkerId, DogId, d.Name, o.Name as OwnerName, wr.Name as WalkerName, wr.ImageUrl, n.Name as NeighborhoodName
                        FROM Walk w
                        LEFT JOIN Dog d ON w.DogId = d.Id
                        LEFT JOIN Owner o ON d.OwnerId = o.Id
                        LEFT JOIN Walker wr ON w.WalkerId = wr.Id
                        LEFT JOIN Neighborhood n ON wr.NeighborhoodId = n.Id
                        WHERE wr.Id = @id
                        ORDER BY o.Name
                    ";
                    cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Walk> walks = new List<Walk>();
                    while (reader.Read())
                    {
                        
                        Owner owner = new Owner
                        {
                            Name = reader.GetString(reader.GetOrdinal("OwnerName"))
                        };

                        Neighborhood neighborhood = new Neighborhood
                        {
                            Name = reader.GetString(reader.GetOrdinal("NeighborhoodName"))
                        };
                        
                        Walker walker = new Walker
                        {
                            Name = reader.GetString(reader.GetOrdinal("WalkerName")),
                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                            Neighborhood = neighborhood,
                            
                        };
                        Dog dog = new Dog
                        {
                            Owner = owner
                        };
                        Walk walk = new Walk
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId")),
                            DogId = reader.GetInt32(reader.GetOrdinal("DogId")),
                            Dog = dog,
                            Walker = walker
                        };
                        

                        walks.Add(walk);
                    }

                    reader.Close();

                    return walks;
                
                }
            }
        }

//        public Walk GetWalkById(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        SELECT Id, [Name], ImageUrl, NeighborhoodId
//                        FROM Walk
//                        WHERE Id = @id
//                    ";

//                    cmd.Parameters.AddWithValue("@id", id);

//                    SqlDataReader reader = cmd.ExecuteReader();

//                    if (reader.Read())
//                    {
//                        Walk owner = new Walk
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            Name = reader.GetString(reader.GetOrdinal("Name")),
//                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
//                            NeighborhoodId = reader.GetInt32(reader.GetOrdinal("NeighborhoodId"))
//                        };

//                        reader.Close();
//                        return owner;
//                    }
//                    else
//                    {
//                        reader.Close();
//                        return null;
//                    }
//                }
//            }
//        }
//        public List<Walk> GetWalksInNeighborhood(int neighborhoodId)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                SELECT Id, [Name], ImageUrl, NeighborhoodId
//                FROM Walk
//                WHERE NeighborhoodId = @neighborhoodId
//            ";

//                    cmd.Parameters.AddWithValue("@neighborhoodId", neighborhoodId);

//                    SqlDataReader reader = cmd.ExecuteReader();

//                    List<Walk> walks = new List<Walk>();
//                    while (reader.Read())
//                    {
//                        Walk walk = new Walk
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            Name = reader.GetString(reader.GetOrdinal("Name")),
//                            ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
//                            NeighborhoodId = reader.GetInt32(reader.GetOrdinal("NeighborhoodId"))
//                        };

//                        walks.Add(walk);
//                    }

//                    reader.Close();

//                    return walks;
//                }
//            }
//        }
    }
}
