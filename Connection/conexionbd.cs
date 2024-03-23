namespace AutotechApi.Connection
{
    public class Conexionbd
    {
        private string connectionString = string.Empty;

        public Conexionbd()
        {
            //Sentencia sql para traer los datos de la BD
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = builder.GetSection("ConnectionStrings:conexion").Value;
        }
        //Devolvemos la cadena ConnectionString
        public string cadenaSql() 
        { 
            return connectionString; 
        }
    }
}
