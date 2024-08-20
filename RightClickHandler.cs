using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Class to create Right Click entry in windows file explorer
//Działa ale tylko z adminem
namespace Wawrov__Organizer
{
    internal class RightClickHandler
    {
        string menuName = "Open with Notepad"; // Name of the menu item
        string command = @"notepad.exe %1";    // Command to execute

        // Path to the registry key
        string regPath = @"*\shell\";
        public void InstallRightClick()
        {
            regPath = @"*\shell\" + menuName;
            try
            {
                // Create or open the key
                using (RegistryKey key = Registry.ClassesRoot.CreateSubKey(regPath))
                {
                    if (key != null)
                    {
                        // Set the default value of the key to the command
                        key.SetValue("", menuName);

                        // Create the command subkey
                        using (RegistryKey commandKey = key.CreateSubKey("command"))
                        {
                            if (commandKey != null)
                            {
                                commandKey.SetValue("", command);
                            }
                        }
                    }
                }

                Console.WriteLine("Context menu entry added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void UninstallRightClick()
        {
            try
            {
                // Delete the key
                Registry.ClassesRoot.DeleteSubKeyTree(regPath);
                Console.WriteLine("Context menu entry removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
