using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HomeBook.API.CsvParsing
{
    internal class CsvParser
    {
        private Action<string> _processLine;
        private string[] _headings;
        private List<CsvRecord> _values;

        public IEnumerable<CsvRecord> ParseFile(string filePath)
        {
            var fileContent = File.ReadAllText(filePath);

            _processLine = ProcessHeading;

            var linesToProcess = Lines(fileContent)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            // linesToProcess.ForEach(_processLine) doesn't work here.
            foreach (var line in linesToProcess)
            {
                _processLine(line);
            }

            return _values;
        }

        private void ProcessHeading(string line)
        {
            _headings = Values(line)
                .Select(x => x.Trim())
                .ToArray();
            _values = new List<CsvRecord>();
            _processLine = ProcessRow;
        }

        private void ProcessRow(string line)
        {
            var values = Values(line).ToArray();
            _values.Add(new CsvRecord(_headings, values));
        }

        private IEnumerable<string> Values(string line)
        {
            var inQuotes = false;
            var sb = new StringBuilder();
            foreach (var c in line)
            {
                switch (c)
                {
                    case ',':
                        if (inQuotes)
                        {
                            break;
                        }

                        yield return sb.ToString();
                        sb.Length = 0;
                        break;

                    case '"':
                         inQuotes = !inQuotes;
                        break;

                    default:
                        sb.Append(c);
                        break;
                }
            }

            yield return sb.ToString();
        }

        private static IEnumerable<string> Lines(string fileContent)
        {
            var sb = new StringBuilder();
            foreach (var c in fileContent)
            {
                switch (c)
                {
                    case '\r': continue;
                    case '\n':
                        yield return sb.ToString();
                        sb.Length = 0;
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
        }
    }
}
