using MelonLoader;
using UnityEngine;
using System.Collections;

namespace ML.ConstantConsolePos {
  public class PluginMain : MelonPlugin {
    object _co_CheckConsolePos = null;
    ConsoleHandler _console = null;
    Settings _settings = null;
    WinAPI.RECT _consoleRect;

    public override void OnPreInitialization() {
      _settings = new Settings();
      _console = new ConsoleHandler();

      if(!_console.IsPresent)
        return;

      // Load settings & place console
      if(_settings.ConsoleRect == WinAPI.RECT.Zero) {
        _console.GetRect(out var rect);
        _settings.ConsoleRect = rect;
        _consoleRect = rect;
      } else {
        _console.SetRect(_settings.ConsoleRect);
        _consoleRect = _settings.ConsoleRect;
      }
    }

    public override void OnApplicationStart() {
      //_co_CheckConsolePos = MelonCoroutines.Start(Co_CheckConsolePos());
    }

    public override void OnApplicationLateStart() {
      if(!_console.IsPresent)
        return;

      _co_CheckConsolePos = MelonCoroutines.Start(Co_CheckConsolePos());
    }

    public override void OnApplicationQuit() {
      if(!_console.IsPresent)
        return;

      MelonCoroutines.Stop(_co_CheckConsolePos);
      // Get current position & save settings
      _console.GetRect(out var rect);
      _settings.ConsoleRect = rect;
    }

    WaitForSeconds _waitForSeconds = null;
    IEnumerator Co_CheckConsolePos() {
      _waitForSeconds = new WaitForSeconds(_settings.CheckPositionEverySeconds);
      while(true) {
        yield return _waitForSeconds;

        _console.GetRect(out var rect);

        if(rect == _consoleRect)
          continue;

        _settings.ConsoleRect = rect;
        _consoleRect = rect;
      }
    }
  }
}
