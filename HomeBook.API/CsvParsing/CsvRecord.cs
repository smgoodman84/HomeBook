using System;

namespace HomeBook.API.CsvParsing
{
    internal class CsvRecord
    {
        private readonly string[] _headings;
        private readonly string[] _values;

        public CsvRecord(string[] headings, string[] values)
        {
            _headings = headings;
            _values = values;
        }

        public DateTime GetDateTime(string fieldName)
        {
            return DateTime.Parse(GetString(fieldName));
        }

        public string GetString(string fieldName)
        {
            var index = 0;
            foreach (var heading in _headings)
            {
                if (heading == fieldName)
                {
                    return _values[index];
                }

                index += 1;
            }

            throw new FieldNotFoundException();
        }

        public decimal GetDecimal(string fieldName)
        {
            var value = GetOptionalDecimal(fieldName);

            if (!value.HasValue)
            {
                throw new FormatException("${fieldName} did not have a value");
            }

            return value.Value;
        }

        public decimal? GetOptionalDecimal(string fieldName)
        {
            var value = GetString(fieldName);

            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return decimal.Parse(value);
        }
    }
}