﻿// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class NullFileLoader : IZeFileLoader
{
    public object Load(Type type, FileInfo file)
    {
        return null;
    }

    public bool Match(Type type, FileInfo file) => true;
}
