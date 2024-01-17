using System.IO.Compression;
using Stll.Playground.Abstractions;

namespace Stll.Playground.Helpers;

public class ZipService : IZipService
{
    public void Unpack(string sourcePath, string outPath)
    {
        ZipFile.ExtractToDirectory(sourcePath, outPath);
    }
}