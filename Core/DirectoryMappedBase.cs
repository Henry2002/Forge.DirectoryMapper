using Microsoft.Win32.SafeHandles;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;

namespace Core;


public abstract class DirectoryMappedBase
{
    private protected readonly static string _basePath = string.Empty;
    public static void AppendAllLines(string name, IEnumerable<string> contents)
    {
        File.AppendAllLines(Combined(name), contents);
    }

    public static async Task AppendAllLinesAsync(string name, IEnumerable<string> contents)
    {
        await File.AppendAllLinesAsync(Combined(name), contents);
    }
    public static void AppendAllText(string name, string? text)
    {
        File.AppendAllText(Combined(name), text);
    }

    public static async Task AppendAllTextAsync(string name, string? text)
    {
        await File.AppendAllTextAsync(Combined(name), text);
    }
    public static void AppendText(string name)
    {
        File.AppendText(Combined(name));
    }

    public static void Copy(string name, string path)
    {
        File.Copy(Combined(name), path);
    }

    public static FileStream Create(string name)
    {
        return File.Create(Combined(name));
    }
    public static FileStream Create(string name, int bufferSize)
    {
        return File.Create(Combined(name), bufferSize);
    }

    public static FileSystemInfo CreateSymbolicLink(string name, string path)
    {
        return File.CreateSymbolicLink(Combined(name), path);
    }

    public static void CreateText(string name)
    {
        File.CreateText(Combined(name));
    }

    [SupportedOSPlatform("windows")]
    public static void Decrypt(string name)
    {
        File.Decrypt(Combined(name));

    }
    public static void Delete(string name)
    {
        File.Delete(Combined(name));
    }

    [SupportedOSPlatform("windows")]
    public static void Encrypt(string name)
    {
        File.Encrypt(Combined(name));
    }

    public static bool Exists(string name)
    {
        return File.Exists(Combined(name));
    }

    public static FileAttributes GetAttributes(SafeFileHandle fileHandle)
    {
        return File.GetAttributes(fileHandle);
    }

    public static FileAttributes GetAttributes(string name)
    {
        return File.GetAttributes(Combined(name));
    }

    public static DateTime GetCreationTime(SafeFileHandle fileHandle)
    {
        return File.GetCreationTime(fileHandle);
    }

    public static DateTime GetCreationTime(string name)
    {
        return File.GetCreationTime(Combined(name));
    }

    public static DateTime GetCreationTimeUtc(SafeFileHandle fileHandle)
    {
        return File.GetCreationTimeUtc(fileHandle);
    }

    public static DateTime GetCreationTimeUtc(string name)
    {
        return File.GetCreationTimeUtc(Combined(name));
    }

    public static DateTime GetLastAccessTime(SafeFileHandle fileHandle)
    {
        return File.GetLastAccessTime(fileHandle);
    }

    public static DateTime GetLastAccessTime(string name)
    {
        return File.GetLastAccessTime(Combined(name));
    }

    public static DateTime GetLastAccessTimeUtc(SafeFileHandle fileHandle)
    {
        return File.GetLastAccessTimeUtc(fileHandle);
    }

    public static DateTime GetLastAccessTimeUtc(string name)
    {
        return File.GetLastAccessTimeUtc(Combined(name));
    }

    public static DateTime GetLastWriteTime(SafeFileHandle fileHandle)
    {
        return File.GetLastWriteTime(fileHandle);
    }

    public static DateTime GetLastWriteTime(string name)
    {
        return File.GetLastWriteTime(Combined(name));
    }

    public static DateTime GetLastWriteTimeUtc(SafeFileHandle fileHandle)
    {
        return File.GetLastWriteTimeUtc(fileHandle);
    }

    public static DateTime GetLastWriteTimeUtc(string name)
    {
        return File.GetLastWriteTimeUtc(Combined(name));
    }

    [UnsupportedOSPlatform("windows")]
    public static UnixFileMode GetUnixFileMode(SafeFileHandle fileHandle)
    {
        return File.GetUnixFileMode(fileHandle);
    }

    [UnsupportedOSPlatform("windows")]
    public static UnixFileMode GetUnixFileMode(string name)
    {
        return File.GetUnixFileMode(Combined(name));
    }

    public static void Move(string name, string path)
    {
        File.Move(Combined(name), path); 
    }

    public static void Move(string name, string path, bool overwrite)
    {
        File.Move(Combined(name), path, overwrite);
    }

    public static FileStream Open(string name, FileMode mode)
    {
        return File.Open(Combined(name), mode);
    }

    public static FileStream Open(string name, FileMode mode, FileAccess access)
    {
        return File.Open(Combined(name), mode, access);
    }

    public static FileStream Open(string name, FileMode mode, FileAccess access, FileShare share)
    {
        return File.Open(Combined(name),mode, access, share);   
    }

    public static FileStream Open(string path, FileStreamOptions options)
    {
        return File.Open(Combined(path), options);
    }

