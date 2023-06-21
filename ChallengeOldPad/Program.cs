// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChallengeOldPad
{
    public class Program
    {

        // Dicionario com os comandos permitidos
        private static readonly Dictionary<string, string> dicPad = new Dictionary<string, string>()
             {
                                                {"*","*"},
                                                {"#","send"},
                                                {"0"," "},
                                                {"1","&"},
                                                {"11","'"},
                                                {"111","("},
                                                {"2", "a"},
                                                {"22", "b"},
                                                {"222", "c"},
                                                {"3", "d"},
                                                {"33", "e"},
                                                {"333", "f"},
                                                {"4", "g"},
                                                {"44", "h"},
                                                {"444", "i"},
                                                {"5","j"},
                                                {"55","k"},
                                                {"555","l"},
                                                {"6","m"},
                                                {"66","n"},
                                                {"666","o"},
                                                {"7","p"},
                                                {"77","q"},
                                                {"777","r"},
                                                {"7777","s"},
                                                {"8","t"},
                                                {"88","u"},
                                                {"888","v"},
                                                {"9","w"},
                                                {"99","x"},
                                                {"999","y"},
                                                {"9999","z"},
              };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// Retorna o comando enviado pelo usuario
        /// </summary>
        /// <param name="input"> Comando enviado pelo usuario, devendo conter somente os caracteres permitidos</param>
        /// <returns></returns>
        public static string OldPhonePad(string input)
        {
            VerifyInput(input);
            string output = "";
            var inputList = ReturnInputList(input);

            foreach (var inputCommand in inputList)
            {
                string tempInmputCommand = inputCommand;

                foreach (var key in dicPad.Keys.OrderByDescending(keys => keys.Length).ThenByDescending(keys => keys))
                {
                    if (tempInmputCommand.Contains(key))
                    {
                        tempInmputCommand = tempInmputCommand.Replace(key, dicPad[key]);
                    }
                }

                tempInmputCommand = DeleteCharacter(tempInmputCommand);
                output += tempInmputCommand;
            }


            return output;
        }

        /// <summary>
        /// Apaga os caracteres conforme solicitação do usuário
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string DeleteCharacter(string input)
        {
            do
            {
                int indexToDelete = input.IndexOf('*') - 1;

                if (indexToDelete < 0)
                    break;

                input = input.Remove(indexToDelete, 1);
                input = input.Replace("*", "");
            }
            while (input.Contains("*"));

            return input;
        }

        /// <summary>
        /// Retorna os comandos enviados formatados e separados por espaço
        /// </summary>
        /// <param name="input">Comandos enviados pelo usuario</param>
        /// <returns>Retorno dos comandos enviados em formato de lista de string</returns>
        private static string[] ReturnInputList(string input)
        {
            input = input.Trim();
            input = input.Remove(input.LastIndexOf('#'));

            return input.Split(" ");
        }

        /// <summary>
        /// Valida a entrada fornecida
        /// </summary>
        /// <param name="input">Comandos enviados pelo usuario</param>
        private static void VerifyInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || (input.Count(a => a != '#' && a != '*') <= 0))
                throw new Exception("Input null or Empty!");

            if (input.Last() != '#')
                throw new Exception("Without send command!");

            foreach (var valueChar in input)
            {
                if (string.IsNullOrWhiteSpace(valueChar.ToString()) == false && dicPad.Keys.Contains(valueChar.ToString()) == false)
                    throw new Exception("Invalid Input!");

            }

        }
    }
}

