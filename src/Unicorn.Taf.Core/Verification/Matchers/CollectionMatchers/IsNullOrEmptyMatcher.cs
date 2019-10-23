﻿using System.Collections;

namespace Unicorn.Taf.Core.Verification.Matchers.CollectionMatchers
{
    /// <summary>
    /// Matcher to check if collection is null or empty. 
    /// </summary>
    public class IsNullOrEmptyMatcher : TypeUnsafeMatcher
    {
        public IsNullOrEmptyMatcher()
        {
        }

        /// <summary>
        /// Gets check description
        /// </summary>
        public override string CheckDescription => "Is empty";

        public override bool Matches(object actual)
        {
            ICollection collection = (ICollection)actual;

            if (collection == null)
            {
                DescribeMismatch("null");
                return true;
            }

            this.DescribeMismatch($"of length = {collection.Count}");
            return collection.Count == 0;
        }
    }
}
