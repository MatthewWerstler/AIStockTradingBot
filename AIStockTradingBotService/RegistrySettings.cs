using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AIStockTradingBotLogic;

namespace AIStockTradingBotService
{
    public static class RegistrySettings
    {

        /// <summary>
        /// Save our EncryptionKey based on https://www.c-sharpcorner.com/UploadFile/f9f215/windows-registry/
        /// </summary>
        /// <param name="value">Registry Setting Value</param>
        /// <param name="setting">Registry Setting Name</param>
        /// <returns>is successful or not</returns>
        public static bool setRegistryEncryptionKey(string EncryptionKey, string setting)
        {
            try
            { 
                //accessing the CurrentUser root element
                //and adding "OurSettings" subkey to the "SOFTWARE" subkey  
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AIStockTradingBotService");



                //storing the values  
                key.SetValue(setting, "This is our setting 1");
                
                key.Close();
                return true;
            }
            catch()
            {
                return false;
            }
        }
    }
}
