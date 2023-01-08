global using ProjectEuler.Tools;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Numerics;
using HtmlAgilityPack;
using System.IO;
using System.Reflection;

namespace ProjectEuler;

public abstract class Problem
{
    private static readonly string ProjectDir = Environment.CurrentDirectory + @"\..\..\..\Problems\";
    private static readonly string Session = GetSession();

    public Problem()
    {
        string[] names = this.GetType().FullName.Split('.');
        Number = int.Parse(names[1][1..]);
    }

    public string CurrentDirectory => GetDirectory(Number);
    public int Number { get; set; }

    public static bool GenerateClass(int number)
    {
        string filePath = GetFilePath(number, "cs");
        string directory = GetDirectory(number);

        Directory.CreateDirectory(directory);

        if (File.Exists(filePath))
            return false;

        string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory + @"\..\..\..\", "Problem.template"));

        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        data = data.Replace("<STATEMENT>", DownloadStatement(number).Replace("\n", "\r\n"));
        data = data.Replace("<NUMBER>", number.ToString("D4"));
        File.WriteAllText(filePath, data);
        return true;
    }

    public static Problem Get(int number)
    {
        if(GenerateClass(number))
            return null;

        return (Problem)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetTypes().First(t => t.FullName == $"ProjectEuler._{number:D4}"));
    }

    public static string GetSession()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory + @"\..\..\..\", "session.key");

        if (File.Exists(filePath))
            return File.ReadAllText(filePath);

        Console.WriteLine("Missing coockie session. Type session then press enter:");
        string session = Console.ReadLine();
        File.WriteAllText(filePath, session);
        return session;
    }

    public abstract object Solve();

    public override string ToString() => $"{Number:D4}";

    private static string GetDirectory(int number) => Path.Combine(ProjectDir, $"{number:D4}\\");

    private static string GetFilePath(int number, string extension) => Path.Combine(GetDirectory(number), $"{number:D4}.{extension}");

    private static string DownloadStatement(int number)
    {
        HtmlDocument doc = new();
        doc.LoadHtml(HttpHelper.DownloadString(Session, $"https://projecteuler.net/minimal={number}"));

        HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//a");

        Directory.CreateDirectory(GetDirectory(number));

        if (links is null)
            return doc.DocumentNode.InnerText;

        foreach (HtmlNode link in links.Where(l => !l.GetAttributeValue("href", "").Contains("://")))
            File.WriteAllText(Path.Combine(GetDirectory(number), link.InnerText), HttpHelper.DownloadString(Session, $"https://projecteuler.net/{link.GetAttributeValue("href", "")}"));

        return doc.DocumentNode.InnerText;
    }
}