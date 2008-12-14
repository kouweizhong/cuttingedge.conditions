﻿#region Copyright (c) 2008 S. van Deursen
/* The CuttingEdge.Conditions library enables developers to validate pre- and postconditions in a fluent 
 * manner.
 * 
 * Copyright (C) 2008 S. van Deursen
 * 
 * To contact me, please visit my blog at http://www.cuttingedge.it/blogs/steven/ 
 *
 * This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser 
 * General Public License as published by the Free Software Foundation; either version 2.1 of the License, or
 * (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the 
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 * License for more details.
*/
#endregion

// NOTE: This file a copy of ValidatorExtensionTests.Compare.Base.cs with all occurrences of 'xxx' replaced
// with 'Decimal'.
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CuttingEdge.Conditions.UnitTests.CompareTests
{
    [TestClass]
    public class CompareDecimalTests
    {
        private static readonly Decimal One = 1;
        private static readonly Decimal Two = 2;
        private static readonly Decimal Three = 3;
        private static readonly Decimal Four = 4;
        private static readonly Decimal Five = 5;

        #region IsDecimalInRange

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound > x < upper bound' should fail.")]
        public void IsDecimalInRangeTest01()
        {
            Decimal a = One;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound = x < upper bound' should pass.")]
        public void IsDecimalInRangeTest02()
        {
            Decimal a = Two;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x < upper bound' should pass.")]
        public void IsDecimalInRangeTest03()
        {
            Decimal a = Three;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x = upper bound' should pass.")]
        public void IsDecimalInRangeTest04()
        {
            Decimal a = Four;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsInRange on Decimal x with 'lower bound < x > upper bound' should fail.")]
        public void IsDecimalInRangeTest05()
        {
            Decimal a = Five;
            a.Requires().IsInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalInRangeTest06()
        {
            Decimal a = Four;
            a.Requires().IsInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalInRangeTest07()
        {
            Decimal a = Five;
            try
            {
                a.Requires("a").IsInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalInRange

        #region IsDecimalNotInRange

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound > x < upper bound' should pass.")]
        public void IsDecimalNotInRangeTest01()
        {
            Decimal a = One;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound = x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x < upper bound' should fail.")]
        public void IsDecimalNotInRangeTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x = upper bound' should fail.")]
        public void IsDecimalNotInRangeTest04()
        {
            Decimal a = Four;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with 'lower bound < x > upper bound' should pass.")]
        public void IsDecimalNotInRangeTest05()
        {
            Decimal a = Five;
            a.Requires().IsNotInRange(Two, Four);
        }

        [TestMethod]
        [Description("Calling IsNotInRange on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotInRangeTest06()
        {
            Decimal a = Five;
            a.Requires().IsNotInRange(Two, Four, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotInRange on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotInRangeTest07()
        {
            Decimal a = Four;
            try
            {
                a.Requires("a").IsNotInRange(Two, Four, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalNotInRange

        #region IsDecimalGreaterThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should fail.")]
        public void IsDecimalGreaterThanTest01()
        {
            Decimal a = One;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalGreaterThanTest02()
        {
            Decimal a = Two;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterThanTest03()
        {
            Decimal a = Three;
            a.Requires().IsGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterThanTest04()
        {
            Decimal a = Three;
            a.Requires().IsGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterThanTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsGreaterThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalGreaterThan

        #region IsDecimalNotGreaterThan

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest01()
        {
            Decimal a = One;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalNotGreaterThanTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterThanTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotGreaterThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterThanTest04()
        {
            Decimal a = Two;
            a.Requires().IsNotGreaterThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterThanTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsNotGreaterThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalNotGreaterThan

        #region IsDecimalGreaterOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalGreaterOrEqualTest01()
        {
            Decimal a = One;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalGreaterOrEqualTest02()
        {
            Decimal a = Two;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalGreaterOrEqualTest03()
        {
            Decimal a = Three;
            a.Requires().IsGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalGreaterOrEqualTest04()
        {
            Decimal a = Three;
            a.Requires().IsGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalGreaterOrEqualTest05()
        {
            Decimal a = One;
            try
            {
                a.Requires("a").IsGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalGreaterOrEqual

        #region IsDecimalNotGreaterOrEqual

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalNotGreaterOrEqualTest01()
        {
            Decimal a = One;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalNotGreaterOrEqualTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotGreaterOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotGreaterOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotGreaterOrEqualTest04()
        {
            Decimal a = One;
            a.Requires().IsNotGreaterOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotGreaterOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotGreaterOrEqualTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsNotGreaterOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalNotGreaterOrEqual

        #region IsDecimalLessThan

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessThanTest01()
        {
            Decimal a = One;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x = upper bound' should fail.")]
        public void IsDecimalLessThanTest02()
        {
            Decimal a = Two;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessThan on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessThanTest03()
        {
            Decimal a = Three;
            a.Requires().IsLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessThanTest04()
        {
            Decimal a = Two;
            a.Requires().IsLessThan(Three, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessThanTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsLessThan(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalLessThan

        #region IsDecimalNotLessThan

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessThanTest01()
        {
            Decimal a = One;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound = x' should pass.")]
        public void IsDecimalNotLessThanTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessThanTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotLessThan(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessThan on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessThanTest04()
        {
            Decimal a = Two;
            a.Requires().IsNotLessThan(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessThan on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessThanTest05()
        {
            Decimal a = Two;
            try
            {
                a.Requires("a").IsNotLessThan(Three, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalNotLessThan

        #region IsDecimalLessOrEqual

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x < upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest01()
        {
            Decimal a = One;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with 'x = upper bound' should pass.")]
        public void IsDecimalLessOrEqualTest02()
        {
            Decimal a = Two;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsLessOrEqual on Decimal x with 'x > upper bound' should fail.")]
        public void IsDecimalLessOrEqualTest03()
        {
            Decimal a = Three;
            a.Requires().IsLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalLessOrEqualTest04()
        {
            Decimal a = Two;
            a.Requires().IsLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalLessOrEqualTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalLessOrEqual

        #region IsDecimalNotLessOrEqual

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound > x' should fail.")]
        public void IsDecimalNotLessOrEqualTest01()
        {
            Decimal a = One;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound = x' should fail.")]
        public void IsDecimalNotLessOrEqualTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Decimal x with 'lower bound < x' should pass.")]
        public void IsDecimalNotLessOrEqualTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotLessOrEqual(Two);
        }

        [TestMethod]
        [Description("Calling IsNotLessOrEqual on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotLessOrEqualTest04()
        {
            Decimal a = Three;
            a.Requires().IsNotLessOrEqual(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotLessOrEqual on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotLessOrEqualTest05()
        {
            Decimal a = Two;
            try
            {
                a.Requires("a").IsNotLessOrEqual(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsNotLessOrEqual

        #region IsDecimalEqualTo

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x < other' should fail.")]
        public void IsDecimalEqualToTest01()
        {
            Decimal a = One;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with 'x = other' should pass.")]
        public void IsDecimalEqualToTest02()
        {
            Decimal a = Two;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsEqualTo on Decimal x with 'x > other' should fail.")]
        public void IsDecimalEqualToTest03()
        {
            Decimal a = Three;
            a.Requires().IsEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalEqualToTest04()
        {
            Decimal a = Two;
            a.Requires().IsEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalEqualToTest05()
        {
            Decimal a = Three;
            try
            {
                a.Requires("a").IsEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalEqualTo

        #region IsDecimalNotEqualTo

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x < other' should pass.")]
        public void IsDecimalNotEqualToTest01()
        {
            Decimal a = One;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("Calling IsNotEqualTo on Decimal x with 'x = other' should fail.")]
        public void IsDecimalNotEqualToTest02()
        {
            Decimal a = Two;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with 'x > other' should pass.")]
        public void IsDecimalNotEqualToTest03()
        {
            Decimal a = Three;
            a.Requires().IsNotEqualTo(Two);
        }

        [TestMethod]
        [Description("Calling IsNotEqualTo on Decimal x with conditionDescription should pass.")]
        public void IsDecimalNotEqualToTest04()
        {
            Decimal a = Three;
            a.Requires().IsNotEqualTo(Two, string.Empty);
        }

        [TestMethod]
        [Description("Calling a failing IsNotEqualTo on Decimal should throw an Exception with an exception message that contains the given parameterized condition description argument.")]
        public void IsDecimalNotEqualToTest05()
        {
            Decimal a = Two;
            try
            {
                a.Requires("a").IsNotEqualTo(Two, "abc {0} xyz");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains("abc a xyz"));
            }
        }

        #endregion // IsDecimalNotEqualTo
    }
}