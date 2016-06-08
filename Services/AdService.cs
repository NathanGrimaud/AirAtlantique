using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;
using AirAtlantique.Model;

namespace AirAtlantique.Services
{
    public static class AdService
    {
        public static bool isRH(Employe emp)
        {
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", emp.samAccountName);
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupsList = new StringBuilder();

            SearchResult result = search.FindOne();
            if (result != null)
            {
                int groupCount = result.Properties["memberOf"].Count;

                for (int counter = 0; counter < groupCount; counter++)
                {
                    groupsList.Append((string)result.Properties["memberOf"][counter]);
                    groupsList.Append("|");
                }
            }
            groupsList.Length -= 1; //remove the last '|' symbol

            return true;
        }

    }
}
