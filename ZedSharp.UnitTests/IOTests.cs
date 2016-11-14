﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZedSharp.UnitTests
{
    [TestClass]
    public class IOTests
    {
        [TestMethod]
        public void IOChaining()
        {
            Assert.AreEqual(1, IO.Of(1).Eval());
            Assert.AreEqual(2, IO.Of(1).Then(IO.Of(2)).Eval());
            Assert.AreEqual(3, IO.Of(1).Join(IO.Of(2), Z.Add).Eval());
        }

        [TestMethod]
        public void IOTransforms()
        {
            Assert.AreEqual(3, IO.Demote(IO.Of(() => Z.Add.Apply(1))).Invoke(2).Eval());
        }
    }
}
