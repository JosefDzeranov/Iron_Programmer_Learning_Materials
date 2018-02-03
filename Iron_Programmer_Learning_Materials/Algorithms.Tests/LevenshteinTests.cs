using System;
using Algorithms.Strings;
using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace Algorithms.Tests
{
    internal sealed class LevenshteinTests
    {
        private Fixture _fixture;

        [SetUp]
        public void TestInitialize()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void Levenshtein_OneStringEmpty_LengthSecondStringReturned()
        {
            // Arrange
            var s = "";
            Random r = new Random();
            var t = string.Join(string.Empty, _fixture.CreateMany<char>(r.Next(100)));

            var expected = new Prescription(t.Length, "");


            // Act
            var levenshtein1 = Metrics.Levenshtein.Solve(s, t);
            var levenshtein2 = Metrics.Levenshtein.Solve(t, s);

            // Assert
            Assert.AreEqual(expected.Distance, levenshtein1.Distance, $"Solve distance should be {expected.Distance}, but it is {levenshtein1.Distance}.");
            Assert.AreEqual(expected.Distance, levenshtein2.Distance, $"Solve distance should be {expected.Distance}, but it is {levenshtein2.Distance}.");
        }

        [Test]
        public void Levenshtein_EqualStrings_ZeroReturned()
        {
            // Arrange
            Random r = new Random();
            var s = string.Join(string.Empty, _fixture.CreateMany<char>(r.Next(100)));
            var t = s;
            var expectedPath = "";
            for (var i = 0; i < t.Length; i++)
            {
                expectedPath += "M";
            }
            var expected = new Prescription(0, expectedPath);


            // Act
            var actual1 = Metrics.Levenshtein.Solve(s, t);
            var actual2 = Metrics.Levenshtein.Solve(t, s);

            // Assert
            actual1.ShouldBeEquivalentTo(expected);
            actual2.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Levenshtein_Insert_DeficitCharsReturned()
        {
            // Arrange
            var s = "ABC";
            var t = "ABCDEF";
            var expected = new Prescription(3, "MMMIII");

            // Act
            var actual = Metrics.Levenshtein.Solve(s, t);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Levenshtein_DeleteAndInsert_DeficitCharsReturned()
        {
            // Arrange
            var s = "ABC";
            var t = "BCDE";
            var expected = new Prescription(3, "MMII");

            // Act
            var actual = Metrics.Levenshtein.Solve(s, t);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }


        [Test]
        public void Levenshtein_DeleteAndInsert2_DeficitCharsReturned()
        {
            // Arrange
            var s = "BCDE";
            var t = "ABCDEF";
            var expected = new Prescription(2, "MMMMI");

            // Act
            var actual = Metrics.Levenshtein.Solve(s, t);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void Levenshtein_ComplexityExample_DeficitCharsReturned()
        {
            // Arrange
            var s = "ATGTTATA";
            var t = "ATCGTCC";
            var expected = new Prescription(5, "MMRRMDRR");

            // Act
            var actual = Metrics.Levenshtein.Solve(s, t);

            // Assert
            actual.ShouldBeEquivalentTo(expected);
        }
    }
}
