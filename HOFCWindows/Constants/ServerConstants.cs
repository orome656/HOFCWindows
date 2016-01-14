using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOFCWindows.Constants
{
    class ServerConstants
    {
        private static readonly string SERVER_BASE_URL = "http://hofcdev.azurewebsites.net";
        public static readonly string ACTUS_URL = SERVER_BASE_URL + "/api/Actu";

        private static readonly string CALENDRIER_BASE_URL = SERVER_BASE_URL + "/api/Calendrier";
        public static  readonly Dictionary<string, string> CALENDRIER_URL = new Dictionary<string, string>() {
            { "equipe1",  CALENDRIER_BASE_URL + "/equipe1"},
            { "equipe2",  CALENDRIER_BASE_URL + "/equipe2"},
            { "equipe3",  CALENDRIER_BASE_URL + "/equipe3"}
        };
        private static readonly string CLASSEMENT_BASE_URL = SERVER_BASE_URL + "/api/Classement";

        public static readonly Dictionary<string, string> CLASSEMENT_URL = new Dictionary<string, string>() {
            { "equipe1",  CLASSEMENT_BASE_URL + "/equipe1"},
            { "equipe2",  CLASSEMENT_BASE_URL + "/equipe2"},
            { "equipe3",  CLASSEMENT_BASE_URL + "/equipe3"}
        };
    }
}
