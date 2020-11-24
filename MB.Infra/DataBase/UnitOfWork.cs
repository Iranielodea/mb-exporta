using MB.Dominio.Shared;
using System.Data;

namespace MB.Infra.DataBase
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        internal UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        IDbConnection _connection;
        static IDbTransaction _transaction;

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        public void BeginTransaction()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction != null)
                _transaction.Commit();

            _transaction.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            if (_transaction != null)
                _transaction.Rollback();

            _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();

            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }
    }
}
