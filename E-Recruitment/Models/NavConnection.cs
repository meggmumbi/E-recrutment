using E_Recruitment.OData;
using System;
using System.Configuration;
using System.Net;

namespace E_Recruitment.Models
{
    public class NavConnection
    {

        public static NAV ReturnNav()
        {
            NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]))
            {
                Credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                         ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"])
            };
            return nav;
        }
        public eRecruitment.eRecruitment ObjNav()
        {
            var ws = new eRecruitment.eRecruitment();
            try
            {
                var credentials = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                    ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                ws.Credentials = credentials;
                ws.PreAuthenticate = true;


            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return ws;
        }
      }
}


