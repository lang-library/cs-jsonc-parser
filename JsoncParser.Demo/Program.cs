﻿using Global;
using Razorvine.Pickle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using Xunit;
//using static MyJson.MyData;
using static Global.SharpJson;
namespace Main;


static class Program
{
    static void TestStrinct()
    {
        ShowDetail = true;
        var o1 = Global.StrictJsonParser.Parse("""
            { "a": 123 }
            """);
        Echo(o1, "o1");
        var exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { a: 123 }
            """);
        });
        exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { "a": /*comment*/123 }
            """);
        });
        Assert.Equal("Illegal JSON: `{ \"a\": /*comment*/123 }`", exception1.Message);
        exception1 = Assert.Throws<ArgumentException>(() => {
            Global.StrictJsonParser.Parse("""
            { "a": //line comment
              123 }
            """);
        });
        Assert.Equal("""
                     Illegal JSON: `{ "a": //line comment
                       123 }`
                     """.Replace("\r\n", "\n"), exception1.Message.Replace("\r\n", "\n"));
    }
    static void TestJsonc()
    {
        ShowDetail = true;
        var o3 = Global.EasyLanguageParser.Parse("""
            { 'a': 123 }
            """);
        Echo(o3, "o3");
        var o4 = Global.EasyLanguageParser.Parse("""
            { a: 123 }
            """);
        Echo(o4, "o4");
        var o5 = Global.EasyLanguageParser.Parse("""
            { "a": /*comment*/123 }
            """);
        Echo(o5, "o5");
        var o6 = Global.EasyLanguageParser.Parse("""
            { "a": //line comment
              123 }
            """);
        Echo(o6, "o6");
        var o7 = Global.EasyLanguageParser.Parse("""
            { abc-def: //line comment
              123 }
            """);
        Echo(o7, "o7");
        var o8 = Global.EasyLanguageParser.Parse("""
            (a-a b-a c-c)
            """);
        Echo(o8, "o8");
    }
    [STAThread]
    static void Main(string[] originalArgs)
    {
        TestStrinct();
        TestJsonc();
        var o1 = new ObjectParser(false).Parse(new { a = 123, b = new object[] { 11, 22, true, new object[] { } } });
        Echo(o1, "o1");
        Console.WriteLine(ObjectParser.ToPrintable(true, o1, "o1(printable)"));
        string json1 = new ObjectParser(false).Stringify(o1, false);
        Echo(json1, "json1");
        string json2 = new ObjectParser(false).Stringify(o1, true);
        Echo(json2, "json2");
        var o2 = EasyLanguageParser.Parse("""
            [11, 22, {}, 33]
            """);
        string json3 = new ObjectParser(false).Stringify(o2, true);
        Echo(json3, "json3");
        //var list01_txt = File.ReadAllText("assets/list01.txt");
        var list01_txt = File.ReadAllText("assets/mydict.txt");
        Echo(list01_txt);
        var list01_bytes = Convert.FromBase64String(list01_txt);
        var unpickler = new Unpickler();
        object result = unpickler.loads(list01_bytes);
        Echo(result);
        Echo(result.GetType().ToString());
        Echo(new CSharpJsonHandler(true, false).Stringify(result, true));
        Echo(new CSharpJsonHandler(true, false).Stringify(result, true, true));
        var o = new ObjectParser(false).Parse(result);
        Echo(new CSharpJsonHandler(true, false).Stringify(o, true));
        Echo(new CSharpJsonHandler(true, false).Stringify(o, true, true));
        var pickler = new Pickler();
        var bytes = pickler.dumps(o);
        var ox = unpickler.loads(bytes);
        Echo(new CSharpJsonHandler(true, false).Stringify(ox, true));
        Echo(new CSharpJsonHandler(true, false).Stringify(ox, true, true));
        var t1 = new ObjectParser(false).Parse(
            new { x = 123, y = 456 });
        Echo(t1, "t1");
        var t2 = new ObjectParser(false).Parse(
            new { y = 456, x = 123 });
        Echo(t2, "t2");
        var t3 = new ObjectParser(false).Parse(
            new { x = 123, y = 4567 });
        Echo(t3, "t3");
        Console.WriteLine(JsoncTester.DeepEquals(t1, t2));
        Console.WriteLine(JsoncTester.DeepEquals(t1, t3));
        Console.WriteLine(JsoncTester.JsonEquals(new ObjectParser(false).Stringify(t1, false), new ObjectParser(false).Stringify(t2, false)));
        Console.WriteLine(JsoncTester.JsonEquals(new ObjectParser(false).Stringify(t1, false), new ObjectParser(false).Stringify(t3, false)));
    }
}