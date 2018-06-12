﻿using System;
using NUnit.Framework;
using static KitchenSink.Operators;
using KitchenSink.Testing;

namespace KitchenSink.Tests
{
    public class Caching
    {
        [Test]
        public void FunctionMemoization()
        {
            var rand = new Random();
            var f = Memo<string, int>(s => rand.Next());
            Assert.AreEqual(f("a"), f("a"));
            Assert.AreEqual(f("b"), f("b"));
            Assert.AreEqual(f("c"), f("c"));
        }

        public interface IUserRepostiory
        {
            string Get(int id);
        }

        public class UserRepository : IUserRepostiory
        {
            public string Get(int id) => Rand.AsciiString(16);
        }

        [Test, Ignore("Not working")]
        public void AutoCaching()
        {
            IUserRepostiory repo = new UserRepository();
            var cachedRepo = Cache(repo);
            Assert.AreEqual(cachedRepo.Get(1), cachedRepo.Get(1));
            Assert.AreEqual(cachedRepo.Get(2), cachedRepo.Get(2));
            Assert.AreEqual(cachedRepo.Get(3), cachedRepo.Get(3));
        }
    }
}
