﻿namespace Unicorn.Core.Testing.Verification.Matchers.CoreMatchers
{
    public class EqualToMatcher : Matcher
    {
        private object objectToCompare;

        public EqualToMatcher(object objectToCompare)
        {
            this.objectToCompare = objectToCompare;
        }

        public override string CheckDescription => "Is equal to " + this.objectToCompare;

        public override bool Matches(object obj)
        {
            if (obj == null)
            {
                DescribeMismatch("null");
                return Reverse;
            }

            if (!this.objectToCompare.GetType().Equals(obj.GetType()))
            {
                DescribeMismatch($"not of type {this.objectToCompare.GetType()}");
                return false;
            }

            if (!obj.Equals(this.objectToCompare))
            {
                DescribeMismatch(obj.ToString());
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
