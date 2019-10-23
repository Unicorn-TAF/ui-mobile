﻿namespace Unicorn.Taf.Core.Verification.Matchers.CoreMatchers
{
    /// <summary>
    /// Matcher to negotiate action of another matcher
    /// </summary>
    /// <typeparam name="T">check items type</typeparam>
    public class TypeSafeNotMatcher<T> : TypeSafeMatcher<T>
    {
        private readonly TypeSafeMatcher<T> matcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeSafeNotMatcher{T}"/> class for specified matcher.
        /// </summary>
        /// <param name="matcher">instance of matcher with specified check</param>
        public TypeSafeNotMatcher(TypeSafeMatcher<T> matcher)
        {
            matcher.Reverse = true;
            this.matcher = matcher;
        }

        /// <summary>
        /// Gets check description.
        /// </summary>
        public override string CheckDescription => $"Not {this.matcher.CheckDescription}";

        public override bool Matches(T actual)
        {
            if (this.matcher.Matches(actual))
            {
                this.Output.Append(this.matcher.Output);
                return false;
            }

            return true;
        }
    }
}
