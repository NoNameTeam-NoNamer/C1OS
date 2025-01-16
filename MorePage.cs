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
    }
}
