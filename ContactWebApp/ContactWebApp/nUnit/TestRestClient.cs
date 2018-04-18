using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using ContactWebApp.Common;
using System.Data;

namespace ContactWebApp.nUnit
{
    [TestFixture]
    public class TestRestClient
    {
        [Test]
        public void GetData()
        {
            RestClient restclient = new RestClient();
            string token = restclient.GetAuthToken();

            DataSet ds = new DataSet();
            RestClient _restClient = new RestClient();
            ds = _restClient.GetData("GetAllContact", token);
            int result =  Convert.ToInt32(ds.Tables[0].Rows.Count);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void TestAuthToken()
        {
            RestClient restclient = new RestClient();
            string result = restclient.GetAuthToken();
            StringAssert.AreEqualIgnoringCase("3aeb7qr9ga227hp3n7m", result);
        }
    }
}