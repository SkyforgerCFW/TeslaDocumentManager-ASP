using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TeslaDocumentManager
{
    public class UserLogIn
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string UsernName { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public static string ErrMessage { get; set; }

        public static bool LogInUser(HttpResponse response, string username, string password)
        {
            try
            {
                SqlCommand cmd = DBConnection.GetCommand;               
                cmd.CommandText = "select u.Id,u.Fullname,g.AccessLevel from Users as u " +
                                    "inner join UserGroups as g on u.UserGroupID = g.Id " + 
                            "where Username = @username and Password = @password and Active = 1";
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        HttpCookie cookieFullName = new HttpCookie("FullName");
                        cookieFullName.Expires = DateTime.Now.AddMinutes(60);
                        cookieFullName.Value = dt.Rows[0]["Fullname"].ToString();
                        response.Cookies.Add(cookieFullName);

                        HttpCookie cookieUserId = new HttpCookie("Id");
                        cookieUserId.Expires = DateTime.Now.AddMinutes(60);
                        cookieUserId.Value = dt.Rows[0]["Id"].ToString();
                        response.Cookies.Add(cookieUserId);

                        HttpCookie cookieAccessLevel = new HttpCookie("AccessLevel");
                        cookieAccessLevel.Expires = DateTime.Now.AddMinutes(60);
                        cookieAccessLevel.Value = dt.Rows[0]["AccessLevel"].ToString();
                        response.Cookies.Add(cookieAccessLevel);
                        return true;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                ErrMessage = "Nije uspelo logovanje";
                return false;
            }
        }

        public static bool LogOutUser(HttpResponse response)
        {
            HttpCookie cookieFullName = new HttpCookie("FullName");
            cookieFullName.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieFullName);

            HttpCookie cookieUserId = new HttpCookie("Id");
            cookieUserId.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieUserId);

            HttpCookie cookieAccessLevel = new HttpCookie("AccessLevel");
            cookieAccessLevel.Expires = DateTime.Now.AddMinutes(-1);
            response.Cookies.Add(cookieAccessLevel);
            return true;
        }

        public static bool UserLogInCheck(HttpRequest request)
        {
            if (request != null && request.Cookies != null)
            {
                if (request.Cookies["Id"] != null)
                {
                    var value = request.Cookies["id"].Value;
                    try
                    {
                        SqlCommand cmd = DBConnection.GetCommand;
                        cmd.Parameters.AddWithValue("@id", value);
                        cmd.CommandText = "select Id from Users " +
                        "where Id = @id and Active = 1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        ErrMessage = "Nije uspelo logovanje";
                        return false;
                    }
                }
            }
            return false;
        }


        public static UserLogIn UserLoggedIn(HttpRequest request)
        {
            if (request != null && request.Cookies != null)
            {
                if (request.Cookies["Id"] != null)
                {
                    var value = request.Cookies["Id"].Value;
                    try
                    {
                        SqlCommand cmd = DBConnection.GetCommand;
                        cmd.Parameters.AddWithValue("@id", value);
                        cmd.CommandText = "select u.Id, u.Fullname,g.AccessLevel from Users as u " +
                            "inner join UserGroups as g on u.UserGroupID = g.Id " +
                        "where u.Id = @id and u.Active = 1";
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                UserLogIn user = new UserLogIn();
                                user.Id = dt.Rows[0]["Id"].ToString();
                                user.FullName = dt.Rows[0]["Fullname"].ToString();
                                user.AccessLevel = Convert.ToInt32(dt.Rows[0]["AccessLevel"]);
                                return user;
                            }
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrMessage = "Nije uspelo logovanje";
                        return null;
                    }
                }
            }
            return null;
        }
    }
}