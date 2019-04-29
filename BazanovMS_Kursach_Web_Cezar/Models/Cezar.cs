using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BazanovMS_Kursach_Web_Cezar.Models
{
    public class Cezar
    {
        //переводим строку в шифр цезаря
        public static string ToCesar(string s, int shift)
        {
            try
            {
                char[] tmp = s.ToCharArray();
                string let = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                List<char> letters = new List<char>(let);
                List<char> LETTERS = new List<char>(let.ToUpper());
                for (int i = 0; i < s.Length; i++)
                {
                    int position;
                    if (new List<char>(let).IndexOf(tmp[i]) != -1)
                    {
                        position = letters.IndexOf(tmp[i]);
                        if ((position + shift < letters.Count) && (position + shift >= 0))
                        {
                            tmp[i] = letters[position + shift];
                        }
                        else
                        {
                            if (position + shift < 0)
                            {
                                tmp[i] = letters[letters.Count - (Math.Abs(position + shift))];
                            }
                            else
                            {
                                tmp[i] = letters[shift - (letters.Count - position)];
                            }
                        }
                    }
                    else
                    {
                        if (new List<char>(let.ToUpper()).IndexOf(tmp[i]) != -1)
                        {
                            position = LETTERS.IndexOf(tmp[i]);
                            if ((position + shift < LETTERS.Count) && (position + shift >= 0))
                            {
                                tmp[i] = LETTERS[position + shift];
                            }
                            else
                            {
                                if (position + shift < 0)
                                {
                                    tmp[i] = LETTERS[LETTERS.Count - (Math.Abs(position + shift))];
                                }
                                else
                                {
                                    tmp[i] = LETTERS[shift - (LETTERS.Count - position)];
                                }
                            }
                        }
                        else continue;
                    }

                }
                string ret = "";
                foreach (var item in tmp)
                {
                    ret += item;
                }
                return ret;
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        //автоматически выдает сдвиг, который использовали для зашифровки файла
        //нет доказательств полной работоспособности
        //на маленьких строках может не работать
        //на больших строках ни разу не выдал неверный результат
        public static int AutoDeCrypt(string AllfileText, string wordLib)
        {
            try
            {
                Dictionary<int, int> result = new Dictionary<int, int>();

                for (int i = 0; i < 34; i++)
                {
                    string tmp = AllfileText;
                    int count = 0;
                    string fileText = "";

                    System.IO.StreamReader WordLib = null;
                    WordLib = new System.IO.StreamReader(wordLib);
                    tmp = ToCesar(tmp, i);

                    while ((fileText = WordLib.ReadLine()) != null)
                    {
                        if (tmp.Contains(fileText))
                        {
                            count++;
                        }
                    }
                    WordLib.Close();
                    result.Add(i, count);
                }
                int max = -1;
                int Shift = -34;
                foreach (var item in result)
                {
                    //Console.WriteLine(item.Key+ " - " + item.Value);
                    if (item.Value > max)
                    {
                        max = item.Value;
                        Shift = item.Key;
                    }
                }
                return Shift;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}