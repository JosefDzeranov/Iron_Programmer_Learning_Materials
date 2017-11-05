using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Ploeh.AutoFixture;

namespace Algorithms.Tests
{
    [TestFixture]
    internal sealed class CollectionsTests
    {
        private Fixture _fixture;

        [SetUp]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void Shiffle_EmpltyCollection_EmptyCollectionReturned()
        {
            // Arrange
            var collection = new List<int>();

            // Act
            collection.Shiffle();

            // Assert
            Assert.NotNull(collection, "collection is null.");
            Assert.AreEqual(0, collection.Count, "Collection count should be 0, but it is {0}.", collection.Count);
        }

        [Test]
        public void Shiffle_Items_MixedItemsReturned()
        {
            // Arrange
            var count = Math.Abs(_fixture.Create<int>());
            var collection = _fixture.CreateMany<int>(count).Distinct().ToList();
            var collection2 = new List<int>(collection);
            // Act
            collection.Shiffle();

            // Assert
            Assert.NotNull(collection, "Collection is null.");
            Assert.AreEqual(count, collection.Count, "Collection count should be {0}, but it is {1}.", count, collection.Count);
            collection.Should().OnlyHaveUniqueItems();
            for (int i = 0; i < count; i++)
            {
                collection[i].Should().NotBe(collection2[i], "Items not shuffled.");
            }
        }

    }
}
