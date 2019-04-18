using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Monkey;
using Monkey.Shared;

namespace Monkey.Tests
{
    [TestClass]
    public class Compiling
    {
        Scanner scanner = new Scanner();
        Parser parser = new Parser();
        Compiler compiler = new Compiler();

        [TestMethod]
        [DataRow("1 + 2")]
        public void Compile(string source)
        {
            var actual = compiler.Compile(parser.Parse(scanner.Scan(source)));
            Utilities.Assert.AreDeeplyEqual(actual, Fixtures.Compiler.Compile[source]);
        }
    }
}