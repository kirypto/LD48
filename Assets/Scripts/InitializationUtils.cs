using System;
using UnityEditor;

internal class InitializationError : ArgumentException
{
    public InitializationError(string message) : base(message) { }
}

internal static class InitializationUtils
{
    internal static void StopAndThrowInitializationError(string message)
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        throw new InitializationError(message);
    }
}
