using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using HWND = System.IntPtr;
using System.Runtime.InteropServices;

namespace AutoClicker
{
	class Program
	{
		static void Main(string[] args)
		{
			foreach(KeyValuePair<IntPtr, string> window in OpenWindowGetter.GetOpenWindows())
			{
				if (window.Value.Contains("Antimatter"))
					{
						IntPtr handle = window.Key;
						string title = window.Value;

						// This line gets the key and name of the window currently playing antimatter
						// Should be able to start doing click stuff? No need to prompt user at all
						Console.WriteLine("{0}: {1}", handle, title);
					}
			}

			Console.ReadKey();

		}

		public static class OpenWindowGetter
		{
			/// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
			/// <returns>A dictionary that contains the handle and title of all the open windows.</returns>
			public static IDictionary<HWND, string> GetOpenWindows()
			{
				HWND shellWindow = GetShellWindow();
				Dictionary<HWND, string> windows = new Dictionary<HWND, string>();

				EnumWindows(delegate (HWND hWnd, int lParam)
				{
					if (hWnd == shellWindow) return true;
					if (!IsWindowVisible(hWnd)) return true;
					
					int length = GetWindowTextLength(hWnd);
					if (length == 0) return true;

					StringBuilder builder = new StringBuilder(length);
					GetWindowText(hWnd, builder, length + 1);

					windows[hWnd] = builder.ToString();
					return true;

				}, 0);

				return windows;
			}

			private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

			[DllImport("USER32.DLL")]
			private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

			[DllImport("USER32.DLL")]
			private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

			[DllImport("USER32.DLL")]
			private static extern int GetWindowTextLength(HWND hWnd);

			[DllImport("USER32.DLL")]
			private static extern bool IsWindowVisible(HWND hWnd);

			[DllImport("USER32.DLL")]
			private static extern IntPtr GetShellWindow();
		}
	}
}
