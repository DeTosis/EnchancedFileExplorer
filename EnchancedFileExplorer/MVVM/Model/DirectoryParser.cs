using System.IO;

namespace EnchancedFileExplorer.MVVM.Model; 
class DirectoryParser {
    public List<string> directoryItems { get; } = new();
    public bool ParseDirectory(string path) {
        if (!Directory.Exists(path)) return false;

        foreach (var folder in Directory.GetDirectories(path))
            directoryItems.Add(folder);

        foreach (var file in Directory.GetFiles(path))
            directoryItems.Add(file);

        return true;
    }
}
