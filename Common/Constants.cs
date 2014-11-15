
namespace GalaxyGuide.Common
{
    public static class Constants
    {
        public static readonly string NewWordRegex = "^([A-Za-z]+) is ([I|V|X|L|C|D|M])$";
        public static readonly string HowMuchRegex = "^how much is (([A-Za-z\\s])+)\\?$";
        public static readonly string HowManyCreditsRegex = "^how many [c|C]redits is (([A-Za-z\\s])+)\\?$";
        public static readonly string AssignCredits = "^([A-Za-z]+)([A-Za-z\\s]*) is ([0-9]+) ([c|C]redits)$";
        public static readonly string RomanRegex = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";

        public static readonly string HowManyCredits = "how many Credits is";
        public static readonly string HowMuchIs = "how much is";
        public static readonly string NoIdea = " I have no idea what you are talking about";
        public static readonly string NoUnits = "No units available to calculate credits";
        public static readonly string InvalidUnits = "Invalid Units";
        public static readonly string InvalidCredits = "Invalid Credits";
        public static readonly string Sucess = "Sucess";
        public static readonly string IncorrectInput = "In correct input";
    }
}

