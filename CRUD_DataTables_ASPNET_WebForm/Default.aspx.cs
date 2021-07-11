using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_DataTables_ASPNET_WebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<User> deletedUserList = new List<User>();
                HiddenFieldDeletedUser.Value = JsonConvert.SerializeObject(deletedUserList);
                
                List<City> cityList = new List<City>();
                cityList.Add(new City { Name = "Kuala Lumpur", Value = "Kuala Lumpur" });
                cityList.Add(new City { Name = "Petaling Jaya", Value = "Petaling Java" });
                cityList.Add(new City { Name = "Subang", Value = "Subang" });
                cityList.Add(new City { Name = "Penang", Value = "Penang" });
                cityList.Add(new City { Name = "Melaka", Value = "Melaka" });
                cityList.Add(new City { Name = "Johor Bahru", Value = "Johor Bahru" });
                HiddenFieldCity.Value = JsonConvert.SerializeObject(cityList);

                DataTable userTable = InMemorySqlite.Instance.GetDataTable("SELECT RowID, * FROM User");
                List<User> userList = new List<User>();
                foreach (DataRow row in userTable.Rows)
                {
                    User newUser = new User();
                    newUser.RowID = Convert.ToInt64(row["RowID"]);
                    newUser.Name = row["Name"].ToString();
                    newUser.Age = row["Age"] == DBNull.Value ? 0 : Convert.ToInt32(row["Age"]);
                    newUser.City = row["City"].ToString();
                    newUser.Email = row["Email"].ToString();
                    newUser.JoinedDate = row["JoinedDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : Convert.ToDateTime(row["JoinedDate"]);
                    newUser.ModifiedDate = row["ModifiedDate"] == DBNull.Value ? new DateTime(1900, 1, 1) : Convert.ToDateTime(row["ModifiedDate"]);
                    userList.Add(newUser);
                }
                HiddenFieldUser.Value = JsonConvert.SerializeObject(userList);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<User> userList = JsonConvert.DeserializeObject<List<User>>(HiddenFieldUser.Value);            
            foreach (User user in userList)
            {
                if (user.RowID == -1)
                {
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@Name", user.Name));
                    parameters.Add(new SQLiteParameter("@Age", user.Age));
                    parameters.Add(new SQLiteParameter("@City", user.City));
                    parameters.Add(new SQLiteParameter("@Email", user.Email));
                    parameters.Add(new SQLiteParameter("@JoinedDate", user.JoinedDate.ToString("yyyy-MM-dd")));
                    parameters.Add(new SQLiteParameter("@ModifiedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                    InMemorySqlite.Instance.ExecuteNonQuery("INSERT INTO User VALUES (@Name, @Age, @City, @Email, @JoinedDate, @ModifiedDate)", parameters.ToArray());
                }
                else
                {
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@Name", user.Name));
                    parameters.Add(new SQLiteParameter("@Age", user.Age));
                    parameters.Add(new SQLiteParameter("@City", user.City));
                    parameters.Add(new SQLiteParameter("@Email", user.Email));
                    parameters.Add(new SQLiteParameter("@JoinedDate", user.JoinedDate.ToString("yyyy-MM-dd")));
                    parameters.Add(new SQLiteParameter("@ModifiedDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                    parameters.Add(new SQLiteParameter("@RowID", user.RowID));
                    InMemorySqlite.Instance.ExecuteNonQuery("UPDATE User SET Name=@Name, Age=@Age, City=@City, Email=@Email, JoinedDate=@JoinedDate, ModifiedDate=@ModifiedDate WHERE RowID=@RowID", parameters.ToArray());
                }
            }

            List<User> deletedUserList = JsonConvert.DeserializeObject<List<User>>(HiddenFieldDeletedUser.Value);
            foreach (User user in deletedUserList)
            {
                List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                parameters.Add(new SQLiteParameter("@RowID", user.RowID));
                InMemorySqlite.Instance.ExecuteNonQuery("DELETE FROM User WHERE RowID=@RowID", parameters.ToArray());
            }

            divSuccessAlert.Visible = true;
        }
    }
}