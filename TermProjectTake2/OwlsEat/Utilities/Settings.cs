using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    [Serializable]
    public class Settings
    {
        private string loginPreference;

        public string LoginPreference
        {
            get { return loginPreference; }
            set { loginPreference = value; }
        }
    }
}
