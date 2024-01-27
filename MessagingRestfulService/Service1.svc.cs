using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MessagingRestfulService
{
    public class Service1 : IService1
    {
        public void sendMsg(string senderID, string receiverID, string msg)
        {
            DateTime dateTime = new DateTime();
            string month = dateTime.ToString("MMMM");
            /**********************Write XML file******************************/
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Messages.xml");
            
            //If file doesn't exist
            if (!File.Exists(fLocation))
            {
                XDocument xmlDocument = new XDocument();
                xmlDocument = new XDocument(
                             new XDeclaration("1.0", "UTF-8", "yes"),
                             new XElement("Messages",
                             new XElement("Message",
                             new XElement("SenderID", senderID),
                             new XElement("ReceiverID", receiverID),
                             new XElement("TimeStamp", System.DateTime.Now.ToString()),
                             new XElement("MessageContent", msg),
                             new XElement("Read", "No"))));
                xmlDocument.Save(fLocation);
            }

            //If file exists-append child
            else 
            { 
                 XDocument xmlDocument = XDocument.Load(fLocation);
                 XElement root = xmlDocument.Element("Messages");
                 IEnumerable<XElement> rows = root.Descendants("Message");
                 XElement firstRow = rows.First();
                 firstRow.AddBeforeSelf(
                     new XElement("Message",
                     new XElement("SenderID", senderID),
                     new XElement("ReceiverID", receiverID),
                     new XElement("TimeStamp", System.DateTime.Now.ToString()),
                     new XElement("MessageContent", msg),
                     new XElement("Read", "No")));
                xmlDocument.Save(fLocation);
            }

        }

        public string[] receiveMsg(string receiverID, Boolean purge)
        {
            string[] response; //array to hold received messages
            string fLocation = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Messages.xml");
            XDocument xmlDocument = XDocument.Load(fLocation);

            //If receiver has checked the purge option (delete all messages for the receiver)
            if (purge==true)
            {
                //Removing all messages from user-entered ReceiverID
                 var nodes = xmlDocument.Descendants("Message");
                 nodes.Where(x =>
                 {
                     var element = x.Element("ReceiverID");
                     return element != null && element.Value == receiverID;
                 }).Remove();

                //Update/Save new values to XML file
                IEnumerable < XElement > queryElementItems =
                   from item in xmlDocument.Root.Descendants("Message")
                   where item.Element("ReceiverID").Value == receiverID
                   orderby (DateTime)item.Element("TimeStamp") descending
                   select item;
                response = new string[queryElementItems.Count() * 3];
                int iter = 0;
                foreach (XElement item in queryElementItems)
                {
                    response[iter++] = item.Element("SenderID").Value;
                    response[iter++] = item.Element("TimeStamp").Value;
                    response[iter++] = item.Element("MessageContent").Value;
                    response[iter++] = item.Element("Read").Value;
                }
                xmlDocument.Save(fLocation);
                
            }
            else
            {
                //Retrieve all messages for the receiver
                IEnumerable<XElement> queryElementItems =
                   from item in xmlDocument.Root.Descendants("Message")
                   where item.Element("ReceiverID").Value == receiverID && item.Element("Read").Value =="No"
                   orderby (DateTime)item.Element("TimeStamp") descending
                   select item;

                response = new string[queryElementItems.Count() * 3];
                int iter = 0;
                foreach (XElement item in queryElementItems)
                {
                    response[iter++] = item.Element("SenderID").Value;
                    response[iter++] = item.Element("TimeStamp").Value;
                    response[iter++] = item.Element("MessageContent").Value;
                }
            }
            return response;
        }
    }
}
