using MySql.Data.MySqlClient;
using System;
using System.Data;

public class DatabaseManager
{
    private MySqlConnection connection;
    private MySqlConnectionStringBuilder builder;

    public DatabaseManager(string server, string database, string userId, string password)
    {
        builder = new MySqlConnectionStringBuilder
        {
            Server = server,
            UserID = userId,
            Password = password,
            Database = database
        };

        connection = new MySqlConnection(builder.ToString());
    }

    public void Connect()
    {
        try
        {
            connection.Open();
            Console.WriteLine("Conexión a la base de datos establecida.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
        }
    }

    public void Disconnect()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Conexión a la base de datos cerrada.");
        }
    }

    public void ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
    {
        using (MySqlCommand cmd = connection.CreateCommand())
        {
            cmd.CommandText = query;
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta no selectiva: {ex.Message}");
            }
        }
    }

    /* public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
     {
         DataTable dataTable = new DataTable();
         using (MySqlCommand cmd = connection.CreateCommand())
         {
             cmd.CommandText = query;
             if (parameters != null) cmd.Parameters.AddRange(parameters);
             try
             {
                 MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                 adapter.Fill(dataTable);
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
             }
         }
         return dataTable;
     }*/
    public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
    {
        DataTable dataTable = new DataTable();
        using (MySqlCommand cmd = connection.CreateCommand())
        {
            cmd.CommandText = query;
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
            }
        }
        return dataTable;
    }


    // CRUD Operations para Pacientes
    public void CrearPaciente(string nombre, string apellidos, string dni, DateTime fechaNacimiento, string comentario)
    {
        string query = "INSERT INTO Pacientes (nombre, apellidos, dni, fecha_nacimiento, comentario) VALUES (@nombre, @apellidos, @dni, @fechaNacimiento, @comentario)";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
            new MySqlParameter("@nombre", nombre),
            new MySqlParameter("@apellidos", apellidos),
            new MySqlParameter("@dni", dni),
            new MySqlParameter("@fechaNacimiento", fechaNacimiento),
            new MySqlParameter("@comentario", comentario)
        });
    }

    // Agregar más métodos para operaciones CRUD de NotasClinicas y Videos

    // Métodos CRUD para UsuariosPrograma (ya incluidos)
    public void CrearUsuario(string username, string password)
    {
        string query = "INSERT INTO UsuariosPrograma (username, password) VALUES (@username, @password)";
        ExecuteNonQuery(query, new MySqlParameter[] {
            new MySqlParameter("@username", username),
            new MySqlParameter("@password", password)
        });
    }

   /* public DataTable LeerUsuarios()
    {
        string query = "SELECT username, password FROM UsuariosPrograma";
        return ExecuteQuery(query);
    }*/

    public void ActualizarUsuario(string username, string newPassword)
    {
        string query = "UPDATE UsuariosPrograma SET password = @newPassword WHERE username = @username";
        ExecuteNonQuery(query, new MySqlParameter[] {
            new MySqlParameter("@username", username),
            new MySqlParameter("@newPassword", newPassword)
        });
    }

    public void EliminarUsuario(string username)
    {
        string query = "DELETE FROM UsuariosPrograma WHERE username = @username";
        ExecuteNonQuery(query, new MySqlParameter[] {
            new MySqlParameter("@username", username)
        });
    }

    public void CrearNotaClinica(int pacienteId, string contenido)
    {
        string query = "INSERT INTO NotasClinicas (paciente_id, contenido) VALUES (@pacienteId, @contenido)";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId),
        new MySqlParameter("@contenido", contenido)
        });
    }

    public DataTable LeerNotasClinicasPorPaciente(int pacienteId)
    {
        string query = "SELECT nota_id, contenido FROM NotasClinicas WHERE paciente_id = @pacienteId";
        return ExecuteQuery(query, new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId)
        });
    }

    public void ActualizarNotaClinica(int notaId, string nuevoContenido)
    {
        string query = "UPDATE NotasClinicas SET contenido = @nuevoContenido WHERE nota_id = @notaId";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
        new MySqlParameter("@notaId", notaId),
        new MySqlParameter("@nuevoContenido", nuevoContenido)
        });
    }
    public void EliminarNotaClinica(int notaId)
    {
        string query = "DELETE FROM NotasClinicas WHERE nota_id = @notaId";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
        new MySqlParameter("@notaId", notaId)
        });
    }

    public void CrearVideo(string titulo, TimeSpan duracion, string categoria, string descripcion)
{
    string query = "INSERT INTO Videos (titulo, duracion, categoria, descripcion) VALUES (@titulo, @duracion, @categoria, @descripcion)";
    ExecuteNonQuery(query, new MySqlParameter[]
    {
        new MySqlParameter("@titulo", titulo),
        new MySqlParameter("@duracion", duracion.ToString()),
        new MySqlParameter("@categoria", categoria),
        new MySqlParameter("@descripcion", descripcion)
    });
}

public DataTable LeerVideos()
{
    string query = "SELECT video_id, titulo, duracion, categoria, descripcion FROM Videos";
    return ExecuteQuery(query);
}

public void ActualizarVideo(int videoId, string nuevoTitulo, TimeSpan nuevaDuracion, string nuevaCategoria, string nuevaDescripcion)
{
    string query = "UPDATE Videos SET titulo = @nuevoTitulo, duracion = @nuevaDuracion, categoria = @nuevaCategoria, descripcion = @nuevaDescripcion WHERE video_id = @videoId";
    ExecuteNonQuery(query, new MySqlParameter[]
    {
        new MySqlParameter("@videoId", videoId),
        new MySqlParameter("@nuevoTitulo", nuevoTitulo),
        new MySqlParameter("@nuevaDuracion", nuevaDuracion.ToString()),
        new MySqlParameter("@nuevaCategoria", nuevaCategoria),
        new MySqlParameter("@nuevaDescripcion", nuevaDescripcion)
    });
}

public void EliminarVideo(int videoId)
{
    string query = "DELETE FROM Videos WHERE video_id = @videoId";
    ExecuteNonQuery(query, new MySqlParameter[]
    {
        new MySqlParameter("@videoId", videoId)
    });
}

}
