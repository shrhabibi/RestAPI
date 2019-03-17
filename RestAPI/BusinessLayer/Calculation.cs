using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.BusinessLayer
{

    public static class Calculation
    {
        private static StringBuilder ErrorMessages = new StringBuilder();

        public static string GetException()
        {
            return ErrorMessages.ToString();
        }

        public static void CheckValue(String Para)
        {
            try
            {
                int n = Convert.ToInt16(Para);
            }
            catch (Exception ex)
            {
                ErrorMessages.Append(ex.Message.ToString());
            }

        }

        public static int? PremiumValue(String Para1, String Para2, String Para3)
        {
            CheckValue(Para1);
            CheckValue(Para2);
            CheckValue(Para3);
            if (ErrorMessages.Length > 0) return null;
            return Convert.ToInt16(Para1) * Convert.ToInt16(Para2) * Convert.ToInt16(Para3);
        }
    }
}
