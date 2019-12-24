using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace GuestBook
{
    public partial class right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtName.Text = "홍길동";
            }
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
                ("server=192.168.0.69;Uid=sa;pwd=1234;database=mysample");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Insert into guestbook(Name, Email, Title, Contents, Pass) " +
                "values (@Name,@Email,@Title,@Contents,@Pass)";

            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Title", txttitle.Text);
            cmd.Parameters.AddWithValue("@Contents", txtContents.Text);
            cmd.Parameters.AddWithValue("@Pass", txtPass.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            //Response.Write("<script>alert('이것이 웹폼이다');<sciprter>");
        }
    }
}