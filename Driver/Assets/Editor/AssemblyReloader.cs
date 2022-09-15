using UnityEditor;

public class AssemblyReloader
{
    [MenuItem("Compiler/Hard Compile")]
    public static void HardCompile()
    {
        AssetDatabase.Refresh();
        UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
    }

    [MenuItem("Compiler/Hot Compile")]
    public static void HotCompile()
    {
        UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();
    }
}
