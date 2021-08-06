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
using System.Collections;

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
            }
        }

        private void BindGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM comments where deleted = 0 ORDER BY Id DESC;"))
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

        private void getComments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM comments where deleted = 0 ORDER BY Id DESC;e"))
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

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            commentsGrid.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string commandText = "INSERT INTO comments (name, email, continent, message, date)  VALUES (@name, @email, @continent, @message, @date)";

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

                //if (continent.SelectedValue != "0")
                //{
                //    cmd.Parameters.AddWithValue("@continent", continent.SelectedValue);
                //} else
                //{
                //    cmd.Parameters.AddWithValue("@continent", DBNull.Value);
                //}

                cmd.Parameters.AddWithValue("@continent", DBNull.Value);

                cmd.Parameters.AddWithValue("@message", message.Text);

                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                try
                {
                    connection.Open();
                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    this.BindGrid();
                    this.clearForm();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Oops. Something went wrong.');</script>");
                    //run Something went wrong popup
                }
            }
        }

        private void clearForm()
        {
            name.Text = string.Empty;
            email.Text = string.Empty;
            //continent.SelectedValue = "0";
            message.Text = string.Empty;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        protected void commentsGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            commentsGrid.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void commentsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(e.Values[0]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE comments SET deleted = 1 WHERE Id=@id", connection);
                cmd.Parameters.AddWithValue("@id", id);

                connection.Open();
                int temp = cmd.ExecuteNonQuery();
                if (temp == 1)
                {
                    Response.Write("<script>alert('Record deleted successfully.');</script>");
                }
                connection.Close();
                this.BindGrid();
            }
        }

        protected void commentsGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {       
            string rowId = (string)commentsGrid.Rows[e.RowIndex].Cells[0].Text;

            Response.Write(commentsGrid.Rows[e.RowIndex].Cells[3].Text); // <--- doesn't return expected new data
            //Response.Write(e.NewValues["message"].ToString());
            //Response.Write(e.NewValues["Message"].ToString());

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlCommand cmd = new SqlCommand("update query...", connection);
                
                //connection.Open();
                //int temp = cmd.ExecuteNonQuery();
                //connection.Close();
                
                //this.BindGrid();
            }
             
        }

        protected void commentsGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            commentsGrid.EditIndex = -1;
            this.BindGrid();
        }
    }
}