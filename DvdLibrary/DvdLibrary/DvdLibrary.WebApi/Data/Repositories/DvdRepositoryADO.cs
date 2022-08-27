using DvdLibrary.WebApi.Data.Interfaces;
using DvdLibrary.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibrary.WebApi.Data.Repositories
{
    public class DvdRepositoryADO : IDvdsRepository
    {
        public void Create(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CreateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@DvdId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);

                if (string.IsNullOrEmpty(dvd.Notes))
                {
                    cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Notes", dvd.Notes);
                }

                cn.Open();

                cmd.ExecuteNonQuery();

                dvd.DvdId = (int)param.Value;
            }
        }

        public void Delete(int dvdId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Dvd> GetAllDvds()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Dvd> dvds = new List<Dvd>();
                SqlCommand cmd = new SqlCommand("GetAllDvds", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }

                return dvds;
            }
        }

        public Dvd GetDvdById(int dvdId)
        {
            Dvd dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvdId);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new Dvd();
                        dvd.DvdId = (int)dr["DvdId"];
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.Title = dr["Title"].ToString();
                        dvd.ReleaseYear = (int)dr["ReleaseYear"];
                        dvd.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                        else
                        {
                            dvd.Notes = "";
                        }
                    }
                }

            }

            return dvd;
        }

        public List<Dvd> GetDvdsByDirector(string director)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Dvd> dvds = new List<Dvd>();
                SqlCommand cmd = new SqlCommand("GetDvdsByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", director);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }

                return dvds;
            }
        }

        public List<Dvd> GetDvdsByRating(string rating)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Dvd> dvds = new List<Dvd>();
                SqlCommand cmd = new SqlCommand("GetDvdsByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", rating);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }

                return dvds;
            }
        }

        public List<Dvd> GetDvdsByReleaseYear(int releaseYear)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Dvd> dvds = new List<Dvd>();
                SqlCommand cmd = new SqlCommand("GetDvdsByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }

                return dvds;
            }
        }

        public List<Dvd> GetDvdsByTitle(string title)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                List<Dvd> dvds = new List<Dvd>();
                SqlCommand cmd = new SqlCommand("GetDvdsByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", title);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Dvd currentRow = new Dvd();
                        currentRow.DvdId = (int)dr["DvdId"];
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        dvds.Add(currentRow);
                    }
                }

                return dvds;
            }
        }

        public void Update(Dvd dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}