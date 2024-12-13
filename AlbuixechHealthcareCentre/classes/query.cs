using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbuixechHealthcareCentre.classes
{
    public class Query
    {
        public static string logInQuery => "SELECT UserID, Password, Role FROM Users WHERE Username = @username";
    }
}

