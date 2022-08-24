using System;

namespace ML.ConstantConsolePos {
  internal class ConsoleHandler {
    IntPtr _consoleHandle;

    public bool IsPresent => _consoleHandle != IntPtr.Zero;

    public ConsoleHandler() {
      _consoleHandle = WinAPI.GetConsoleWindow();
    }

    public void GetRect(out WinAPI.RECT rect) {
      WinAPI.GetWindowRect(_consoleHandle, out var consoleRect);
      rect = consoleRect;
    }

    public void SetRect(in WinAPI.RECT rect) {
      WinAPI.SetWindowPos(_consoleHandle, IntPtr.Zero, rect.Left, rect.Top, rect.Width, rect.Height, WinAPI.SWP_NOZORDER | WinAPI.SWP_SHOWWINDOW);
    }
  }
}
