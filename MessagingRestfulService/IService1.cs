using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

//Simplified messaging service to buffer messages in XML file
namespace MessagingRestfulService
{
   
    [ServiceContract]
    public interface IService1
    {
        //Allows the client to send a string-type message to the messaging service and the message will be stored in XML file
        //with at least a senderID, a receiverID, and a timestamp.
        [OperationContract]
        [WebGet(UriTemplate = "sendMsg?senderID={senderID}&receiverID={receiverID}&msg={msg}")]
        void sendMsg(string senderID, string receiverID, string msg);
        //Allows the client to receive all the messages sent to the receiverID
       
        [OperationContract]
        [WebGet(UriTemplate = "receiveMsg?receiverID={receiverID}&purge={purge}")]
        string[] receiveMsg(string receiverID, Boolean purge);

    }
}