    public static SafeFileHandle OpenHandle(string path, FileMode mode = FileMode.Open, FileAccess access = FileAccess.Read,
            FileShare share = FileShare.Read, FileOptions options = FileOptions.None, long preallocationSize = 0)
    {
        return File.OpenHandle(Combined(path), mode, access, share, options,  preallocationSize);
    }

    public static FileStream OpenRead(string name)
    {
        return File.OpenRead(Combined(name));
    }

    public static StreamReader OpenText(string name)
    {
        return File.OpenText(Combined(name));   
    }

    public static FileStream OpenWrite(string name)
    {
        return File.OpenWrite(Combined(name));  
    }

    public static byte[] ReadAllBytes(string name)
    {
        return File.ReadAllBytes(Combined(name));
    }

    public static async Task<byte[]> ReadAllBytesAsync(string name, CancellationToken cancellationToken = default)
    {
        return await File.ReadAllBytesAsync(Combined(name), cancellationToken);  
    }

    public static IEnumerable<string> ReadAllLines(string name) 
    {
        return File.ReadAllLines(Combined(name));  
    }

    public static IEnumerable<string> ReadAllLines(string path, Encoding encoding)
    {
       
        return File.ReadAllLines(Combined(path), encoding);   
    }

    public static async Task<IEnumerable<string>> ReadAllLinesAsync(string name, CancellationToken cancellationToken = default)
    {
        return await File.ReadAllLinesAsync(Combined(name), cancellationToken);  
    }

    public static IEnumerable<string> ReadLines(string name)
    {
        return File.ReadLines(Combined(name));
    }

    public static IEnumerable<string> ReadLines(string path, Encoding encoding)
    {
        return File.ReadLines(Combined(path), encoding);
    }

    public static IAsyncEnumerable<string> ReadLinesAsync(string name)
    {
        return File.ReadLinesAsync(Combined(name));
    }

    public static string ReadAllText(string name)
    {
        return File.ReadAllText(Combined(name));
    }
    
    public static async Task<string> ReadAllTextAsync(string name, CancellationToken cancellationToken = default)
    {
        return await File.ReadAllTextAsync(Combined(name), cancellationToken);    
    }

    public static void Replace(string sourceFileName, string destinationFileName, string? destinationFileBackupName)
    {
        File.Replace(Combined(sourceFileName), Combined(destinationFileName), CombinedNullable(destinationFileBackupName));
    }
  
    public static FileSystemInfo? ResolveLinkTarget(string linkPath, bool returnFinalTarget)
    {
        return File.ResolveLinkTarget(Combined(linkPath), returnFinalTarget);
    }

    public static void SetAttributes(SafeFileHandle handle, FileAttributes attributes)
    {
        File.SetAttributes(handle, attributes);
    }

    public static void SetCreationTime(SafeFileHandle handle, DateTime time)
    {
        File.SetCreationTime(handle, time);
    }

    public static void SetCreationTimeUtc(SafeFileHandle handle, DateTime time)
    {
        File.SetCreationTimeUtc(handle, time);
    }

    public static void SetLastAccessTime(SafeFileHandle handle, DateTime time)
    {
        File.SetLastAccessTime(handle, time);
    }

    public static void SetLastAccessTimeUtc(SafeFileHandle handle, DateTime time)
    {
        File.SetLastAccessTimeUtc(handle, time);
    }

    public static void SetLastWriteTime(SafeFileHandle handle, DateTime time)
    {
        File.SetLastAccessTime(handle, time);
    }

    public static void SetLastWriteTimeUtc(SafeFileHandle handle, DateTime time)
    {
        File.SetLastAccessTimeUtc(handle, time);
    }

    [UnsupportedOSPlatform("windows")]
    public static void SetUnixFileMode(SafeFileHandle handle, UnixFileMode mode)
    {
        File.SetUnixFileMode(handle, mode);
    }

    public static void WriteAllBytes(string name, byte[] bytes)
    {
        File.WriteAllBytes(Combined(name), bytes);
    }

    public static async Task WriteAllBytesAsync(string name, byte[] bytes)
    {
        
        await File.WriteAllBytesAsync(Combined(name), bytes);
    }

    public static void WriteAllLines(string name, IEnumerable<string> lines)
    {
        File.WriteAllLines(Combined(name), lines);
    }

    public static async Task WriteAllLinesAsync(string name, IEnumerable<string> lines)
    {

        await File.WriteAllLinesAsync(Combined(name), lines);
    }

    public static void WriteAllText(string name, string? text)
    {
        File.WriteAllText(Combined(name), text);
    }

    public static async Task WriteAllTextAsync(string name, string? text)
    {

        await File.WriteAllTextAsync(Combined(name), text);
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static string Combined(string name)
    {
        return Path.Combine(_basePath, name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static string? CombinedNullable(string? name)
    {
        if (name is null) return null;

        return Path.Combine(_basePath, name);
    }
}

