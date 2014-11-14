
namespace GalaxyGuide.Common
{
    public static class Constants
    {
        public static readonly string NewWordRegex = "^([A-Za-z]+) is ([I|V|X|L|C|D|M])$";
        public static readonly string HowMuchRegex = "^how much is (([A-Za-z\\s])+)\\?$";
        public static readonly string HowManyCreditsRegex = "^how many [c|C]redits is (([A-Za-z\\s])+)\\?$";
        public static readonly string AssignCredits = "^([A-Za-z]+)([A-Za-z\\s]*) is ([0-9]+) ([c|C]redits)$";
        public static readonly string RomanRegex = "^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$";


        public static readonly string NoIdea = " I have no idea what you are talking about";
    }
}
