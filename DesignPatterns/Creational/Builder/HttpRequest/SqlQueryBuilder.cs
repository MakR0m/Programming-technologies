using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.HttpRequest
{
    public class SqlQueryBuilder
    {
        private string _table;
        private List<string> _columns = new();
        private List<string> _where = new();
        private string _orderBy;

        public SqlQueryBuilder Select(params string[] columns)
        {
            _columns.AddRange(columns);
            return this;
        }

        public SqlQueryBuilder From(string table)
        {
            _table = table;
            return this;
        }

        public SqlQueryBuilder Where(string condition)
        {
            _where.Add(condition);
            return this;
        }

        public SqlQueryBuilder OrderBy(string column)
        {
            _orderBy = column;
            return this;
        }

        public string Build()
        {
            if (string.IsNullOrWhiteSpace(_table))
                throw new InvalidOperationException("Таблица не указана");

            var selectPart = _columns.Any() ? string.Join(", ", _columns) : "*"; //Any - есть что либо  //Тернарный оператор (if/else сжатый)

            var sql = new StringBuilder();
            sql.Append($"SELECT {selectPart} FROM {_table}");

            if (_where.Any())
                sql.Append(" WHERE " + string.Join(" AND ", _where));

            if (!string.IsNullOrWhiteSpace(_orderBy))
                sql.Append($" ORDER BY {_orderBy}");

            return sql.ToString();
        }
    }
}
