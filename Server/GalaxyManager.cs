
namespace GalaxyGuide.Server
{
    using Common;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GalaxyManager : IGalaxyManager
    {
        private readonly GalaxyDictionary<string, Romans> _galacticUnits = new GalaxyDictionary<string, Romans>();
        private readonly GalaxyDictionary<string, float> _itemCredits = new GalaxyDictionary<string, float>();

        public string ProcessMessage(string inputString)
        {
            switch (getTypeOfString(inputString))
            {

                case InputType.NewWord:
                    return AddNewWord(inputString);

                case InputType.AssignCredits:
                    return AssignCredits(inputString);

                case InputType.HowMuchIs:
                    return GetHowMuchIs(inputString);

                case InputType.HowManyCredits:
                    return GetHowManyCredits(inputString);

                case InputType.Roman:
                    return GetHinduArabicValue(inputString);

                case InputType.Invalid:
                    return Constants.NoIdea;
            }

            return Constants.IncorrectInput;
        }

        public string GetHinduArabicValue(string romanSting)
        {
            if (!ValidateRoman(romanSting))
                throw new Exception(Constants.InvalidRoamnsCombination);

            var sum = 0;
            var romanArray = romanSting.ToCharArray();
            for (var index = 0; index < romanArray.Length; index++)
            {
                var nextRoman = (index + 1) >= romanArray.Length ? 'N' : romanArray[index + 1];
                sum += getSum(romanArray[index], nextRoman);
            }

            return sum.ToString(CultureInfo.InvariantCulture);
        }

        private string GetHowMuchIs(string inputString)
        {
            inputString =
                inputString.Replace("?", string.Empty).Trim().Substring(Constants.HowMuchIs.Length).TrimStart();
            var words = inputString.Split(' ');

            var romanWord = string.Empty;
            foreach (var word in words)
            {
                if (_galacticUnits.Keys.Contains(word))
                {
                    romanWord += _galacticUnits[word];
                }
                else
                {
                    return Constants.InvalidUnits;
                }
            }

            return string.Format("{0} is {1}", inputString, GetHinduArabicValue(romanWord));
        }

        private string GetHowManyCredits(string inputString)
        {
            inputString =
                inputString.Replace("?", string.Empty).Trim().Substring(Constants.HowManyCredits.Length).TrimStart();
            var words = inputString.Split(' ');
            var romanWord = string.Empty;
            foreach (var word in words)
            {
                if (_galacticUnits.ContainsKey(word))
                {
                    romanWord += _galacticUnits[word];
                }
                else if (_itemCredits.ContainsKey(word))
                {
                    return string.Format("{0} is {1} Credits", inputString,
                        (int.Parse(GetHinduArabicValue(romanWord))*_itemCredits[word]).ToString(
                            CultureInfo.InvariantCulture));
                }
                else
                {
                    break;
                }
            }

            return Constants.InvalidCredits;
        }

        private string AssignCredits(string inputString)
        {
            if (_galacticUnits.Count <= 0)
                return Constants.NoUnits;

            var words = inputString.Split(' ');
            var romanWord = string.Empty;
            for (var index = 0; index < words.Length; index++)
            {
                var word = words[index].Trim();

                if (string.IsNullOrEmpty(word))
                {
                    return Constants.NoIdea;
                }

                if (_galacticUnits.Keys.Contains(word))
                {
                    romanWord += _galacticUnits[word];
                }
                else
                {
                    if (!words[index + 1].Equals("is", StringComparison.InvariantCultureIgnoreCase))
                        return Constants.InvalidUnits;

                    var itemGrossValue = int.Parse(words[index + 2]);
                    var unitValue = (itemGrossValue / float.Parse(GetHinduArabicValue(romanWord)));
                    _itemCredits.AddUpdateKey(word, unitValue);
                    return Constants.CreditsAssigned;
                }
            }

            return Constants.IncorrectInput;
        }

        private string AddNewWord(string inputString)
        {
            var words = inputString.Split(' ');

            var roman = (Romans)Enum.Parse(typeof(Romans), words[2]);
            _galacticUnits.AddUpdateKey(words[0], roman);

            return Constants.Assigned;
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
            return Constants.Sucess;
        }



        private bool ValidateRoman(string romanSting)
        {
            var regex = new Regex(Constants.RomanRegex);
            if (!regex.IsMatch(romanSting))
                return false;

            if (romanSting.Contains("MMMM"))
                return false;

            return true;
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
