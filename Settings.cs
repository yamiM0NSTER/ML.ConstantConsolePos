using MelonLoader;

namespace ML.PersistentConsole {
  internal class Settings {
    MelonPreferences_Category _category;
    MelonPreferences_Entry<WinAPI.RECT> _consoleRect;
    MelonPreferences_Entry<float> _checkPositionEverySeconds;

    public WinAPI.RECT ConsoleRect {
      get {
        return _consoleRect.Value;
      }
      set {
        _consoleRect.Value = value;
        _category.SaveToFile(false);
      }
    }

    public float CheckPositionEverySeconds {
      get {
        return _checkPositionEverySeconds.Value;
      }
      set {
        _checkPositionEverySeconds.Value = value;
        _category.SaveToFile(false);
      }
    }

    public Settings() {
      _category = MelonPreferences.CreateCategory("ML_ConstantConsolePos");
      _consoleRect = _category.CreateEntry("ConsoleRect", WinAPI.RECT.Zero);
      _checkPositionEverySeconds = _category.CreateEntry("CheckPositionEverySeconds", 1.0f);
    }

    public void Save() {
      _category.SaveToFile(false);
    }
  }
}
