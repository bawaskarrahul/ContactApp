using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContactDAL;

using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using AutoMapper;
using System.ServiceModel.Activation;
using System.Net;

namespace ContactAPI
{
    [AspNetCompatibilityRequirements (RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ContactSerice : IContacts
    {
        string token = null;
        #region IContacts Members
        public IEnumerable<Contact> GetAllContact()
        {
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string userIdentityToken = headers["TokenHeader"].ToString();
                //Todo: Fetch the token from the database.
                token = "3aeb7qr9ga227hp3n7m";
                if (ValidateToken(userIdentityToken))
                {
                    IRepository<tblContact> DBRepository = new EntityRepository<tblContact>();
                    Mapper.CreateMap<tblContact, Contact>();
                    return Mapper.Map<IEnumerable<tblContact>, IEnumerable<Contact>>(DBRepository.GetAll());
                }
                else
                {
                    List<Contact> obj = new List<Contact>();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        public Contact GetContactByID(string ContactID)
        {
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string userIdentityToken = headers["TokenHeader"].ToString();
                //Todo: Fetch the token from the database.
                token = "3aeb7qr9ga227hp3n7m";
                if (ValidateToken(userIdentityToken))
                {
                    IRepository<tblContact> DBRepository = new EntityRepository<tblContact>();
                    Mapper.CreateMap<tblContact, Contact>();
                    return Mapper.Map<IEnumerable<tblContact>, IEnumerable<Contact>>(DBRepository.GetAll()).Where(x => x.ContactID == Convert.ToInt32(ContactID)).FirstOrDefault();
                }
                else
                {
                    return new Contact();
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        public string GetAuthToken()
        {
            try
            {
                //ToDo : user to be authenticated from the database
                // random token to be generated and stored in database that will expire at pre-defined time
                token = "3aeb7qr9ga227hp3n7m";
                return token;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        private bool ValidateToken(string userIdentityToken)
        {
            try
            {
                bool isValid = false;
                if (userIdentityToken == token)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
                return isValid;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        public string AddContact(Contact contact)
        {
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string userIdentityToken = headers["TokenHeader"].ToString();
                //Todo: Fetch the token from the database.
                token = "3aeb7qr9ga227hp3n7m";
                if (ValidateToken(userIdentityToken))
                {
                    IRepository<tblContact> DBRepository = new EntityRepository<tblContact>();
                    Mapper.CreateMap<Contact, tblContact>();
                    var tblcontext = Mapper.Map<Contact, tblContact>(contact);

                    // Insert a new Contacts
                    DBRepository.Add(tblcontext);
                    DBRepository.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Invalid User";
                }

            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        public string UpdateContact(Contact contact)
        {
            try
            {
                IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                WebHeaderCollection headers = request.Headers;
                string userIdentityToken = headers["TokenHeader"].ToString();
                //Todo: Fetch the token from the database.
                token = "3aeb7qr9ga227hp3n7m";
                if (ValidateToken(userIdentityToken))
                {
                    IRepository<tblContact> DBRepository = new EntityRepository<tblContact>();
                    //Mapper.CreateMap<Contact, tblContact>();
                    //var tblcontext = Mapper.Map<Contact, tblContact>(contact);

                    tblContact tbl = (DBRepository.GetAll()).Where(x => x.ContactID == Convert.ToInt32(contact.ContactID)).FirstOrDefault();
                    tbl.FirstName = contact.FirstName;
                    tbl.LastName = contact.LastName;
                    tbl.Email = contact.Email;
                    tbl.PhoneNumber = contact.PhoneNumber;
                    tbl.Status = contact.Status;

                    // Insert a new Contacts
                    //DBRepository.Attach(tbl);
                    DBRepository.SaveChanges();
                    return "Success";
                }
                else
                {
                    return "Invalid User";
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
        #endregion
    }
}
