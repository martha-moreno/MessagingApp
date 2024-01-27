using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace MsgApp_ASPNET
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSendMessage_Click(object sender, EventArgs e)
        {
            
            //Validating user data
            if(txtSenderID.Text == string.Empty || txtReceiverID.Text == string.Empty || txtMessage.Text ==string.Empty)
            {
                lblWarning.Text = "Please enter all field in the form";
                lblWarning.Visible = true;
            }
            else
            {
               
                //Holding user-entered values into variables
                string senderID = txtSenderID.Text;
                string receiverID = txtReceiverID.Text;
                string Message = txtMessage.Text;
                // Calling Restful service- operation sendMsg
                string apiUrl = "http://localhost:50060/Service1.svc/sendMsg?senderID=" + senderID + "&receiverID=" + receiverID + "&msg=" + Message;
                WebClient client = new WebClient();
                string response = client.DownloadString(apiUrl);    //receiving response from restul service

                //lblConfirmation.Visible = true;
                
                txtMessage.Text = String.Empty;
                txtSenderID.Text = String.Empty;
                txtReceiverID.Text = String.Empty;
                
                
            }

            
           
            
                                                         

        }
    }
}