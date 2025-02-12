using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;
using System.Text.RegularExpressions;
using Microsoft.UI.Xaml.Documents;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.System.Preview;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace C1OS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MorePage : Page
    {


        public MorePage()
        {
            this.InitializeComponent();
            
        }

        public string[] PTable =
            ["H","He",
             "Li","Be","B","C","N","O","F","Ne",
             "Na","Mg","Al","Si","P","S","Cl","Ar",
             "K","Ca","Sc","Ti","V","Cr","Mn","Fe","Co","Ni","Cu","Zn","Ga","Ge","As","Se","Br","Kr",
             "Rb","Sr","Y","Zr","Nb","Mo","Tc","Ru","Rh","Pd","Ag","Cd","In","Sn","Sb","Te","I","Xe",
             "Cs","Ba","La","Ce","Pr","Nd","Pm","Sm","Eu","Gb","Tb","Dy","Ho","Er","Tm","Yb","Lu","Hf","Ta","W","Re","Os","Ir","Pt","Au","Hg","Tl","Pb","Bi","Po","At","Rn",
             "Fr","Ra","Ac","Th","Pa","U","Np","Pu","Am","Cm","Bk","Cf","Es","Fm","Md","No","Lr","Rf","Db","Sg","Bh","Hs","Mt","Ds","Rg","Cn","Nh","Fl","Mc","Lv","Ts","Og"];

        private void GetSeewoPassword(object sender, RoutedEventArgs args)
        {
            var package = new DataPackage();
            package.SetText("g304224g");
            Clipboard.SetContent(package);
            ToggleThemeTeachingTip1.IsOpen = true;
        }

        private void LittleHaagentusGoToWork(object sender, RoutedEventArgs args)
        {
            LittleHaagentus.Text = "🤓正在分析...";
            string[] things1 = LittleHaagentusInput.Text.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (things1.Length == 2) {
                string[] things2 = things1[0].Split('+', StringSplitOptions.RemoveEmptyEntries);
                string[] things3 = things1[1].Split('+', StringSplitOptions.RemoveEmptyEntries);
                List<List<string>> things23 = [], things33 = [];
                List<List<ulong>> things24 = [], things34 = [];
                List<string> things25 = [], things35 = [],helperS = [];
                List<ulong> things26 = [], things36 = [],helperU = [],Output2 = [],Output3 = [];
                //------------------------------------------------------------读取反应物-----------------------------------------------------------------
                try
                {
                foreach (string thing1 in things2)
                    {
                    List<string> things21 = [];
                    List<ulong> things22 = [];
                    string thing = thing1;
                        var x = 0;
                        string y;
                        thing = thing.Replace(" ","");
                            for (; x < thing.Length; x++)
                        {
                            y = thing.Substring(x, 1);
                          if (ABC().Matches(y).Count == 1)
                          {
                            SecondTry1:
                            if (x < thing.Length - 1)
                            {
                                x++;
                                y = thing.Substring(x, 1);
                                if (abc().Matches(y).Count == 1)
                                {
                                    y = thing.Substring(x - 1, 2);
                                    if (PTable.Contains(y) == true)
                                    {
                                    ThirdTry1:
                                        if (x < thing.Length - 1)
                                        {
                                            x++;
                                            y = thing.Substring(x, 1);
                                            if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                            {
                                                x--;
                                                y = thing.Substring(x - 1, 2);
                                                if (things21.Contains(y) == true)
                                                {
                                                    things22[things21.IndexOf(y)] += 1;
                                                }
                                                else
                                                {
                                                    things21.Add(y);
                                                    things22.Add(1);
                                                }
                                            }
                                            else if (num().Matches(y).Count == 1)
                                            {
                                                var z = 0;
                                                ulong zz;
                                                while (x <= thing.Length - 1 && num().Matches(y).Count != 0)
                                                {
                                                    y = thing.Substring(x, 1);
                                                    x++;
                                                    z++;
                                                }
                                                x--;
                                                if (z != 1)
                                                {
                                                    z--;
                                                    x--;
                                                }
                                                y = thing.Substring(x - z - 1, 2);
                                                zz = Convert.ToUInt64(thing.Substring(x - z + 1, z));
                                                if (PTable.Contains(y) == true)
                                                {
                                                    if (things21.Contains(y) == true)
                                                    {
                                                        things22[things21.IndexOf(y)] += zz;
                                                    }
                                                    else
                                                    {
                                                        things21.Add(y);
                                                        things22.Add(zz);
                                                    }
                                                }
                                                else
                                                {
                                                    LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                                    return;
                                                }
                                            }
                                            else if (y == " ") { goto ThirdTry1; }
                                            else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                        }
                                        else
                                        {
                                            if (things21.Contains(y) == true)
                                            {
                                                things22[things21.IndexOf(y)] += 1;
                                            }
                                            else
                                            {
                                                things21.Add(y);
                                                things22.Add(1);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                        return;
                                    }
                                }
                                else if (num().Matches(y).Count == 1)
                                {
                                        var z = 0;
                                        ulong zz;
                                        while (x <= thing.Length - 1 && num().Matches(y).Count != 0)
                                        {
                                            y = thing.Substring(x, 1);
                                            x++;
                                            z++;
                                        }
                                        if (num().Matches(y).Count == 0)
                                        {
                                            y = thing.Substring(x - z - 1, 1);
                                            zz = Convert.ToUInt64(thing.Substring(x - z, z - 1));
                                            x -= 2;
                                        }
                                        else 
                                        {
                                            y = thing.Substring(x - z - 1, 1);
                                            zz = Convert.ToUInt64(thing.Substring(x - z, z));
                                            x--;
                                        }
                                        if (PTable.Contains(y) == true)
                                        {
                                            if (things21.Contains(y) == true)
                                            {
                                                things22[things21.IndexOf(y)] += zz;
                                            }
                                            else
                                            {
                                                things21.Add(y);
                                                things22.Add(zz);
                                            }
                                        }
                                        else
                                        {
                                            LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                            return;
                                        }
                                    }
                                else if (y == " ") { goto SecondTry1; }
                                else
                                {
                                    x--;
                                    y = thing.Substring(x, 1);
                                    if (PTable.Contains(y) == true)
                                    {
                                        if (things21.Contains(y) == true)
                                        {
                                            things22[things21.IndexOf(y)] += 1;
                                        }
                                        else
                                        {
                                            things21.Add(y);
                                            things22.Add(1);
                                        }
                                    }
                                    else
                                    {
                                        LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (PTable.Contains(y) == true)
                                {
                                    if (things21.Contains(y) == true)
                                    {
                                        things22[things21.IndexOf(y)] += 1;
                                    }
                                    else
                                    {
                                        things21.Add(y);
                                        things22.Add(1);
                                    }
                                }
                                else
                                {
                                    LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“{thing1}”中）";
                                    return;
                                }
                            }
                          }
                          else if (y == "(")
                          {
                            if (thing.Contains(')') == false)
                            {
                                LittleHaagentus.Text = $"❌未找到括号的结束标记“）”\n（在化学式“{thing1}”中）";
                                    return;
                                }
                            else
                            {
                                var a = thing.IndexOf(')');
                            PartyTry1:
                                if (a == thing.Length - 1)
                                {
                                    LittleHaagentus.Text = $"❌括号后应当有数量（数量为1请省略括号），但在“{thing.Substring(x, a - x + 1)}”后未找到数量\n（在化学式“{thing1}”中）";
                                    return;
                                }
                                else
                                {
                                    a++;
                                    y = thing.Substring(a, 1);
                                    if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                    {
                                        LittleHaagentus.Text = $"❌括号后应当有数量，但在“{thing[x..a]}”后未找到数量\n（在化学式“{thing1}”中）";
                                            return;
                                    }
                                    else if (num().Matches(y).Count == 1)
                                    {
                                        var z = 0;
                                        ulong zz;
                                        while (a <= thing.Length - 1 && num().Matches(y).Count != 0)
                                        {
                                            y = thing.Substring(a, 1);
                                            a++;
                                            z++;
                                        }
                                            if (abc().Matches(y).Count == 1)
                                            { LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                            a--;
                                        if (z != 1)
                                        {
                                            z--;
                                            a--;
                                        }
                                        y = thing[(x + 1)..(a - z)];
                                        zz = Convert.ToUInt64(thing.Substring(a - z + 1, z));
                                        thing = thing.Remove(a - z, z + 1);
                                        thing = thing.Remove(x, 1);
                                        for (; zz > 1; zz--)
                                        {
                                            thing += y;
                                        }
                                        x--;
                                    }
                                    else if (y == " ") { goto PartyTry1; }
                                    else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                }
                            }

                               
                          }
                          else if (y == ")")
                          {
                                    LittleHaagentus.Text = $"❌未找到括号的开始标记“（”\n（在化学式“{thing1}”中）";
                                    return;
                          }
                          else if (y == "[")
                          {
                                if (thing.Contains(']') == false)
                                {
                                    LittleHaagentus.Text = $"❌未找到括号的结束标记“]”\n（在化学式“{thing1}”中）";
                                    return;
                                }
                                else
                                {
                                    var a = thing.IndexOf(']');
                                PartyTry1:
                                    if (a == thing.Length - 1)
                                    {
                                        LittleHaagentus.Text = $"❌括号后应当有数量（数量为1请省略括号），但在“{thing.Substring(x, a - x + 1)}”后未找到数量\n（在化学式“{thing1}”中）";
                                        return;
                                    }
                                    else
                                    {
                                        a++;
                                        y = thing.Substring(a, 1);
                                        if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                        {
                                            LittleHaagentus.Text = $"❌括号后应当有数量，但在“{thing[x..a]}”后未找到数量\n（在化学式“{thing1}”中）";
                                            return;
                                        }
                                        else if (num().Matches(y).Count == 1)
                                        {
                                            var z = 0;
                                            ulong zz;
                                            while (a <= thing.Length - 1 && num().Matches(y).Count != 0)
                                            {
                                                y = thing.Substring(a, 1);
                                                a++;
                                                z++;
                                            }
                                            if (abc().Matches(y).Count == 1) 
                                            { LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                            a--;
                                            if (z != 1)
                                            {
                                                z--;
                                                a--;
                                            }
                                            y = thing[(x + 1)..(a - z)];
                                            zz = Convert.ToUInt64(thing.Substring(a - z + 1, z));
                                            thing = thing.Remove(a - z, z + 1);
                                            thing = thing.Remove(x, 1);
                                            for (; zz > 1; zz--)
                                            {
                                                thing += y;
                                            }
                                            x--;
                                        }
                                        else if (y == " ") { goto PartyTry1; }
                                        else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                    }


                                }
                          }
                          else if (y == "]")
                          {
                                LittleHaagentus.Text = $"❌未找到括号的开始标记“[”\n（在化学式“{thing1}”中）";
                                return;
                          }
                          else if (y != " "&& y != "=" && y != "≡")
                          {
                                LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“{thing1}”中）";
                                return;
                          }
                        }
                    things23.Add(things21);
                    things24.Add(things22);
                    foreach (string a in things21)
                    {
                        if (things25.Contains(a) == true)
                        {
                            things26[things25.IndexOf(a)] += things22[things21.IndexOf(a)];
                        }
                        else 
                        {
                            things25.Add(a);
                            things26.Add(things22[things21.IndexOf(a)]);
                        }
                    }
                }
                    string debug1 = null, debug2 = null;
                    foreach (string debug in things25)
                    {
                        debug1 += debug + "，";
                    }
                    foreach (ulong debug in things26)
                    {
                        debug2 += debug.ToString() + "，";
                    }
//                    LittleHaagentus.Text = $"调试(下一阶段将访问生成物）\n{debug1}\n{debug2}\n";
                }
                catch(Exception a) { LittleHaagentus.Text = $"❌在读取反应物时出现问题，请检查物质是否符合客观事实！\n{a}"; return; }

                //------------------------------------------------------------读取生成物-----------------------------------------------------------------

                try
                {
                    foreach (string thing1 in things3)
                    {
                        List<string> things31 = [];
                        List<ulong> things32 = [];
                        string thing = thing1;
                        var x = 0;
                        string y;
                        thing = thing.Replace(" ", "");
                        for (; x < thing.Length; x++)
                        {
                            y = thing.Substring(x, 1);
                            if (ABC().Matches(y).Count == 1)
                            {
                            SecondTry1:
                                if (x < thing.Length - 1)
                                {
                                    x++;
                                    y = thing.Substring(x, 1);
                                    if (abc().Matches(y).Count == 1)
                                    {
                                        y = thing.Substring(x - 1, 2);
                                        if (PTable.Contains(y) == true)
                                        {
                                        ThirdTry1:
                                            if (x < thing.Length - 1)
                                            {
                                                x++;
                                                y = thing.Substring(x, 1);
                                                if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                                {
                                                    x--;
                                                    y = thing.Substring(x - 1, 2);
                                                    if (things31.Contains(y) == true)
                                                    {
                                                        things32[things31.IndexOf(y)] += 1;
                                                    }
                                                    else
                                                    {
                                                        things31.Add(y);
                                                        things32.Add(1);
                                                    }
                                                }
                                                else if (num().Matches(y).Count == 1)
                                                {
                                                    var z = 0;
                                                    ulong zz;
                                                    while (x <= thing.Length - 1 && num().Matches(y).Count != 0)
                                                    {
                                                        y = thing.Substring(x, 1);
                                                        x++;
                                                        z++;
                                                    }
                                                    x--;
                                                    if (z != 1)
                                                    {
                                                        z--;
                                                        x--;
                                                    }
                                                    y = thing.Substring(x - z - 1, 2);
                                                    zz = Convert.ToUInt64(thing.Substring(x - z + 1, z));
                                                    if (PTable.Contains(y) == true)
                                                    {
                                                        if (things31.Contains(y) == true)
                                                        {
                                                            things32[things31.IndexOf(y)] += zz;
                                                        }
                                                        else
                                                        {
                                                            things31.Add(y);
                                                            things32.Add(zz);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                                        return;
                                                    }
                                                }
                                                else if (y == " ") { goto ThirdTry1; }
                                                else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                            }
                                            else
                                            {
                                                if (things31.Contains(y) == true)
                                                {
                                                    things32[things31.IndexOf(y)] += 1;
                                                }
                                                else
                                                {
                                                    things31.Add(y);
                                                    things32.Add(1);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                            return;
                                        }
                                    }
                                    else if (num().Matches(y).Count == 1)
                                    {
                                        var z = 0;
                                        ulong zz;
                                        while (x <= thing.Length - 1 && num().Matches(y).Count != 0)
                                        {
                                            y = thing.Substring(x, 1);
                                            x++;
                                            z++;
                                        }
                                        if (num().Matches(y).Count == 0)
                                        {
                                            y = thing.Substring(x - z - 1, 1);
                                            zz = Convert.ToUInt64(thing.Substring(x - z, z - 1));
                                            x -= 2;
                                        }
                                        else
                                        {
                                            y = thing.Substring(x - z - 1, 1);
                                            zz = Convert.ToUInt64(thing.Substring(x - z, z));
                                            x--;
                                        }
                                        if (PTable.Contains(y) == true)
                                        {
                                            if (things31.Contains(y) == true)
                                            {
                                                things32[things31.IndexOf(y)] += zz;
                                            }
                                            else
                                            {
                                                things31.Add(y);
                                                things32.Add(zz);
                                            }
                                        }
                                        else
                                        {
                                            LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                            return;
                                        }
                                    }
                                    else if (y == " ") { goto SecondTry1; }
                                    else
                                    {
                                        x--;
                                        y = thing.Substring(x, 1);
                                        if (PTable.Contains(y) == true)
                                        {
                                            if (things31.Contains(y) == true)
                                            {
                                                things32[things31.IndexOf(y)] += 1;
                                            }
                                            else
                                            {
                                                things31.Add(y);
                                                things32.Add(1);
                                            }
                                        }
                                        else
                                        {
                                            LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“ {thing1} ”中）";
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    if (PTable.Contains(y) == true)
                                    {
                                        if (things31.Contains(y) == true)
                                        {
                                            things32[things31.IndexOf(y)] += 1;
                                        }
                                        else
                                        {
                                            things31.Add(y);
                                            things32.Add(1);
                                        }
                                    }
                                    else
                                    {
                                        LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“{thing1}”中）";
                                        return;
                                    }
                                }
                            }
                            else if (y == "(")
                            {
                                if (thing.Contains(')') == false)
                                {
                                    LittleHaagentus.Text = $"❌未找到括号的结束标记“）”\n（在化学式“{thing1}”中）";
                                    return;
                                }
                                else
                                {
                                    var a = thing.IndexOf(')');
                                PartyTry1:
                                    if (a == thing.Length - 1)
                                    {
                                        LittleHaagentus.Text = $"❌括号后应当有数量（数量为1请省略括号），但在“{thing.Substring(x, a - x + 1)}”后未找到数量\n（在化学式“{thing1}”中）";
                                        return;
                                    }
                                    else
                                    {
                                        a++;
                                        y = thing.Substring(a, 1);
                                        if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                        {
                                            LittleHaagentus.Text = $"❌括号后应当有数量，但在“{thing[x..a]}”后未找到数量\n（在化学式“{thing1}”中）";
                                            return;
                                        }
                                        else if (num().Matches(y).Count == 1)
                                        {
                                            var z = 0;
                                            ulong zz;
                                            while (a <= thing.Length - 1 && num().Matches(y).Count != 0)
                                            {
                                                y = thing.Substring(a, 1);
                                                a++;
                                                z++;
                                            }
                                            if (abc().Matches(y).Count == 1)
                                            { LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                            a--;
                                            if (z != 1)
                                            {
                                                z--;
                                                a--;
                                            }
                                            y = thing[(x + 1)..(a - z)];
                                            zz = Convert.ToUInt64(thing.Substring(a - z + 1, z));
                                            thing = thing.Remove(a - z, z + 1);
                                            thing = thing.Remove(x, 1);
                                            for (; zz > 1; zz--)
                                            {
                                                thing += y;
                                            }
                                            x--;
                                        }
                                        else if (y == " ") { goto PartyTry1; }
                                        else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                    }
                                }


                            }
                            else if (y == ")")
                            {
                                LittleHaagentus.Text = $"❌未找到括号的开始标记“（”\n（在化学式“{thing1}”中）";
                                return;
                            }
                            else if (y == "[")
                            {
                                if (thing.Contains(']') == false)
                                {
                                    LittleHaagentus.Text = $"❌未找到括号的结束标记“]”\n（在化学式“{thing1}”中）";
                                    return;
                                }
                                else
                                {
                                    var a = thing.IndexOf(']');
                                PartyTry1:
                                    if (a == thing.Length - 1)
                                    {
                                        LittleHaagentus.Text = $"❌括号后应当有数量（数量为1请省略括号），但在“{thing.Substring(x, a - x + 1)}”后未找到数量\n（在化学式“{thing1}”中）";
                                        return;
                                    }
                                    else
                                    {
                                        a++;
                                        y = thing.Substring(a, 1);
                                        if (ABC().Matches(y).Count == 1 || y == "(" || y == "[" || y == ")" || y == "]" || y == "=" || y == "≡")
                                        {
                                            LittleHaagentus.Text = $"❌括号后应当有数量，但在“{thing[x..a]}”后未找到数量\n（在化学式“{thing1}”中）";
                                            return;
                                        }
                                        else if (num().Matches(y).Count == 1)
                                        {
                                            var z = 0;
                                            ulong zz;
                                            while (a <= thing.Length - 1 && num().Matches(y).Count != 0)
                                            {
                                                y = thing.Substring(a, 1);
                                                a++;
                                                z++;
                                            }
                                            if (abc().Matches(y).Count == 1)
                                            { LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                            a--;
                                            if (z != 1)
                                            {
                                                z--;
                                                a--;
                                            }
                                            y = thing[(x + 1)..(a - z)];
                                            zz = Convert.ToUInt64(thing.Substring(a - z + 1, z));
                                            thing = thing.Remove(a - z, z + 1);
                                            thing = thing.Remove(x, 1);
                                            for (; zz > 1; zz--)
                                            {
                                                thing += y;
                                            }
                                            x--;
                                        }
                                        else if (y == " ") { goto PartyTry1; }
                                        else { LittleHaagentus.Text = $"❌找到了未知的字符“{y}”\n（在化学式“  {thing1}  ”中）"; return; }
                                    }


                                }
                            }
                            else if (y == "]")
                            {
                                LittleHaagentus.Text = $"❌未找到括号的开始标记“[”\n（在化学式“{thing1}”中）";
                                return;
                            }
                            else if (y != " " && y != "=" && y != "≡")
                            {
                                LittleHaagentus.Text = $"❌找到了未知的元素“{y}”\n（在化学式“{thing1}”中）";
                                return;
                            }
                        }
                        things33.Add(things31);
                        things34.Add(things32);
                        foreach (string a in things31)
                        {
                            if (things35.Contains(a) == true)
                            {
                                things36[things35.IndexOf(a)] += things32[things31.IndexOf(a)];
                            }
                            else
                            {
                                things35.Add(a);
                                things36.Add(things32[things31.IndexOf(a)]);
                            }
                        }
                    }
                    string debug1 = null, debug2 = null;
                    foreach (string debug in things35)
                    {
                        debug1 += debug + "，";
                    }
                    foreach (ulong debug in things36)
                    {
                        debug2 += debug.ToString() + "，";
                    }
//                    LittleHaagentus.Text += $"调试(下一阶段将配平）\n{debug1}\n{debug2}\n";
                }
                catch (Exception a) { LittleHaagentus.Text = $"❌在读取生成物时出现问题，请检查物质是否符合客观事实！\n{a}"; return; }

                //--------------------------------------------------配平！---------------------------------------------------------------------
                try 
                {
                    foreach (string thing in things35)
                    {
                        if (things25.Contains(thing) == false)
                        { LittleHaagentus.Text = $"❌反应物中缺少生成物中含有的元素{thing}，请检查！"; return; }
                    }
                    foreach (string thing in things25)
                    {
                        if (things35.Contains(thing) == false)
                        { LittleHaagentus.Text = $"❌生成物中缺少反应物中含有的元素{thing}，请检查！"; return; }
                        else
                        {
                            helperS.Add(thing);
                            helperU.Add(things36[things35.IndexOf(thing)]);
                        }
                    }
                    things35 = helperS;
                    things36 = helperU; 
                    foreach (List<string> a in things23)
                    { Output2.Add(1); }
                    foreach (List<string> b in things33)
                    { Output3.Add(1); }
                    ulong error = 1;
                    var times = 0;
                    while (error != 0)
                    {
                        times++;
                        if (times >= 2500000)
                        {
                            LittleHaagentus.Text = "❌尝试配平的次数过多！此系统可能无法将其配平！请检查反应是否符合客观事实！";
                            return;
                        }
                        error = 0;
                        var x = 0;
                        ulong y = 0;
                        var z = 0;
                        var o = 0;
                        foreach (string thing in things25) 
                        {
                            y = 0;
                            z = 0;
                            if (things26[x] < things36[x])
                            {
                                error++;
                                foreach (List<string> thingsA in things23)
                                {
                                    if (thingsA.Contains(thing))
                                    {
                                        if (thingsA.Count < z || z == 0)
                                        {
                                            y = things24[things23.IndexOf(thingsA)][thingsA.IndexOf(thing)];
                                            z = things24[things23.IndexOf(thingsA)].Count;
                                            o = things23.IndexOf(thingsA);
                                        }
                                        else if (thingsA.Count == z)
                                        {
                                            if(things24[things23.IndexOf(thingsA)][thingsA.IndexOf(thing)] < y)
                                            {
                                                y = things24[things23.IndexOf(thingsA)][thingsA.IndexOf(thing)];
                                                z = things24[things23.IndexOf(thingsA)].Count;
                                                o = things23.IndexOf(thingsA);
                                            }
                                        }
                                    }
                                    if (things23.IndexOf(thingsA) == things23.Count - 1)
                                    {
                                        foreach (string thinga in things23[o])
                                        {
                                            things26[things25.IndexOf(thinga)] += things24[o][things23[o].IndexOf(thinga)];
                                        }
                                            Output2[o] += 1;
                                    }
                                }

                            }
                            else if (things26[x] > things36[x])
                            {
                                error++;
                                foreach (List<string> thingsB in things33)
                                {
                                    if (thingsB.Contains(thing))
                                    {
                                        if (thingsB.Count < z || z == 0)
                                        {
                                            y = things34[things33.IndexOf(thingsB)][thingsB.IndexOf(thing)];
                                            z = things34[things33.IndexOf(thingsB)].Count;
                                            o = things33.IndexOf(thingsB);
                                        }
                                        else if (thingsB.Count == z)
                                        {
                                            if (things34[things33.IndexOf(thingsB)][thingsB.IndexOf(thing)] < y)
                                            {
                                                y = things34[things33.IndexOf(thingsB)][thingsB.IndexOf(thing)];
                                                z = things34[things33.IndexOf(thingsB)].Count;
                                                o = things33.IndexOf(thingsB);
                                            }
                                        }
                                    }
                                    if (things33.IndexOf(thingsB) == things33.Count - 1)
                                    {
                                        foreach (string thingb in things33[o])
                                        {
                                            things36[things35.IndexOf(thingb)] += things34[o][things33[o].IndexOf(thingb)];
                                        }
                                            Output3[o] += 1;
                                    }
                                }
                            }
                            x++;
                        }
                    }
//                    LittleHaagentus.Text += "（调试）配平成功！正在化简...\n";
                    
                }
                catch (Exception a) { LittleHaagentus.Text = $"❌在尝试配平时出现问题，请检查物质是否符合客观事实！\n{a}"; return; }

                //--------------------------------------------------化简！---------------------------------------------------------------------
                try {
                    List<ulong> X = [];
                    foreach (ulong x in Output2)
                    { X.Add(x); }
                    foreach (ulong z in Output3)
                    { X.Add(z); }
                    ulong Y = GreatestCommonFactor(X);
                    helperU.Clear();
                    foreach (ulong k in Output2)
                    { helperU.Add(k / Y);}
                    Output2.Clear();
                    foreach (ulong K in helperU)
                    { Output2.Add(K);}
                    helperU.Clear();
                    foreach (ulong m in Output3)
                    { helperU.Add(m / Y); }
                    Output3 = helperU;
//                    LittleHaagentus.Text += "（调试）化简成功！正在输出...\n";
                }
                catch (Exception a) { LittleHaagentus.Text = $"❌在尝试化简时出现问题，请检查物质是否符合客观事实！\n{a}"; return; }

                //--------------------------------------------------输出！---------------------------------------------------------------------
                try 
                {
                    LittleHaagentus.Text = "🤓👉";
                    var x = 0;
                    foreach (ulong a in Output2)
                    {
                        if (a != 1) 
                        {
                            LittleHaagentus.Text += a.ToString();
                        }
                        LittleHaagentus.Text += " ";
                        LittleHaagentus.Text += things2[x];
                        if (x != things23.Count - 1)
                        { LittleHaagentus.Text += " + "; }
                        x++;
                    }
                    LittleHaagentus.Text += " → ";
                    x = 0;
                    foreach (ulong b in Output3)
                    {
                        if (b != 1)
                        {
                            LittleHaagentus.Text += b.ToString();
                        }
                        LittleHaagentus.Text += " ";
                        LittleHaagentus.Text += things3[x];
                        if (x != things33.Count - 1)
                        { LittleHaagentus.Text += " + "; }
                        x++;
                    }
                }
                catch (Exception a) { LittleHaagentus.Text = $"❌在尝试输出时出现问题，请检查物质是否符合客观事实！\n{a}"; return; }

                //下班！
            }
            else if (things1.Length > 2) { LittleHaagentus.Text = "❌找到了多个反应物与生成物的分隔符“-”"; }
            else if (things1.Length < 2) { LittleHaagentus.Text = "❌未找到反应物与生成物的分隔符“-”\n或找不到反应物或生成物"; }  
        }

        static ulong GreatestCommonFactor(List<ulong> X)
        {
            List<List<ulong>> Z = [];
            List<ulong> K = [];
            var fun = 0;
            var y = 0;
            foreach (ulong x in X)
            {
                if (NumberPartyCheck(x).Contains(1) == true)
                {
                    return 1;
                }
                else
                {
                    Z.Add(NumberPartyCheck(x));
                }
            }
            foreach (List<ulong> z in Z)
            {
                if (z.Count > fun)
                {
                    y = Z.IndexOf(z);
                    fun = z.Count;
                }
            }
            foreach (ulong x in Z[y])
            {
                var error = 0;
                foreach (List<ulong> z in Z)
                {
                    if (z.Contains(x) != true)
                    {
                        error++;
                    }
                }
                if (error == 0)
                {
                K.Add(x);
                }
            }
            if (K.Count == 0) { return 1; }
            else { return K[^1]; }

        }

        private void NumChangePlus(object sender, RoutedEventArgs args)
        {
            try {
                if (NumCheckInput.Value <= 0)
                {
                    NumCheckInput.Value = 1;
                }
                else if (NumCheckInput.Value < 18446744073709551615)
                {
                    NumCheckInput.Value += NumChangeInput.Value;
                    NumCheckInput.Value = Convert.ToUInt64(NumCheckInput.Value);
                    TeacherGoToWork(sender, args);
                }
            }
            catch { }

        }

        private void NumChangeMinus(object sender, RoutedEventArgs args)
        {
            try {
                if (NumCheckInput.Value > 18446744073709551615)
                {
                    NumCheckInput.Value = 18446744073709551615;
                }
                else if (NumCheckInput.Value > 0)
                {
                    NumCheckInput.Value -= NumChangeInput.Value;
                    NumCheckInput.Value = Convert.ToUInt64(NumCheckInput.Value);
                    TeacherGoToWork(sender, args);
                }
            }
            catch { }

        }

        static List<ulong> NumberPartyCheck(ulong number)
        {
            List<ulong> NumList = [];
            if (number == 1)
            {
                NumList.Add(1);
            }
            else if (number > 18446744073709551615)
            {
                NumList.Add(0);
            }
            else
            {
                try
                {
                    ulong x = number;
                    ulong i = 2;
                    
                    for (; i <= Convert.ToUInt64(Math.Sqrt(x)); i++)
                    {
                        if (x % i == 0)
                        {
                            NumList.Add(i);
                            x /= i;
                            i = 1;
                        }
                    }
                        NumList.Add(x);
                }
                catch
                {
                    NumList.Add(0);
                }
            }
            return NumList;
        }

        private void TeacherGoToWork(object sender, RoutedEventArgs args)
        {
            var Imput = NumCheckInput.Value;
            CleverTeacher.Text = "🤓正在分析...";
            if (Double.IsNaN(Imput) != true)
            {
                if (Imput <= 0)
                {
                    CleverTeacher.Text = $"🤓👉质数的范围为大于1的自然数，但{Imput}不在此范围内！";
                }
                else
                {
                    try
                    {
                        ulong x = Convert.ToUInt64(Imput);
                        if (x != Imput)
                        {
                            CleverTeacher.Text = "❌输入无效，请检查！(是否为空或带小数？)";
                        }
                        else
                        {
                            List<ulong> iList = NumberPartyCheck(x);
                            if (iList.Count > 0)
                            {
                                if (iList.Contains(0) == true)
                                {
                                    CleverTeacher.Text = "❌在尝试分析时出现错误！可能是数值过大！\n目前仅支持分析≤18446744073709551615(≈1844兆)的数";
                                }
                                else if(iList.Contains(1) == true) 
                                {
                                        CleverTeacher.Text = "🤓👉1既不是质数也不是合数";
                                }
                                else {
                                    if (iList.Count > 1)
                                    {
                                        CleverTeacher.Text = $"🤓👉{Imput}是合数，{Imput}=";
                                        for (int fun = iList.Count; iList.Count > 0; iList.RemoveAt(0))
                                        {
                                            if (iList.Count == fun)
                                            {
                                                CleverTeacher.Text += iList[0];
                                            }
                                            else
                                            {
                                                CleverTeacher.Text += "×";
                                                CleverTeacher.Text += iList[0];
                                            }
                                            x = iList[0];
                                            if (iList.Count(n => n == x) > 1)
                                            {
                                                x = (ulong)iList.Count(n => n == x);
                                                CleverTeacher.Text += "^";
                                                CleverTeacher.Text += x;
                                                for (x--; x > 0; x--)
                                                {
                                                    iList.RemoveAt(0);
                                                }
                                            }
                                        }
                                    }
                                    else 
                                    {
                                        CleverTeacher.Text = $"🤓👉{Imput}是质数";
                                    }
                                }
                            }
                            else
                            {
                                CleverTeacher.Text = "❌在尝试分析时出现错误！请重试！\n如仍无法分析请联系我们修复BUG！";
                            }
                        }
                    }
                    catch 
                    {
                        CleverTeacher.Text = "❌在尝试分析时出现错误！可能是数值过大！\n目前仅支持分析≤18446744073709551615(≈1844兆)的数";
                    }
                }
            }
        }

        [GeneratedRegex("[A-Z]")]
        private static partial Regex ABC();
        [GeneratedRegex("[a-z]")]
        private static partial Regex abc();
        [GeneratedRegex("[0-9]")]
        private static partial Regex num();

        #region
        //LittleHaagentusGoToWork2 below was generated by DeepSeek!
        /*
        private void LittleHaagentusGoToWork2(object sender, RoutedEventArgs e)
        {
            try
            {
                // 清空输出区域
                LittleHaagentusTeaching.Text = "开始分析！\n";
                LittleHaagentus.Text = "🤓分析中...";

                // 获取用户输入
                var input = LittleHaagentusInput.Text;
                LittleHaagentusTeaching.Text += $"输入验证：{input}\n";

                // 基础输入验证
                if (string.IsNullOrWhiteSpace(input))
                {
                    ShowError("请输入化学方程式");
                    return;
                }

                if (!input.Contains("->"))
                {
                    ShowError("方程式格式错误，请使用 -> 分隔反应物和生成物");
                    return;
                }

                // 解析反应物和生成物
                var sides = input.Split(["->"], StringSplitOptions.None);
                if (sides.Length != 2)
                {
                    ShowError("方程式格式错误，应包含且仅包含一个 ->");
                    return;
                }

                // 解析化合物
                var reactants = ParseSide(sides[0].Trim());
                var products = ParseSide(sides[1].Trim());
                LittleHaagentusTeaching.Text += $"解析完成：{reactants.Count} 反应物，{products.Count} 生成物\n";

                // 构建矩阵
                var matrix = BuildMatrix(reactants, products);
                LittleHaagentusTeaching.Text += "构建矩阵成功\n";

                // 高斯消元求解
                var coefficients = Solve(matrix);
                LittleHaagentusTeaching.Text += "计算完成\n";

                // 生成结果
                var balancedEquation = FormatEquation(reactants, products, coefficients);
                LittleHaagentus.Text = balancedEquation;
            }
            catch (Exception ex)
            {
                ShowError($"发生错误：{ex.Message}");
            }
        }
        
        private List<Compound> ParseSide(string side)
        {
            // 实现带括号和离子团的解析逻辑
            var compounds = side.Split('+')
        .Select(s => s.Trim())
        .Select(s => new Compound(s))
        .ToList();

            // 调试输出
            foreach (var c in compounds)
            {
                LittleHaagentusTeaching.Text += $"{c.Formula}: {string.Join(",", c.Elements)}\n";
            }
            return compounds;
        }

        private double[,] BuildMatrix(List<Compound> reactants, List<Compound> products)
        {
            // 合并所有化合物（生成物系数取负）
            var allCompounds = reactants
                .Select(c => c.Elements)
                .Concat(products.Select(c => c.Elements.ToDictionary(e => e.Key, e => -e.Value)))
                .ToList();

            // 获取所有元素
            var elements = allCompounds
                .SelectMany(c => c.Keys)
                .Distinct()
                .OrderBy(e => e)
                .ToList();

            // 构建矩阵
            var matrix = new double[elements.Count, allCompounds.Count];
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = 0; j < allCompounds.Count; j++)
                {
                    matrix[i, j] = allCompounds[j].TryGetValue(elements[i], out var value) ? value : 0;
                }
            }

            // 输出矩阵到调试信息
            LittleHaagentusTeaching.Text += "\n构建的矩阵：\n";
            for (int i = 0; i < elements.Count; i++)
            {
                LittleHaagentusTeaching.Text += $"{elements[i]}: ";
                for (int j = 0; j < allCompounds.Count; j++)
                {
                    LittleHaagentusTeaching.Text += $"{matrix[i, j],5}";
                }
                LittleHaagentusTeaching.Text += "\n";
            }

            return matrix;
        }

        private int[] Solve(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // 初始化列映射
            int[] columnMap = Enumerable.Range(0, cols).ToArray();

            // 高斯消元核心逻辑
            for (int i = 0; i < rows; i++)
            {
                int pivotColumn = -1;
                for (int j = i; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > 1e-10)
                    {
                        pivotColumn = j;
                        break;
                    }
                }

                if (pivotColumn == -1) continue;

                // 交换列并更新映射
                if (pivotColumn != i)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        (matrix[k, i], matrix[k, pivotColumn]) = (matrix[k, pivotColumn], matrix[k, i]);
                    }
                    (columnMap[i], columnMap[pivotColumn]) = (columnMap[pivotColumn], columnMap[i]);
                }

                // 归一化当前行
                double pivotValue = matrix[i, i];
                for (int j = i; j < cols; j++)
                {
                    matrix[i, j] /= pivotValue;
                }

                // 消去其他行
                for (int k = 0; k < rows; k++)
                {
                    if (k != i && Math.Abs(matrix[k, i]) > 1e-10)
                    {
                        double factor = matrix[k, i];
                        for (int j = i; j < cols; j++)
                        {
                            matrix[k, j] -= factor * matrix[i, j];
                        }
                    }
                }
            }

            // 计算矩阵的秩
            int rank = 0;
            for (int i = 0; i < rows; i++)
            {
                bool isZeroRow = true;
                for (int j = 0; j < cols; j++)
                {
                    if (Math.Abs(matrix[i, j]) > 1e-10)
                    {
                        isZeroRow = false;
                        break;
                    }
                }
                if (!isZeroRow) rank++;
            }

            // 检查矛盾方程
            if (rank < rows)
            {
                for (int i = rank; i < rows; i++)
                {
                    if (Math.Abs(matrix[i, cols - 1]) > 1e-10)
                    {
                        throw new Exception("方程式矛盾，无法配平");
                    }
                }
            }

            // 初始化分数系数数组
            Fraction[] coeffFractions = new Fraction[cols];
            for (int i = 0; i < cols; i++)
            {
                coeffFractions[i] = new Fraction(0, 1);
            }

            // 显式设置最后一个变量为自由变量（即使 rank == cols）
            coeffFractions[cols - 1] = new Fraction(1, 1);

            // 回代求解所有变量
            for (int i = rows - 1; i >= 0; i--)
            {
                Fraction sum = new Fraction(0, 1);
                for (int j = i; j < cols; j++)
                {
                    // 使用原始列顺序的 matrix[i, j]
                    Fraction matrixEntry = new Fraction(matrix[i, columnMap[j]], 1);
                    sum += matrixEntry * coeffFractions[j];
                }
                // 解出当前变量：x_i = -sum / matrix[i,i]
                coeffFractions[i] = new Fraction(-sum.Numerator, sum.Denominator) / new Fraction(matrix[i, columnMap[i]], 1);
            }

            // 转换为整数系数
            int[] coeff = new int[cols];
            for (int i = 0; i < cols; i++)
            {
           //     coeff[i] = (coeffFractions[i].Numerator * lcmDenominator) / coeffFractions[i].Denominator;
            }

            // 计算所有系数的 GCD 并简化
     //       int gcdAll = GCD(coeff);
            for (int i = 0; i < cols; i++)
            {
       //         coeff[i] /= gcdAll;
            }

            // 确保系数非负
            int minCoeff = coeff.Min();
            if (minCoeff < 0)
            {
                int factor = -minCoeff;
                for (int i = 0; i < cols; i++)
                {
                    coeff[i] += factor;
                }
            }

            // 再次简化系数
       //     gcdAll = GCD(coeff);
            for (int i = 0; i < cols; i++)
            {
       //         coeff[i] /= gcdAll;
            }

            // 根据列映射还原原始顺序
            int[] originalCoeff = new int[cols];
            for (int i = 0; i < cols; i++)
            {
                originalCoeff[columnMap[i]] = coeff[i];
            }

            // 打印消元后的矩阵和列映射（必须放在最后）
            LittleHaagentusTeaching.Text += "\n消元后的矩阵：\n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    LittleHaagentusTeaching.Text += $"{matrix[i, j],8:0.##}";
                }
                LittleHaagentusTeaching.Text += "\n";
            }
            LittleHaagentusTeaching.Text += $"列映射: {string.Join(", ", columnMap)}\n";

            return originalCoeff;
        }

        // 分数转换辅助类
        public class Fraction
        {
            public int Numerator { get; }
            public int Denominator { get; }

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0) throw new ArgumentException("分母不能为零");
                int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
                Numerator = numerator / gcd;
                Denominator = denominator / gcd;

                // 确保分母为正
                if (Denominator < 0)
                {
                    Numerator *= -1;
                    Denominator *= -1;
                }
            }

            public Fraction(double value, int maxDenominator = 1000)
            {
                // 寻找最佳分数近似
                double bestError = double.MaxValue;
                int bestNum = 0;
                int bestDen = 1;

                for (int den = 1; den <= maxDenominator; den++)
                {
                    int num = (int)Math.Round(value * den);
                    double error = Math.Abs((double)num / den - value);
                    if (error < bestError)
                    {
                        bestError = error;
                        bestNum = num;
                        bestDen = den;
                    }
                }

                int gcd = GCD(bestNum, bestDen);
                Numerator = bestNum / gcd;
                Denominator = bestDen / gcd;
            }

            private static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

            // 运算符重载：除法
            public static Fraction operator /(Fraction a, Fraction b)
            {
                // 除法转换为乘以倒数
                return new Fraction(
                    a.Numerator * b.Denominator,
                    a.Denominator * b.Numerator
                );
            }

            // 运算符重载：乘法
            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(
                    a.Numerator * b.Numerator,
                    a.Denominator * b.Denominator
                );
            }

            // 运算符重载：加法
            public static Fraction operator +(Fraction a, Fraction b)
            {
                int commonDenominator = LCM(a.Denominator, b.Denominator);
                int newNumA = a.Numerator * (commonDenominator / a.Denominator);
                int newNumB = b.Numerator * (commonDenominator / b.Denominator);
                return new Fraction(newNumA + newNumB, commonDenominator);
            }

            // 静态方法：计算最小公倍数（LCM）
            private static int LCM(int a, int b)
            {
                return Math.Abs(a * b) / GCD(a, b);
            }

            // 其他必要运算符（如减法、负号等）
            public static Fraction operator -(Fraction a, Fraction b)
            {
                return a + (-b);
            }

            public static Fraction operator -(Fraction a)
            {
                return new Fraction(-a.Numerator, a.Denominator);
            }
        }

        private string FormatEquation(List<Compound> reactants, List<Compound> products, int[] coefficients)
        {
            // 格式化输出方程式
            var reactantStr = string.Join(" + ", reactants.Select((r, i) => $"{coefficients[i]}{r.Formula}"));
            var productStr = string.Join(" + ", products.Select((p, i) => $"{coefficients[reactants.Count + i]}{p.Formula}"));
            return $"{reactantStr} -> {productStr}";
        }

        private void ShowError(string message)
        {
            LittleHaagentus.Text = "❌" + message;
            LittleHaagentusTeaching.Text += $"{message}\n";
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int LCM(int a, int b)
        {
            return Math.Abs(a * b) / GCD(a, b);
        }

        private static int LCM(IEnumerable<int> numbers)
        {
            return numbers.Aggregate(LCM);
        }
        */
        #endregion
    }
    #region
    /*
    public class Compound
    {
        public string Formula { get; }
        public Dictionary<string, int> Elements { get; }

        public Compound(string formula)
        {
            Formula = formula;
            Elements = ParseFormula(formula);
        }

        private static Dictionary<string, int> ParseFormula(string formula)
        {
            var elements = new Dictionary<string, int>();
            var stack = new Stack<Dictionary<string, int>>();
            stack.Push(new Dictionary<string, int>());

            int i = 0;
            while (i < formula.Length)
            {
                if (formula[i] == '(')
                {
                    stack.Push(new Dictionary<string, int>());
                    i++;
                }
                else if (formula[i] == ')')
                {
                    var temp = stack.Pop();
                    i++;

                    // 解析括号后的数字
                    int num = 1;
                    if (i < formula.Length && char.IsDigit(formula[i]))
                    {
                        int start = i;
                        while (i < formula.Length && char.IsDigit(formula[i])) i++;
                        num = int.Parse(formula.Substring(start, i - start));
                    }

                    foreach (var (k, v) in temp)
                    {
                        var top = stack.Peek(); // 获取栈顶元素
                        top[k] = top.TryGetValue(k, out int current)
                                 ? current + v * num
                                 : v * num;
                    }
                }
                else
                {
                    // 原有元素解析逻辑
                    if (char.IsUpper(formula[i]))
                    {
                        int elementStart = i;
                        i++;
                        while (i < formula.Length && char.IsLower(formula[i])) i++;
                        string element = formula.Substring(elementStart, i - elementStart);

                        // 解析原子数
                        int num = 1;
                        if (i < formula.Length && char.IsDigit(formula[i]))
                        {
                            int numStart = i;
                            while (i < formula.Length && char.IsDigit(formula[i])) i++;
                            num = int.Parse(formula.Substring(numStart, i - numStart));
                        }

                        var top = stack.Peek();
                        top[element] = top.TryGetValue(element, out int current)
                                      ? current + num
                                      : num;
                    }
                    else
                    {
                        i++; // 跳过非元素字符
                    }
                }
            }

            return stack.Pop();
        }
    }
    */
    #endregion
}
