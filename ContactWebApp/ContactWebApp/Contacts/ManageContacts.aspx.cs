using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;
using ContactWebApp.Common;

namespace ContactWebApp.Contacts
{
    public partial class ManageContacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                RestClient restclient = new RestClient();
                string token = restclient.GetAuthToken();

                DataSet ds = new DataSet();
                RestClient _restClient = new RestClient();
                ds = _restClient.GetData("GetAllContact", token);
                grdList.DataSource = ds;
                grdList.DataBind();
                Session["Contacts"] = ds;
            }
        }

        protected void bntAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                Session["srno"] = 0;
                Response.Redirect("AddCoontact.aspx");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
        protected void ImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow row = ((ImageButton)sender).Parent.Parent as GridViewRow;
                Session["srno"] = grdList.DataKeys[row.RowIndex].Value.ToString();
                Response.Redirect("AddCoontact.aspx");
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}