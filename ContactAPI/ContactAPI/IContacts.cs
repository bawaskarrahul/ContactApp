using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContactDAL;

namespace ContactAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContacts
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetContactByID/{contactId}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        Contact GetContactByID(string contactID);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllContact")]
        IEnumerable<Contact> GetAllContact();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAuthToken")]
        string GetAuthToken();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddContact", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string AddContact(Contact contact);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateContact", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string UpdateContact(Contact contact);
    }
}
