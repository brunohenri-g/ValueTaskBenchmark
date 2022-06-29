using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ValueTasksBenchmark
{

    [MemoryDiagnoser]
    public class ValueTaskBenchamrk
    {
        readonly Repository _repo = new Repository();
        readonly Random _rnd = new Random(42);
        readonly string _data;


        public ValueTaskBenchamrk()
        {
            _data = _rnd.Next().ToString();
        }

        [Benchmark]
        public async Task RunTaskRandomAsync() => await _repo.GetDataWithTaskAsync(_data);


        [Benchmark]
        public async Task RunValueTaskRandomAsync() => await _repo.GetDataWithValueTaskAsync(_data);

        [Benchmark]
        public async Task RunTaskAsync() => await _repo.GetDataWithTaskAsync("CONST_KEY");


        [Benchmark]
        public async Task RunValueTaskAsync() => await _repo.GetDataWithValueTaskAsync("CONST_KEY");
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
