using asp_net_core_cli.Interfaces;

namespace asp_net_core_cli.Models
{
    public class Sample : ISample
    {
        private static int _counter;
        private int _id;

        public Sample()
        {
            _id = ++_counter;
        }

        public int Id => _id;
    }
}