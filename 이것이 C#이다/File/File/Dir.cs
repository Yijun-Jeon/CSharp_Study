﻿using System;
using System.Linq;
using System.IO;

namespace Dir;
class MainApp
{
    static void Main(string[] args)
    {
        string directory;
        if (args.Length < 1)
            directory = ".";
        else
            directory = args[0];

        Console.WriteLine($"{directory} directory Info");
        Console.WriteLine("- Directories : ");

        // 하위 디렉터리 목록 조회
        var directories = (from dir in Directory.GetDirectories(directory)
                           let info = new DirectoryInfo(dir)
                           select new
                           {
                               Name = info.Name,
                               Attribute = info.Attributes
                           }).ToList();

        foreach (var d in directories)
            Console.WriteLine($"{d.Name} : {d.Attribute}");


        Console.WriteLine("- Files : ");

        // 하위 파일 목록 조회 
        var files = (from file in Directory.GetFiles(directory)
                     let info = new FileInfo(file)
                     select new
                     {
                         Name = info.Name,
                         FileSize = info.Length,
                         Attribute = info.Attributes
                     }).ToList();

        foreach (var f in files)
            Console.WriteLine($"{f.Name} : {f.FileSize}, {f.Attribute}");
    }
}

