using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Akroma.Core.Integration.Tests
{
    public class AkromaTests
    {
        [Test]
        public async Task GetBalanceTest()
        {
            var akroma = new Akroma();
            var balance = await akroma.GetBalance("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            Console.Write(balance.Result);
        }

        [Test]
        public async Task GetBlockByHashTest()
        {
            var akroma = new Akroma();
            var block = await akroma.GetBlockByHash(
                "0xa6a73739fdcd0e4b9c4c6447cea3c80511494ff74e4fda6c286ce81819b1af5b");
            var number = block.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetBlockByNumberTest()
        {
            var akroma = new Akroma();
            var block = await akroma.GetBlockByNumber();
            var number = block.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetTransactionCountByAddressTest()
        {
            var akroma = new Akroma();
            var block = await akroma.GetTransactionCountByAddress("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            var number = block.Result.Value;
            number.Should().Be(3);
        }

        [Test]
        public async Task GetBlockByNumberWithTransactionsTest()
        {
            var akroma = new Akroma();
            var query = await akroma.GetBlockByNumberWithTransactions();
            Console.Write(query.Result);
            var number = query.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetTransactionsByAddressTest()
        {
            var akroma = new Akroma();
            var balance = await akroma.GetTransactionsByAddress("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            foreach (var transaction in balance.Result)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}