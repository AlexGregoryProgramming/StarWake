/// <summary>
/// Platform dependent constants.
/// </summary>
public static class Platform {

#if UNITY_EDITOR
    public const bool IsEditor = true;
#else
    public const bool IsEditor = false;
#endif

#if UNITY_STANDALONE
    public const bool IsStandalone = true;
#else
    public const bool IsStandalone = false;
#endif

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    public const bool IsWindows = true;
#else
    public const bool IsWindows = false;
#endif

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
    public const bool IsOSX = true;
#else
    public const bool IsOSX = false;
#endif

#if UNITY_STANDALONE_LINUX || UNITY_ANDROID || UNITY_SAMSUNGTV || UNITY_TIZEN
    public const bool IsLinux = true;
#else
    public const bool IsLinux = false;
#endif

}
