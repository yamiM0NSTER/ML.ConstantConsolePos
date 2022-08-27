using MelonLoader;

namespace ML.ConstantConsolePos {
  internal class Settings {
    MelonPreferences_Category _category;
    MelonPreferences_Entry<WinAPI.RECT> _consoleRect;
    MelonPreferences_Entry<float> _checkPositionEverySeconds;

    internal readonly MelonPreferences_Entry<bool> UseFixedSize;
    internal readonly MelonPreferences_Entry<int> FixedHeight;
    internal readonly MelonPreferences_Entry<int> FixedWidth;

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



    public Settings(ConsoleHandler console) {
      _category = MelonPreferences.CreateCategory("ML_ConstantConsolePos");
      _consoleRect = _category.CreateEntry("ConsoleRect", WinAPI.RECT.Zero);
      _checkPositionEverySeconds = _category.CreateEntry("CheckPositionEverySeconds", 1.0f);

      UseFixedSize = _category.CreateEntry("UseFixedWindowSize", false);
      FixedHeight = _category.CreateEntry("FixedHeight", console.GetRect().Height);
      FixedWidth = _category.CreateEntry("FixedWidth", console.GetRect().Width);
    }

    public void Save() {
      _category.SaveToFile(false);
    }
  }
}
