using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OneCog.Testing.SpecFlow;

namespace OneCog.Testing.SpecFlow.Tests
{
    [TestFixture]
    public class TestExtensions
    {
        public enum Gender { Male, Female }

        [Test]
        public void ShouldBeAbleToReadAString()
        {
            Table table = new Table(new[] { "Name", "Age", "Gender", "Height" });
            table.AddRow(new[] { "Ian", "37", "Male", "1.73" });

            Assert.That(table.Rows.First().Read<string>("Name"), Is.EqualTo("Ian"));
        }

        [Test]
        public void ShouldBeAbleToReadAnInteger()
        {
            Table table = new Table(new[] { "Name", "Age", "Gender", "Height" });
            table.AddRow(new[] { "Ian", "37", "Male", "1.73" });

            Assert.That(table.Rows.First().Read<int>("Age"), Is.EqualTo(37));
        }

        [Test]
        public void ShouldBeAbleToReadADouble()
        {
            Table table = new Table(new[] { "Name", "Age", "Gender", "Height" });
            table.AddRow(new[] { "Ian", "37", "Male", "1.73" });

            Assert.That(table.Rows.First().Read<double>("Height"), Is.EqualTo(1.73));
        }

        [Test]
        public void ShouldBeAbleToReadAnEnumeration()
        {
            Table table = new Table(new[] { "Name", "Age", "Gender", "Height" });
            table.AddRow(new[] { "Ian", "37", "Male", "1.73" });

            Assert.That(table.Rows.First().ReadEnum<Gender>("Gender"), Is.EqualTo(Gender.Male));
        }
    }
}
