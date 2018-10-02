using System;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Akroma.Integration.Tests
{
    public class AkromaTests
    {
        [Test]
        public async Task ErrorHandlingTest()
        {
            var akroma = new Akroma();
            var response = await akroma.FailMethod();
            response.Ok.Should().BeFalse();
            response.Error.Code.Should().Be(-32601);
        }

        [Test]
        public async Task FindTransactionForAddressTest()
        {
            var akroma = new Akroma();
            const string address = "0x5d82aa8a77d1c37bcfad24ce746b77ae4aea13c9";
            const string data = "0x6561346664663632333666623436393062396161336339343963633165393535";
            var response = await akroma.GetTransactionsByAddress(address);
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            foreach (var hash in response.Result)
            {
                var tx = await akroma.GetTransactionByHash(hash);
                if (tx.Result.Input == data
                    && tx.Result.To == address
                    && tx.Result.From == address)
                {
                    Console.WriteLine(tx.Result.Input);
                    Console.WriteLine("found it.");
                    break;
                }
            }
        }

        [Test]
        public async Task GetBalanceTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetBalance("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            Console.Write(response.Result);
        }

        [Test]
        public async Task ListeningTest()
        {
            var akroma = new Akroma();
            var response = await akroma.Listening();
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

        [Test]
        public async Task GetBlockByHashTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetBlockByHash("0xa6a73739fdcd0e4b9c4c6447cea3c80511494ff74e4fda6c286ce81819b1af5b");
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            var number = response.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetBlockByNumberTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetBlockByNumber();
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            var number = response.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetBlockByNumberWithTransactionsTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetBlockByNumberWithTransactions();
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            Console.Write(response.Result);
            var number = response.Result.Number.Value;
            number.Should().BeGreaterThan(1693827);
        }

        [Test]
        public async Task GetTransactionByHashTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetTransactionByHash("0x4f34f255aa8efb866ad5f0fc81c8411bf7aa9f1361773587762c27b9a0066231");
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
        }

        [Test]
        public async Task GetTransactionCountByAddressTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetTransactionCountByAddress("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            var number = response.Result.Value;
            number.Should().Be(3);
        }

        [Test]
        public async Task GetTransactionsByAddressTest()
        {
            var akroma = new Akroma();
            var response = await akroma.GetTransactionsByAddress("0x09033F3fF86F889602A57ED2c434B9D85642A0e2");
            response.Ok.Should().BeTrue("there is a local node running for the int tests.");
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            foreach (var transaction in response.Result) Console.WriteLine(transaction);
        }
    }
}