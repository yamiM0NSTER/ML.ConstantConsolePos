﻿using System;

namespace ML.PersistentConsole {
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
      WinAPI.SetWindowPos(_consoleHandle, IntPtr.Zero, rect.Left, rect.Top, 0, 0, WinAPI.SWP_NOSIZE);
      WinAPI.SetWindowPos(_consoleHandle, IntPtr.Zero, 0, 0, rect.Width, rect.Height, WinAPI.SWP_NOMOVE);
    }
  }
}
