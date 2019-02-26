using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChannelAdvisorDeveloperAuth.ChannelAdvisorAdminService;

namespace ChannelAdvisorDeveloperAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Profile ID for the account you wish to authorize.");
            string accountID = Console.ReadLine();
            AuthorizeChannelAdvisorAPI(accountID);

        }

        public static void AuthorizeChannelAdvisorAPI(string accountID)
        {
            string developerKey = string.Empty;
            string password = string.Empty;
            

            developerKey = "83a02569-8a08-431e-8f4d-08293c08506d";
            password = "TPGdev2017";
            

            try
            {
                ChannelAdvisorAdminService.APICredentials AdminCredentials = new ChannelAdvisorAdminService.APICredentials();
                AdminCredentials.DeveloperKey = developerKey;
                AdminCredentials.Password = password;

                AdminServiceSoapClient admin = new AdminServiceSoapClient();
                ChannelAdvisorAdminService.APIResultOfBoolean bol = admin.RequestAccess(AdminCredentials, Convert.ToInt32(accountID));
                ChannelAdvisorAdminService.APIResultOfArrayOfAuthorizationResponse authList = admin.GetAuthorizationList(AdminCredentials, accountID);

                Console.WriteLine("Account authorized successfully.");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
