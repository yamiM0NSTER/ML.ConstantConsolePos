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

    public WinAPI.RECT GetRect() {
      WinAPI.GetWindowRect(_consoleHandle, out var rect);
      return rect;
    }

    public void SetRect(Settings settings) {
      var rect = settings.ConsoleRect;
      var height = settings.UseFixedSize.Value ? settings.FixedHeight.Value : rect.Height;
      var width = settings.UseFixedSize.Value ? settings.FixedWidth.Value : rect.Width;
      WinAPI.SetWindowPos(_consoleHandle, IntPtr.Zero, rect.Left, rect.Top, width, height, WinAPI.SWP_NOZORDER | WinAPI.SWP_SHOWWINDOW);
    }
  }
}
