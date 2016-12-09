using System;
using Microsoft.Deployment.WindowsInstaller;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace installer_custom_action
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult RemoveCameraCache(Session session)
        {
            session.Log("Begin Remove Camera Cache CustomActions");
            deleteDir("apps", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("cache\\QtWebEngine", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("QtWebEngine", "F821976C-02E9-4835-99E2-5D32704EF4D4");
            deleteDir("apps", "DC2C2130-8C26-45AD-BBCC-860613BFB550");
            deleteDir("cache\\QtWebEngine", "DC2C2130-8C26-45AD-BBCC-860613BFB550");
            deleteDir("QtWebEngine", "DC2C2130-8C26-45AD-BBCC-860613BFB550");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveShowCache(Session session)
        {
            session.Log("Begin Remove Show Cache CustomActions");
            deleteDir("apps", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("cache\\QtWebEngine", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("QtWebEngine", "0E604908-1691-484F-9BE9-C41935A46185");
            deleteDir("apps", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("cache\\QtWebEngine", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("QtWebEngine", "7D3545FF-89D3-4E8F-8CE5-97CD9B9184AA");
            deleteDir("apps", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");
            deleteDir("cache\\QtWebEngine", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");
            deleteDir("QtWebEngine", "D5D941FB-C096-43C1-BBDC-FEEAC1A89CCE");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveStageCache(Session session)
        {
            session.Log("Begin Remove Stage Cache CustomActions");
            deleteDir("apps", "0DF44E41-4340-4D75-9205-2E5A8252D22E");
            deleteDir("cache\\QtWebEngine", "0DF44E41-4340-4D75-9205-2E5A8252D22E");

            string message = "Do you want to remove all cache files for WorkTools Stage ?";
            string caption = "Popup dialog";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            session.Log("You want to remover all cache files for WorkTools Stage: {0}", result);
            deleteDir("QtWebEngine", "0DF44E41-4340-4D75-9205-2E5A8252D22E", result);
            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveCoreCache(Session session)
        {
            session.Log("Begin Remove WorkTools Core Cache CustomActions");
            session.Log("Begin remove cache for WorkTools Welcome");
            deleteDir("apps", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");
            deleteDir("cache\\QtWebEngine", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");
            deleteDir("QtWebEngine", "25CAC7E1-5DCB-473A-99A0-7FBC05313C14");

            session.Log("Begin remove cache for WorkTools Control");
            deleteDir("apps", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("cache\\QtWebEngine", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("QtWebEngine", "9F5320E5-876D-4525-BFCE-831C9C276C0A");
            deleteDir("apps", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");
            deleteDir("cache\\QtWebEngine", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");
            deleteDir("QtWebEngine", "5D3CBE6B-69C5-488B-9C4E-0667379DE809");

            session.Log("Begin remove cache for WorkTools Discover");
            deleteDir("apps", "777FCF69-65E4-486C-81AA-3538E87D8727");
            deleteDir("cache\\QtWebEngine", "777FCF69-65E4-486C-81AA-3538E87D8727");
            deleteDir("QtWebEngine", "777FCF69-65E4-486C-81AA-3538E87D8727");

            session.Log("Begin remove cache for WorkTools Input");
            deleteDir("apps", "BDBFEB22-F153-41F5-940F-DAE4DD517699");
            deleteDir("cache\\QtWebEngine", "BDBFEB22-F153-41F5-940F-DAE4DD517699");
            deleteDir("QtWebEngine", "BDBFEB22-F153-41F5-940F-DAE4DD517699");

            session.Log("Begin remove cache for WorkTools Launcher");
            deleteDir("apps", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("cache\\QtWebEngine", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("QtWebEngine", "A0F00606-41E4-44A3-ACBA-CC8DBF65E30A");
            deleteDir("apps", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");
            deleteDir("cache\\QtWebEngine", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");
            deleteDir("QtWebEngine", "55BF50FB-5DA2-4AD8-9E3E-E28B226DB5CE");

            session.Log("if cache folder is null, remove it");
            deleteDir("cache", "");

            session.Log("if FortisDesktopContainer folder is null, remove it");
            deleteDir("", "");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveCameraVersion(Session session)
        {
            session.Log("Begin remove Camera version CustomAction");

            String upgradeCode = "F821976C02E9483599E25D32704EF4D4";
            String upgradeCodeKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
            String UpgradeCodeRK = upgradeCodeKey + reverseGUID(upgradeCode, "");
            session.Log("registryKey: {0}", UpgradeCodeRK);
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey soft = rk.OpenSubKey(UpgradeCodeRK);

            String[] values = soft.GetValueNames();

            String productId = reverseGUID(values[0], "-");
            session.Log("productId: {0}", productId);
            try
            {
                //delete displayversion info in uninstall registry key
                String uninstallKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{" + productId + "}";
                session.Log("uninstallKey: {0}", uninstallKey);
                RegistryKey rk2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                try
                {
                    RegistryKey uninstallRK = rk2.OpenSubKey(uninstallKey, true);
                    uninstallRK.SetValue("DisplayVersion", "");
                    session.Log("DisplayVersion: {0}", (string)uninstallRK.GetValue("DisplayVersion", "DisplayVersion not found."));

                }
                catch (Exception ex)
                {
                    session.Log("Exception: {0}", ex.ToString());
                }

            }
            catch (Exception e1)
            {
                session.Log("Exception: {0}", e1.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveShowVersion(Session session)
        {
            session.Log("Begin remove Show version CustomAction");

            String upgradeCode = "0E6049081691484F9BE9C41935A46185";
            String upgradeCodeKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
            String UpgradeCodeRK = upgradeCodeKey + reverseGUID(upgradeCode, "");
            session.Log("registryKey: {0}", UpgradeCodeRK);
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey soft = rk.OpenSubKey(UpgradeCodeRK);

            String[] values = soft.GetValueNames();

            String productId = reverseGUID(values[0], "-");
            session.Log("productId: {0}", productId);
            try
            {
                //delete displayversion info in uninstall registry key
                String uninstallKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{" + productId + "}";
                session.Log("uninstallKey: {0}", uninstallKey);
                RegistryKey rk2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                try
                {
                    RegistryKey uninstallRK = rk2.OpenSubKey(uninstallKey, true);
                    uninstallRK.SetValue("DisplayVersion", "");
                    session.Log("DisplayVersion: {0}", (string)uninstallRK.GetValue("DisplayVersion", "DisplayVersion not found."));

                }
                catch (Exception ex)
                {
                    session.Log("Exception: {0}", ex.ToString());
                }

            }
            catch (Exception e1)
            {
                session.Log("Exception: {0}", e1.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveStageVersion(Session session)
        {
            session.Log("Begin remove Stage version CustomAction");

            String upgradeCode = "0DF44E4143404D7592052E5A8252D22E";
            String upgradeCodeKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
            String UpgradeCodeRK = upgradeCodeKey + reverseGUID(upgradeCode, "");
            session.Log("registryKey: {0}", UpgradeCodeRK);
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey soft = rk.OpenSubKey(UpgradeCodeRK);

            String[] values = soft.GetValueNames();

            String productId = reverseGUID(values[0], "-");
            session.Log("productId: {0}", productId);
            try
            {
                //delete displayversion info in uninstall registry key
                String uninstallKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{" + productId + "}";
                session.Log("uninstallKey: {0}", uninstallKey);
                RegistryKey rk2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                try
                {
                    RegistryKey uninstallRK = rk2.OpenSubKey(uninstallKey, true);
                    uninstallRK.SetValue("DisplayVersion", "");
                    session.Log("DisplayVersion: {0}", (string)uninstallRK.GetValue("DisplayVersion", "DisplayVersion not found."));

                }
                catch (Exception ex)
                {
                    session.Log("Exception: {0}", ex.ToString());
                }

            }
            catch (Exception e1)
            {
                session.Log("Exception: {0}", e1.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult RemoveCoreVersion(Session session)
        {
            session.Log("Begin remove WorkTools Core version CustomAction");

            String upgradeCode = "EB17D2BB38D1474fA6A95457CC8F4E2E";
            String upgradeCodeKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UpgradeCodes\\";
            String UpgradeCodeRK = upgradeCodeKey + reverseGUID(upgradeCode, "");
            session.Log("UpgradeCodeRK: {0}", UpgradeCodeRK);
            RegistryKey rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey soft = rk.OpenSubKey(UpgradeCodeRK);

            String[] values = soft.GetValueNames();

            String productId = reverseGUID(values[0], "-");
            session.Log("productId: {0}", productId);
            try
            {
                //delete displayversion info in uninstall registry key
                String uninstallKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\{" + productId + "}";
                session.Log("uninstallKey: {0}", uninstallKey);
                RegistryKey rk2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                try
                {
                    RegistryKey uninstallRK = rk2.OpenSubKey(uninstallKey, true);
                    uninstallRK.SetValue("DisplayVersion", "");
                    session.Log("DisplayVersion: {0}", (string)uninstallRK.GetValue("DisplayVersion", "DisplayVersion not found."));

                }
                catch (Exception ex)
                {
                    session.Log("Exception: {0}", ex.ToString());
                }

            }
            catch (Exception e1)
            {
                session.Log("Exception: {0}", e1.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }

        static String reverseGUID(String guid, String space)
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
                if (i == 1 || i == 2 || i == 3 || i == 5)
                {
                    reversed += space;
                }
            }

            return reversed;
        }

        static void deleteDir(String segment, String appId, DialogResult dialogResult = DialogResult.Yes)
        {
            String root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HP\\FortisDesktopContainer\\");
            String path = root + segment;
            String appIdPath = path + "\\" + appId;

            DirectoryInfo rootDir = new DirectoryInfo(root);
            DirectoryInfo pathDir = new DirectoryInfo(path);
            DirectoryInfo appIdPathDir = new DirectoryInfo(appIdPath);

            if (rootDir.Exists)
            {
                if (rootDir.GetDirectories().Length <= 0)
                {
                    rootDir.Delete(true);
                    return;
                }

                if (pathDir.Exists)
                {
                    if (pathDir.GetDirectories().Length <= 0)
                    {
                        pathDir.Delete(true);
                        return;
                    }

                    if (appIdPathDir.Exists)
                    {
                        if (dialogResult == DialogResult.Yes)
                        {
                            appIdPathDir.Delete(true);
                        }
                        else
                        {

                            if (appIdPathDir.GetFiles().Length > 0)
                            {
                                foreach (FileInfo file in appIdPathDir.GetFiles())
                                {
                                    file.Delete();
                                }
                            }

                            if (appIdPathDir.GetDirectories().Length > 0)
                            {
                                foreach (DirectoryInfo subDirectory in appIdPathDir.GetDirectories())
                                {
                                    if (subDirectory.Name != "IndexedDB")
                                    {
                                        subDirectory.Delete(true);
                                    }
                                }
                            }
                            else
                            {
                                appIdPathDir.Delete(true);
                            }
                        }
                    }
                }
            }
            return;
        }
    }
}