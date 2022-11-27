using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace MultiLanguageOmni
{
  
    // ########################################################################
    // #  Class       :ReadResourceKey  
    // # Propose      :Open Resource file for reading and get names
    // # Use  singelton class "ResourceManagerSingleton"
    // #  Metods      : GetString(string resourceId, string resourceBaseName,string cultname)
    // #                LoadFormUserControlText(System.Windows.Forms.Form form,  string cultname, string resourceBaseName)  
    // #  Returns     : bool                                                    #
    // #  "Add a row given all values. 
    // #  Input Parameter: ArrayList " include all row values by colmun order
    // #  Writed by Sevim Tel       
    // #  Date 31.07.2006
    // ########################################################################            
    public class ReadResourceKey
    {
        public static string ResourceName = "";
        public static Assembly assName;
        public static string cultureName="tr-TR";
        public static CultureInfo ci;


        // ########################################################################
        // #  Metods      : GetString(string resourceId, string resourceBaseName,string cultname)
        // #  Returns     : static string (real value or error code)                                                    #
        // #  
        // #  Input Parameter: String resourceId  -- is name column of Resource file 
        // #                   string resourceBaseName  -- Resource file name.
        // #                   string cultname  -- Cultur Name is like tr-TR, enu-US"
        // #  Writed by Sevim Tel       
        // #  Date 31.07.2006
        // ########################################################################            
        public static string GetString(string resourceId, string resourceBaseName)
        {

            string result;
            string error_resource_code_1 = "error1"; 
            ResourceName = resourceBaseName;
            ci = new CultureInfo(cultureName);
            assName = Assembly.GetExecutingAssembly();
            try
            {
                result = ResourceManagerSingleton.Instance.GetString(resourceId, ci);
            }
            catch (Exception ex)
            {
                result = error_resource_code_1;

            }
            return result;
        }


        // ########################################################################
        // #  Metods      : LoadFormUserControlText(System.Windows.Forms.Form form,  
        // #                  string cultname,
        // #                   ,string resourceBaseName)
        // #  This metod takes user windows form referance and 
        // # get all all user control names on this resource file
        // # and assign these names to all user colntrol on the Form. 
        // #  Returns     : static void                                                                 
        // #  Writed by Sevim Tel       
        // #  Date 31.07.2006
        // ########################################################################            
        
        
        //******************************

        public class ResourceManagerSingleton
        {
            private ResourceManagerSingleton() { }

            protected static ResourceManager CreateInstance()
            {
                return new ResourceManager(ResourceName, assName);
            }

            private static ResourceManager _instance;
            public static ResourceManager Instance
            {
                get
                {
                    lock (typeof(ResourceManagerSingleton))
                    {
                        if (_instance == null)
                        {

                          //  cultureName = SystemParametersDef.GetRequiredColumnValue("system_culture_name");
                            cultureName = cultureName.TrimEnd(); 
                            _instance = CreateInstance();
                            ci = new CultureInfo(cultureName);
                        }
                        else
                        {
                            if ((_instance.BaseName).ToString() != ResourceName)
                            {
                                System.GC.SuppressFinalize(_instance);
                                _instance = CreateInstance();
                            
                           //     cultureName = SystemParametersDef.GetRequiredColumnValue("system_culture_name");
                                cultureName = cultureName.TrimEnd();
                                ci = new CultureInfo(cultureName);
                            }
                        }
                           
                    }
                    return _instance;
                }
            }
        }
    }
    class ReadResourceKeyList
    {

    }

    public class AddResourceKey
    {
        public static string ResourceName;

        public static void AddStringResourceKey(string resourceKey, string resourceValue, string resourceBaseName)
        {
            if (resourceKey == "Close")
            {
                ResourceWriteSingleton.Instance.Generate();
                ResourceWriteSingleton.Instance.Close();
            }
            else
            {
                ResourceName = resourceBaseName;
                ResourceWriteSingleton.Instance.AddResource(resourceKey, resourceValue);
            }
            
        }
        public static void CloseResource()
        {
            ResourceWriteSingleton.Instance.Generate();
            ResourceWriteSingleton.Instance.Close();
        }

        /*public static void AddStringResourceKey(string resourceId, object resourceValue, string baseName)
        {
            ResourceName = baseName;
            ResourceWriteSingleton.Instance.AddResource(resourceId, resourceValue);
            ResourceWriteSingleton.Instance.Generate();
            ResourceWriteSingleton.Instance.Close();
            
        }*/
        private class ResourceWriteSingleton
        {
            private ResourceWriteSingleton() { }

            protected static ResXResourceWriter CreateInstance()
            {
                return new ResXResourceWriter(ResourceName);
            }


            private static ResXResourceWriter _instance;


            public static ResXResourceWriter Instance
            {
                get
                {
                    // Allow access from multiple threads
                    lock (typeof(ResourceWriteSingleton))
                    {
                        if (_instance == null)
                            _instance = CreateInstance();
                    }

                    return _instance;
                }
            }
        }
    }

}
