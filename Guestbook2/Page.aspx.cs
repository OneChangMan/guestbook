using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Guestbook2
{
    public partial class Page : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["guestBook"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.BindGrid();
                //this.getComments():
            }


            //string commandText = "SELECT * FROM comments where deleted = 0";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand(commandText, connection);

            //    try
            //    {
            //        connection.Open();
            //        Int32 rowsAffected = cmd.ExecuteNonQuery();

            //        Response.Write(rowsAffected);


            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(ex);
            //        //run Something went wrong popup
            //    }
            //}
            //SqlConnection cnn = new SqlConnection(connectionString);
            //this.cnn.Open();

            //SqlCommand getPosts = cnn.CreateCommand();
            //getPosts.CommandType = System.Data.CommandType.Text;
            //getPosts.CommandText = "SELECT * FROM continents";

            //Response.Write("Connection MAde");
            //this.cnn.Close();
        }

        private void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT name, email, continent, message FROM comments"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = connection;
                        sda.SelectCommand = cmd;
                        using (DataTable dataTable = new DataTable())
                        {
                            sda.Fill(dataTable);
                            commentsGrid.DataSource = dataTable;
                            commentsGrid.DataBind();
                        }
                    }
                }
            }
        }

        //private void getComments()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT name, email, continent, message FROM comments"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Connection = connection;
        //                sda.SelectCommand = cmd;
        //                using (DataTable dataTable = new DataTable())
        //                {
        //                    sda.Fill(dataTable);
        //                    commentsGrid.DataSource = dataTable;
        //                    commentsGrid.DataBind();
        //                }
        //            }
        //        }
        //    }
        //}

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            commentsGrid.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string commandText = "INSERT INTO comments (name, email, continent, message)  VALUES (@name, @email, @continent, @message)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(commandText, connection);

                cmd.Parameters.AddWithValue("@name", name.Text);

                if (email.Text != "")
                {
                    cmd.Parameters.AddWithValue("@email", email.Text);
                } else
                {
                    cmd.Parameters.AddWithValue("@email", DBNull.Value);
                }

                if (continent.SelectedValue != "0")
                {
                    cmd.Parameters.AddWithValue("@continent", continent.SelectedValue);
                } else
                {
                    cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@message", message.Text);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    this.BindGrid();
                    this.clearForm();
                }
                catch (Exception ex)
                {
                    //run Something went wrong popup
                }
            }
        }

        private void clearForm()
        {
            name.Text = string.Empty;
            email.Text = string.Empty;
            continent.SelectedValue = "0";
            message.Text = string.Empty;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
    }
}