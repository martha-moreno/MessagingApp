using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MsgApp_ASPNET
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWarning.Visible= false;
        }

        protected void btnReceiveMessage_Click(object sender, EventArgs e)
        {
            if( txtReceiverID.Text == string.Empty)
            {
                lblWarning.Text = "Please enter all fields in the form";
                lblWarning.Visible = true;
            }
            else
            {
                string receiverID = txtReceiverID.Text;
                bool purge = Purge.Checked;
                List<string> list = new List<string>(); //list to hold deserialized received messages that have not been read before
                string[] finalresponse;
             
                //call RESTful service
                string apiUrl = "http://localhost:50060/Service1.svc/receiveMsg?receiverID=" + receiverID + "&purge=" + purge;
                WebClient client = new WebClient();
                string response = client.DownloadString(apiUrl);    //receiving response from restul service

                //Deserialize service response
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response);

                XmlNodeList elemList = doc.GetElementsByTagName("string");
                //if there are messages
                if (elemList.Count > 0)
                {
                    //Add messages to the list
                    for (int i = 0; i < elemList.Count; i++)
                    {
                        list.Add(elemList[i].InnerText);
                    }
                    var arrayResponse = list.ToArray();
                    string result = String.Join("\r\n", arrayResponse);
                    txtMessage.Text = result; //Display messages in textbox

                    //Update element "Read" value to true (after read) in xml file
                    string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"..\MessagingRestfulService\App_Data\Messages.xml");
                    XDocument xmlDocument = XDocument.Load(fLocation);
                    IEnumerable<XElement> queryElementItems =
                       from item in xmlDocument.Root.Descendants("Message")
                       where item.Element("ReceiverID").Value == receiverID
                       orderby (DateTime)item.Element("TimeStamp") descending
                       select item;

                    finalresponse = new string[queryElementItems.Count() * 3];
                    foreach (XElement item in queryElementItems)
                    {
                        item.Element("Read").Value = "Yes";
                    }
                    xmlDocument.Save(fLocation);
                }
                else //if no messages, display message
                {
                    if (!purge)
                    {
                        string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"..\MessagingRestfulService\App_Data\Messages.xml");
                        XDocument xmlDocument = XDocument.Load(fLocation);
                        IEnumerable<XElement> queryElementItems =
                           from item in xmlDocument.Root.Descendants("Message")
                           where item.Element("ReceiverID").Value == receiverID
                           orderby (DateTime)item.Element("TimeStamp") descending
                           select item;
                        if (queryElementItems.Count() > 0)
                        {
                            txtMessage.Text = "There are no new messages for ReceiverID:" + receiverID;
                        }
                        else
                        {
                            txtMessage.Text = "There are no messages for ReceiverID:" + receiverID;
                        }
                       
                    }
                    else
                    {
                        txtMessage.Text = "There are no messages for ReceiverID:" + receiverID;
                    }
                    
                }

            }

        }           
    }
}