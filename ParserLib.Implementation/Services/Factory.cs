﻿using ParserLib.Implementation.Services.Parsers;
using ParserLib.Services;
using ParserLib.Services.Parsers;

namespace ParserLib.Implementation.Services;

internal class Factory: IFactory
{
    private  IFileReader _fileReader;
    internal Factory(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

   public  IParser GetInstance(string file)
    {
        var fileName = file.Split('\\').Last();

        switch (fileName)
        {
            case "capterra.yaml": return new ParseCapterra(_fileReader);
            case "softwareadvice.json": return new ParseSoftwareadvice(_fileReader);
        }

        throw new Exception("Parser not available");
    }
}