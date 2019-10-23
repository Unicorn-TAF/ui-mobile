﻿using System.Collections.Generic;
using System.Linq;

namespace Unicorn.Taf.Core.Verification.Matchers.CollectionMatchers
{
    /// <summary>
    /// Matcher to check if aech collection element matches specified matcher. 
    /// </summary>
    /// <typeparam name="T">check items type</typeparam>
    public class EachMatcher<T> : TypeSafeCollectionMatcher<T>
    {
        private readonly TypeSafeMatcher<T> matcher;

        public EachMatcher(TypeSafeMatcher<T> matcher)
        {
            this.matcher = matcher;
        }

        /// <summary>
        /// Gets check description
        /// </summary>
        public override string CheckDescription => $"Each element {this.matcher.CheckDescription}";

        public override bool Matches(IEnumerable<T> actual)
        {
            if (actual == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            var matches = true;

            for (var i = 0; i < actual.Count(); i++)
            {
                if (!this.matcher.Matches(actual.ElementAt(i)))
                {
                    matches = false;
                    this.Output.AppendFormat("element at index {0}:", i).AppendLine(this.matcher.Output.ToString());
                    this.matcher.Output.Clear();
                }
            }

            return matches;
        }
    }
}
