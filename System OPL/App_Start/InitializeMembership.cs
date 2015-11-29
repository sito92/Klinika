using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using WebMatrix.WebData;

namespace System_OPL
{
    public static class InitializeMembership
    {
        public static void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("OPLConnection", "Doctors", "Id", "UserName", autoCreateTables: true);
        }
    }
}