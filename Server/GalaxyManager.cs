


using System;
using System.Globalization;
using System.Management.Instrumentation;
using System.Text.RegularExpressions;

namespace GalaxyGuide.Server
{
    using Common;
    using System.Collections.Generic;

    public class GalaxyManager : IGalaxyManager
    {
        private readonly Dictionary<string, Romans> _newWordDictionary = new Dictionary<string, Romans>();

        public string ProcessMessage(string inputString)
        {

            switch (getTypeOfString(inputString))
            {

                case InputType.NewWord:
                    AddNewWord(inputString);
                    return Messages.Sucess.ToString();

                case InputType.AssignCredits:
                    return Messages.Sucess.ToString();

                case InputType.HowMuchIs:
                    return Messages.Sucess.ToString();

                case InputType.HowManyCredits:
                    return Messages.Sucess.ToString();

                case InputType.Roman:
                    return GetHinduArabicValue(inputString);

                case InputType.Invalid:
                    return Constants.NoIdea;
            }

            return Messages.IncorrectInput.ToString();

        }

        private void AddNewWord(string inputString)
        {
            var words = inputString.Split(' ');

            var roman = (Romans)Enum.Parse(typeof(Romans), words[2]);

            if (_newWordDictionary.ContainsKey(words[0]))
            {
                _newWordDictionary[words[0]] = roman;
            }
            else
            {
                _newWordDictionary.Add(words[0], roman);
            }
        }

        private InputType getTypeOfString(string inputString)
        {

            var regex = new Regex(Constants.NewWordRegex);
            if (regex.IsMatch(inputString))
            {
                return InputType.NewWord;
            }


            regex = new Regex(Constants.AssignCredits);
            if (regex.IsMatch(inputString))
            {
                return InputType.AssignCredits;
            }

            regex = new Regex(Constants.HowMuchRegex);
            if (regex.IsMatch(inputString))
            {
                return InputType.HowMuchIs;
            }

            regex = new Regex(Constants.HowManyCreditsRegex);
            if (regex.IsMatch(inputString))
            {
                return InputType.HowManyCredits;
            }

            regex = new Regex(Constants.RomanRegex);
            return regex.IsMatch(inputString) ? InputType.Roman : InputType.Invalid;
        }

        public string GetRomanValue(string arabicString)
        {

            throw new System.NotImplementedException();

        }

        public string GetHinduArabicValue(string romanSting)
        {
            int sum = 0;
            char[] romanArray = romanSting.ToCharArray();
            for (int index = 0; index < romanArray.Length; index++)
            {
                var nextRoman = (index + 1) >= romanArray.Length ? 'N' : romanArray[index + 1];
                sum += getSum(romanArray[index], nextRoman);
            }

            return sum.ToString(CultureInfo.InvariantCulture);
        }

        private int getSum(char currentRoman, char nextRoman)
        {
            var currentValue = (int)Enum.Parse(typeof(Romans), currentRoman.ToString(CultureInfo.InvariantCulture));

            if (nextRoman == 'N') return currentValue;

            var nextVlaue = (int)Enum.Parse(typeof(Romans), nextRoman.ToString(CultureInfo.InvariantCulture));
            if (currentValue < nextVlaue)
                return currentValue * -1;

            return currentValue;
        }



    }
}
