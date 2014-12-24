﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZedSharp.UnitTests
{
    [TestClass]
    public class XmlTests
    {
        [TestMethod]
        public void XmlBuilding()
        {
            String xml;
            String str;

            xml = Xml.Doc < "Person" >= "id" <= "123" < "Name" < "First" <= "John" < "Last" <= "Smith" > Xml.EndDoc;
            str = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Person id=\"123\"><Name><First>John</First><Last>Smith</Last></Name></Person>";
            Assert.AreEqual(str, xml);

            xml = Xml.Doc < "Root" >= "attr" <= "123" >= "attr2" <= "456" >= "attr3" <= "789" > Xml.EndDoc;
            str = "<?xml version=\"1.0\" encoding=\"utf-16\"?><Root attr=\"123\" attr2=\"456\" attr3=\"789\" />";
            Assert.AreEqual(str, xml);
        }
    }
}
