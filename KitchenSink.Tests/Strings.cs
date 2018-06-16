﻿using System.Linq;
using System.Text.RegularExpressions;
using static KitchenSink.Operators;
using KitchenSink.Extensions;
using NUnit.Framework;

namespace KitchenSink.Tests
{
    public class Strings
    {
        [Test]
        public void StringSeqTest()
        {
            const string s = "comma, separated, string with multiple, comma, separated, parts";
            var splits = s.Split(",").ToList();
            Assert.AreEqual(6, splits.Count);
        }

        [Test]
        public void StringRegexSeq()
        {
            var usPhoneRegex = new Regex(@"(\x28?\d{3}\x29?[\x20\x2D\x2E])?(\d{3})[\x20\x2D\x2E](\d{4})");
            const string s = "some text that (123) 555-1234 contains some U.S. phone 432.6545 numbers of varying 654 234 1233 formats";
            var splits = s.Split(usPhoneRegex).ToList();
            Assert.AreEqual(3, splits.Count);
            Assert.IsTrue(splits.SequenceEqual(SeqOf("(123) 555-1234", "432.6545", "654 234 1233")));
        }

        [Test]
        public void CollapseWhiteSpace()
        {
            Assert.AreEqual("asd fdjkv sdfv fsv as4 '", " asd   fdjkv sdfv \nfsv \r\ras4 '  ".CollapseSpace());
        }
    }
}