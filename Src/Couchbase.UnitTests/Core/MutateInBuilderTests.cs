﻿using System;
using Couchbase.Core;
using Couchbase.Core.IO.SubDocument;
using Couchbase.Core.Serialization;
using Moq;
using NUnit.Framework;

namespace Couchbase.UnitTests.Core
{
    [TestFixture]
    public class MutateInBuilderTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Replace_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.Replace(path, "somevalue");
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Upsert_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.Upsert(path, "somevalue", false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Insert_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.Insert(path, "somevalue", false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.Remove(path);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void Counter_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.Counter(path, 0, false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ArrayAddUnique_DoesNotThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.ArrayAddUnique(path, 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [ExpectedException(typeof(ArgumentException))]
        public void ArrayInsert_ThrowsArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.ArrayInsert(path, 0);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ArrayAppend_DoesNotThrowArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(),  "thekey");

            builder.ArrayAppend(path, 0, false);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void ArrayPrepend_DoesNotThrowArgumentException_WhenPathIsEmpty(string path)
        {
            var mockedInvoker = new Mock<ISubdocInvoker>();
            var builder = new MutateInBuilder<dynamic>(mockedInvoker.Object, () => new DefaultSerializer(), "thekey");

            builder.ArrayPrepend(path, 0, false);
        }
    }
}
