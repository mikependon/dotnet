using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProvider.Factories
{
    public static class StringFactory
    {
        public static IEnumerable<string> GetStrings()
        {
            var text = @"We believe that it's time to take real action to create a world that runs on green energy. Renewable energy holds the key to a cleaner future, and we need to act now to reduce the effects of climate change.";
            return text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s?.Trim())
                .Where(s => s?.Length > 0)
                .AsEnumerable();
        }
    }
}
