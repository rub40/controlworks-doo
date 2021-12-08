using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace ControlWorks
{
    public class Util
    {
        public static string RemoverAcentos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return null;
            }

            texto = CleanInvalidXmlChars(texto);

            texto = texto.Replace("\r\n", "");
            if (string.IsNullOrEmpty(texto))
            {
                return null;
            }

            texto = texto.Trim();
            Regex replace_a_Accents = new Regex("[áàäâã]", RegexOptions.Compiled);
            Regex replace_A_Accents = new Regex("[ÁÀÄÂÃ]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[éèëê]", RegexOptions.Compiled);
            Regex replace_E_Accents = new Regex("[ÉÈËÊ]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[íìïî]", RegexOptions.Compiled);
            Regex replace_I_Accents = new Regex("[ÍÌÏÎ]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[óòöôõ]", RegexOptions.Compiled);
            Regex replace_O_Accents = new Regex("[ÓÒÖÔÕ]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[úùüû]", RegexOptions.Compiled);
            Regex replace_U_Accents = new Regex("[ÚÙÜÛ]", RegexOptions.Compiled);
            texto = replace_a_Accents.Replace(texto, "a");
            texto = replace_A_Accents.Replace(texto, "A");
            texto = replace_e_Accents.Replace(texto, "e");
            texto = replace_E_Accents.Replace(texto, "E");
            texto = replace_i_Accents.Replace(texto, "i");
            texto = replace_I_Accents.Replace(texto, "I");
            texto = replace_o_Accents.Replace(texto, "o");
            texto = replace_O_Accents.Replace(texto, "O");
            texto = replace_u_Accents.Replace(texto, "u");
            texto = replace_U_Accents.Replace(texto, "U");
            texto = texto.Replace("<", "&lt;");
            texto = texto.Replace(">", "&gt;");
            texto = texto.Replace("&", "&amp;");
            texto = texto.Replace("\"", "&quot;");
            texto = texto.Replace("'", "'");
            texto = texto.Replace("ç", "c");
            texto = texto.Replace("Ç", "C");
            texto = texto.Replace("º", " ");
            texto = texto.Replace("´", "");
            texto = texto.Replace("`", "");

            // CONVERT O TEXTO PARA O PADRAO DO XML UTF-8
            Encoding utf8 = Encoding.UTF8;
            byte[] encodedBytes = utf8.GetBytes(texto);
            byte[] convertedBytes = Encoding.Convert(Encoding.UTF8, Encoding.ASCII, encodedBytes);
            Encoding ascii = Encoding.ASCII;
            texto = ascii.GetString(convertedBytes);

            return texto;
        }

        public static string CleanInvalidXmlChars(string text)
        {
            string re = @"[^\x09\x0A\x0D\x20-\xD7FF\xE000-\xFFFD\x10000-x10FFFF]";
            return Regex.Replace(text, re, "");
        }


        public static void percorrerCampos(KeyEventArgs e)
        {
            if (e.Handled)
            {
                return;
            }

            if (Keyboard.FocusedElement is TextBox atextbox)
            {
                if (!atextbox.AcceptsReturn)
                {
                    if (e.Key == Key.Enter)
                    {
                        _ = atextbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        e.Handled = true;
                    }
                    if (e.Key == Key.Up)
                    {
                        _ = atextbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                        e.Handled = true;
                    }
                    if (e.Key == Key.Down)
                    {
                        _ = atextbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        e.Handled = true;
                    }
                }

            }
            else if (Keyboard.FocusedElement is PasswordBox apasswordbox)
            {
                if (e.Key == Key.Enter)
                {
                    _ = apasswordbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
                if (e.Key == Key.Up)
                {
                    _ = apasswordbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    e.Handled = true;
                }
                if (e.Key == Key.Down)
                {
                    _ = apasswordbox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
            }
            else if (Keyboard.FocusedElement is TextBlock atextblock)
            {
                if (e.Key == Key.Enter)
                {
                    _ = atextblock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
                if (e.Key == Key.Up)
                {
                    _ = atextblock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    e.Handled = true;
                }
                if (e.Key == Key.Down)
                {
                    _ = atextblock.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
            }
            else if (Keyboard.FocusedElement is ComboBox acombobox)
            {
                if (e.Key == Key.Enter)
                {
                    _ = acombobox.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
                else if (e.Key == Key.F2)
                {
                    acombobox.IsDropDownOpen = true;
                }
            }
            else if (Keyboard.FocusedElement is RadioButton aradiobutton)
            {
                if (e.Key == Key.Up)
                {
                    _ = aradiobutton.MoveFocus(new TraversalRequest(FocusNavigationDirection.Previous));
                    e.Handled = true;
                }
                if (e.Key == Key.Down)
                {
                    _ = aradiobutton.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    e.Handled = true;
                }
            }
        }
    }
}
