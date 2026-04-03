using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Cli
{
    public sealed class Options
    {
        public string InputDir { get; init; } = "./in";
        public string Output { get; init; } = "summary.json";
    }

}
