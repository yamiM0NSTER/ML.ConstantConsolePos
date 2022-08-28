using System;
using System.Runtime.InteropServices;

namespace ML.PersistentConsole {
  internal class WinAPI {
    [DllImport("Kernel32.dll")]
    public static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT {
      public int Left;        // x position of upper-left corner
      public int Top;         // y position of upper-left corner
      public int Right;       // x position of lower-right corner
      public int Bottom;      // y position of lower-right corner

      public static bool operator ==(RECT rect1, RECT rect2) {
        return rect1.Top == rect2.Top && rect1.Right == rect2.Right && rect1.Bottom == rect2.Bottom && rect1.Left == rect2.Left;
      }

      public static bool operator !=(RECT rect1, RECT rect2) => !(rect1 == rect2);

      public static RECT Zero = new RECT{ Bottom = 0, Left = 0, Right = 0, Top = 0 };

      public int Width => Right - Left;
      public int Height => Bottom - Top;
    }

    [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
    public static extern IntPtr SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, int flags);

    public const int SWP_NOZORDER = 0x0004;
    public const int SWP_NOSIZE = 0x0001;
    public const int SWP_SHOWWINDOW = 0x0040;
  }
}
