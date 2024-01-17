namespace Stll.Playground.Abstractions;

public interface IZipService
{
    void Unpack(string sourcePath, string outPath);
}