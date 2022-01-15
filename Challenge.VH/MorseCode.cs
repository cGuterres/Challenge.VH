namespace Challenge.VH
{
    public static class MorseCode
    {
        private static readonly IDictionary<string, string> morseCode = new Dictionary<string, string>
        {
            { ".-", "A" },
            { "-...", "B"},
            { "-.-.", "C"},
            { "-..", "D"},
            { ".", "E"},
            { "..-.", "F"},
            { "--.", "G"},
            { "....", "H"},
            { "..", "I"},
            { ".---", "J"},
            { "-.-", "K"},
            { ".-..", "L"},
            { "--", "M"},
            { "-.", "N"},
            { "---", "O"},
            { ".--.", "P"},
            { "--.-", "Q"},
            { ".-.", "R"},
            { "...", "S"},
            { "-", "T"},
            { "..-", "U"},
            { "...-", "V"},
            { ".--", "W"},
            { "-..-", "X"},
            { "-.--", "Y"},
            { "--..", "Z"},
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
            foreach (var item in signals.ToCharArray())
            {
                chars.Add(item);
            }

            char? first = chars.Count > 0 && !chars[0].Equals('?') ? chars[0] : (char?)null;
            char? second = chars.Count > 1 && !chars[1].Equals('?') ? chars[1] : (char?)null;
            char? third = chars.Count > 2 && !chars[2].Equals('?') ? chars[2] : (char?)null;

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

        public static string[] PossibilitiesNotWorking(string signals)
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

            var length = signals.Length;

            char? charactere = null;

            bool hasOneUnknown = false;

            if (signals.Equals("?"))
            {
                hasOneUnknown = true;
            }

            var indexOf = 0;

            if (!hasOneUnknown)
            {
                foreach (var item in signals.ToCharArray())
                {
                    if (item.Equals('?')) continue;

                    charactere = item;

                    break;
                }

                indexOf = signals.IndexOf(charactere.Value);
            }

            var lengthWithSignals = morseCode.Where(x => x.Key.Length.Equals(signals.Length)).ToList();

            if (!hasOneUnknown)
            {
                lengthWithSignals = lengthWithSignals.OrderByDescending(x => x.Key, StringComparer.Ordinal).ToList();

                result = lengthWithSignals.Where(x => x.Key[indexOf].Equals(charactere)).Select(x => x.Value).ToList();
            }
            else
            {
                lengthWithSignals = lengthWithSignals.OrderByDescending(x => x.Key, StringComparer.Ordinal).ToList();

                result = lengthWithSignals.Select(x => x.Value).ToList();
            }

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
