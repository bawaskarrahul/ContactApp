using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactWebApp.Model;
using ContactWebApp.Common;
using System.Data;


namespace ContactWebApp.Contacts
{
    public partial class AddCoontact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Convert.ToInt32(Session["srno"])>0) FillForm();
            }
        }
        private void FillForm()
        {
            try
            {
                RestClient restclient = new RestClient();
                string token = restclient.GetAuthToken();

                DataSet ds = new DataSet();
                RestClient _restClient = new RestClient();
                ds = _restClient.GetData("GetContactByID/" + Convert.ToInt32(Session["srno"]), token);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtFName.Value = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    txtLName.Value = ds.Tables[0].Rows[0]["LastName"].ToString();
                    txtEmail.Value = ds.Tables[0].Rows[0]["Email"].ToString();
                    txtContactNumber.Value = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    cboStatus.SelectedIndex = cboStatus.Items.IndexOf(cboStatus.Items.FindByText(ds.Tables[0].Rows[0]["Status"].ToString()));
                }
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";

                Contact obj = new Contact();
                obj.ContactID = Convert.ToInt32(Session["srno"]);
                obj.FirstName = txtFName.Value.Trim();
                obj.LastName = txtLName.Value.Trim();
                obj.Email = txtEmail.Value.Trim();
                obj.PhoneNumber = txtEmail.Value.Trim();
                obj.Status = cboStatus.SelectedValue == "1" ? true : false;

                RestClient restclient = new RestClient();
                string token = restclient.GetAuthToken();
                if (obj.ContactID == 0)
                {
                    lblmsg.Text = restclient.PostData("AddContact", obj, token);
                    Response.Redirect("ManageContacts.aspx");
                }
                else
                {
                    lblmsg.Text = restclient.PostData("UpdateContact", obj, token);
                    Response.Redirect("ManageContacts.aspx");
                }
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }
}