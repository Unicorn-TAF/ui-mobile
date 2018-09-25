﻿using System.Collections;

namespace Unicorn.Core.Testing.Verification.Matchers.CollectionMatchers
{
    public class IsNullOrEmptyMatcher : Matcher
    {
        public IsNullOrEmptyMatcher()
        {
        }

        public override string CheckDescription => "Is empty";

        public override bool Matches(object actual)
        {
            ICollection collection = (ICollection)actual;

            if (collection == null || collection.Count == 0)
            {
                return true;
            }
            else
            {
                this.DescribeMismatch($"of length = {collection.Count}");
                return false;
            }
        }
    }
}
