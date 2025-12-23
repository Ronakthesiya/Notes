using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Abstractions
{
    /// <summary>
    /// Abstract base class for importing domain models from files.
    /// Marked abstract so concrete types must define parsing logic.
    /// </summary>
    public abstract class FileImporter<T>
    {
        /// <summary>
        /// Parse a file at <paramref name="path"/> into a sequence of <typeparamref name="T"/>.
        /// </summary>
        public abstract IEnumerable<T> Import(string path);

    }

}
