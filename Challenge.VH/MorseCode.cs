namespace Challenge.VH
{
    public static class MorseCode
    {
        private static readonly IDictionary<string, string> morseCode = new Dictionary<string, string>
        {
            { ".-", "A" }, { "-...", "B"}, { "-.-.", "C"}, { "-..", "D"}, { ".", "E"}, { "..-.", "F"}, { "--.", "G"}, { "....", "H"}, { "..", "I"}, { ".---", "J"},
            { "-.-", "K"}, { ".-..", "L"}, { "--", "M"}, { "-.", "N"}, { "---", "O"}, { ".--.", "P"}, { "--.-", "Q"}, { ".-.", "R"}, { "...", "S"}, { "-", "T"},
            { "..-", "U"}, { "...-", "V"}, { ".--", "W"}, { "-..-", "X"}, { "-.--", "Y"}, { "--..", "Z"}
        };

        public static string[] Possibilities(string signals)
        {
            var result = new List<string>();

            if (!signals.Contains("?"))
            {
                return SignalsWithUnknownOne(signals);
            }
            else if (signals.Equals("?") || signals.Equals("??") || signals.Equals("???"))
            {
                return UnknownSignal(signals);
            }

            var chars = new List<char>();

            signals.ToList().ForEach(s => chars.Add(s));

            char? first = chars.Count > 0 && !chars[0].Equals('?') ? chars[0] : null;
            char? second = chars.Count > 1 && !chars[1].Equals('?') ? chars[1] : null;
            char? third = chars.Count > 2 && !chars[2].Equals('?') ? chars[2] : null;

            var lengthWithSignals = morseCode.Where(x => x.Key.Length.Equals(signals.Length)).ToList();

            lengthWithSignals = lengthWithSignals.OrderByDescending(x => x.Key, StringComparer.Ordinal).ToList();

            if (first.HasValue)
            {
                lengthWithSignals = lengthWithSignals.Where(x => x.Key[0].Equals(first)).ToList();
            }

            if (second.HasValue)
            {
                lengthWithSignals = lengthWithSignals.Where(x => x.Key[1].Equals(second)).ToList();
            }

            if (third.HasValue)
            {
                lengthWithSignals = lengthWithSignals.Where(x => x.Key[2].Equals(third)).ToList();
            }

            result = lengthWithSignals.Select(x => x.Value).ToList();

            return result.ToArray();
        }

        private static string[] SignalsWithUnknownOne(string signals)
        {
            var result = new List<string>();

            if (morseCode.TryGetValue(signals, out var value))
            {
                result.Add(value);
            }

            return result.ToArray();
        }

        private static string[] UnknownSignal(string signals)
        {
            var result = new List<string>();

            var lengthWithSignals = morseCode.Where(x => x.Key.Length.Equals(signals.Length)).ToList();

            lengthWithSignals = lengthWithSignals.OrderByDescending(x => x.Key, StringComparer.Ordinal).ToList();

            result = lengthWithSignals.Select(x => x.Value).ToList();

            return result.ToArray();
        }
    }
}
