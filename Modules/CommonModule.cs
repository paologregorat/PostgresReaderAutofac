using Autofac;
using WebAPIPostgresReader.Abstract;
using WebAPIPostgresReader.Infracstructure;

namespace WebAPIPostgresReader.Modules
{
    public class CommonModule : Autofac.Module
    {
        private readonly string _connectionString;

        public CommonModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlReader>().As<IReader>().WithParameter("connectionString", _connectionString).SingleInstance();
        }
    }
}