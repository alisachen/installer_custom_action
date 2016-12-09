using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            deleteDir("apps", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");
            deleteDir("cache\\QtWebEngine", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");
            deleteDir("QtWebEngine", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");

            
            deleteDir("apps", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("cache\\QtWebEngine", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("QtWebEngine", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("apps", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");
            deleteDir("cache\\QtWebEngine", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");
            deleteDir("QtWebEngine", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");

            
            deleteDir("apps", "777FCF69-65E4-486C-81AA-3538E87D8727");
            deleteDir("cache\\QtWebEngine", "777FCF69-65E4-486C-81AA-3538E87D8727");
            deleteDir("QtWebEngine", "777FCF69-65E4-486C-81AA-3538E87D8727");

            
            deleteDir("apps", "BDBFEB22-F153-41F5-940F-DAE4DD517699");
            deleteDir("cache\\QtWebEngine", "BDBFEB22-F153-41F5-940F-DAE4DD517699");
            deleteDir("QtWebEngine", "BDBFEB22-F153-41F5-940F-DAE4DD517699");

            
            deleteDir("apps", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("cache\\QtWebEngine", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("QtWebEngine", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("apps", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");
            deleteDir("cache\\QtWebEngine", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");
            deleteDir("QtWebEngine", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");

            
            deleteDir("apps", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("cache\\QtWebEngine", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("QtWebEngine", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("apps", "DC2C2130-8C26-45AD-BBCC-860613BFB550");
            deleteDir("cache\\QtWebEngine", "DC2C2130-8C26-45AD-BBCC-860613BFB550");
            deleteDir("QtWebEngine", "DC2C2130-8C26-45AD-BBCC-860613BFB550");

            
            deleteDir("apps", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("cache\\QtWebEngine", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("QtWebEngine", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("apps", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("cache\\QtWebEngine", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("QtWebEngine", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("apps", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");
            deleteDir("cache\\QtWebEngine", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");
            deleteDir("QtWebEngine", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");

            
            deleteDir("cache", "");
            deleteDir("", "");


        }

        static void deleteDir(String segment, String appId)
        {
            String root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HP\\FortisDesktopContainer\\");
            String path = root + segment;
            String appIdPath = path + "\\" + appId;

            DirectoryInfo rootDir = new DirectoryInfo(root);
            DirectoryInfo pathDir = new DirectoryInfo(path);
            DirectoryInfo appIdPathDir = new DirectoryInfo(appIdPath);

            if(rootDir.Exists)
            {
                if (rootDir.GetDirectories().Length <= 0)
                {
                    rootDir.Delete(true);
                    return;
                }

                if (pathDir.Exists) 
                {
                    if (pathDir.GetDirectories().Length <= 0 )
                    {
                        pathDir.Delete(true);
                        return;
                    }

                    if (appIdPathDir.Exists) 
                    {
                        appIdPathDir.Delete(true);
                    }
                }
            }
            return;
        }

        static String reverseGUID( String guid, String space)
        {
            String reversed = null;
            
            Regex rx = new Regex("([0-9a-fA-F]{8,8})([0-9a-fA-F]{4,4})([0-9a-fA-F]{4,4})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})([0-9a-fA-F]{2,2})");

            Match match = rx.Match(guid);

            for (int i = 1; i <= 11; i++)
            {
                String str = (String)match.Groups[i].Value;
                char[] ch = str.ToCharArray();
                Array.Reverse(ch);
                reversed += new string(ch);
                if(i==1 || i==2 || i==3 || i == 5)
                {
                    reversed += space;
                }
            }

            return reversed;
        }

        static String deleteVersion(String guid)
        {
            String upgradeCode = "EB17D2BB-38D1-474f-A6A9-5457CC8F4E2E";
            String upgradeCodeKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
            String registryKey = upgradeCodeKey + reverseGUID(upgradeCode, "");
            
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey soft = rk.OpenSubKey(registryKey);

            String[] values = soft.GetValueNames();

            String productId = reverseGUID(values[0], "-");

            //delete displayversion info in uninstall registry key
            String uninstallKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{"+productId+"}";
            RegistryKey rk2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey uninstallRK = rk2.OpenSubKey(uninstallKey);


            return null;

        }


        private static string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
        
        static void PrintKeys(RegistryKey rkey)
        {

            // Retrieve all the subkeys for the specified key.
            String[] names = rkey.GetSubKeyNames();

            int icount = 0;

            Console.WriteLine("Subkeys of " + rkey.Name);
            Console.WriteLine("-----------------------------------------------");
            
            // Print the contents of the array to the console.
            foreach (String s in names)
            {
                Console.WriteLine(s);

                // The following code puts a limit on the number
                // of keys displayed.  Comment it out to print the
                // complete list.
                icount++;
                if (icount >= 10)
                    break;
            }
            Console.ReadLine();
        }
    }
}
