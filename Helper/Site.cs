using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Configuration;

namespace Helper
{
    //*********************************************************************
    //
    // Site Class
    //
    // Properties are used to store configurations of the of the user
    //
    //*********************************************************************
    public class Site
    {
        private static string m_ApplicationPath;
        //*********************************************************************
        //
        // FilesTypesToSearch ReadOnly Property
        //
        // Retreive FilesTypesToSearch of the site
        //
        //*********************************************************************
        public static string FilesTypesToSearch
        {
            get { return ConfigurationSettings.AppSettings["FilesTypesToSearch"]; }
        }

        //*********************************************************************
        //
        // DynamicFilesTypesToSearch ReadOnly Property
        //
        // Retreive DynamicFilesTypesToSearch of the site
        //
        //*********************************************************************
        public static string DynamicFilesTypesToSearch
        {
            get { return ConfigurationSettings.AppSettings["DynamicFilesTypesToSearch"]; }
        }

        //*********************************************************************
        //
        // BarredFolders ReadOnly Property
        //
        // Retreive BarredFolders of the site
        //
        //*********************************************************************
        public static string BarredFolders
        {
            get { return ConfigurationSettings.AppSettings["BarredFolders"]; }
        }

        //*********************************************************************
        //
        // BarredFiles ReadOnly Property
        //
        // Retreive BarredFiles of the site
        //
        //*********************************************************************
        public static string BarredFiles
        {
            get { return ConfigurationSettings.AppSettings["BarredFiles"]; }
        }

        //*********************************************************************
        //
        // EnglishLanguage Property
        //
        // Retreive EnglishLanguage of the site
        //
        //*********************************************************************
        public static string EnglishLanguage
        {
            get { return ConfigurationSettings.AppSettings["EnglishLanguage"]; }
        }

        //*********************************************************************
        //
        // ApplicationPath Property
        //
        // Assign and retreive ApplicationPath of the site
        //
        //*********************************************************************
        public static string ApplicationPath
        {
            get { return m_ApplicationPath; }
            set { m_ApplicationPath = value; }
        }

    }
}
