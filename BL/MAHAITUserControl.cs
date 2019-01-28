using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MAHAITUserControl : System.Web.UI.UserControl
    {
        public string GetResourceValue(string ResourceFile, string ResourceKey, string DefaultValue)
        {
            object t_Value = GetGlobalResourceObject(ResourceFile, ResourceKey);

            return t_Value == null ? DefaultValue : t_Value.ToString();
        }
    }
}
