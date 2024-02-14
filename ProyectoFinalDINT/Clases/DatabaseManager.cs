using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

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
    public DatabaseManager()
    {
        builder = new MySqlConnectionStringBuilder();
        builder.Server = "localhost";
        builder.UserID = "root";
        builder.Password = "";
        builder.Database = "mindfieldvr";
        connection = new MySqlConnection(builder.ToString());
    }

    //METODOS DE CONEXION

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
            MessageBox.Show("Error en la base de datos!!");
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
    //METODOS GENERICOS

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
    public List<string> ConvertirDataTableALista(DataTable dataTable)
    {
        List<string> lista = new List<string>();

        foreach (DataRow row in dataTable.Rows)
        {
            // Asumiendo que quieres convertir la primera columna en string
            lista.Add(row[0].ToString());
        }

        return lista;
    }

    public string SeleccionarPrimerResultado(DataTable dataTable)
    {
        if (dataTable.Rows.Count > 0)
        {
            // Obtiene el primer valor de la primera columna
            return dataTable.Rows[0][0].ToString();
        }

        return null; // O maneja este caso según sea necesario
    }

    public DataTable LeerPacientePorId(int pacienteId)
    {
        string query = @"
        SELECT 
            paciente_id, 
            nombre, 
            apellidos, 
            dni, 
            fecha_nacimiento, 
            sesiones, 
            ultima_sesion, 
            proxima_sesion, 
            comentario 
        FROM Pacientes 
        WHERE paciente_id = @pacienteId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId)
        };

        return ExecuteQuery(query, parameters);
    }





    // CRUD Operations para Pacientes
    /*public void CrearPaciente(string nombre, string apellidos, string dni, DateTime fechaNacimiento, string comentario)
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
    public void CrearPaciente(string nombre, string apellidos, string dni, string fechaNacimiento, string comentario)
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
    }*/
    public void CrearPaciente(string nombre, string apellidos, string dni, DateTime fechaNacimiento, int sesiones, DateTime? ultimaSesion, DateTime? proximaSesion, string comentario)
    {
        string query = "INSERT INTO Pacientes (nombre, apellidos, dni, fecha_nacimiento, sesiones, ultima_sesion, proxima_sesion, comentario) VALUES (@nombre, @apellidos, @dni, @fechaNacimiento, @sesiones, @ultimaSesion, @proximaSesion, @comentario)";

        List<MySqlParameter> parameters = new List<MySqlParameter>
    {
        new MySqlParameter("@nombre", nombre),
        new MySqlParameter("@apellidos", apellidos),
        new MySqlParameter("@dni", dni),
        new MySqlParameter("@fechaNacimiento", fechaNacimiento),
        new MySqlParameter("@sesiones", sesiones),
        new MySqlParameter("@comentario", comentario)
    };

        // Manejo de valores nulos para las fechas de sesión
        parameters.Add(ultimaSesion.HasValue ? new MySqlParameter("@ultimaSesion", ultimaSesion.Value) : new MySqlParameter("@ultimaSesion", DBNull.Value));
        parameters.Add(proximaSesion.HasValue ? new MySqlParameter("@proximaSesion", proximaSesion.Value) : new MySqlParameter("@proximaSesion", DBNull.Value));

        ExecuteNonQuery(query, parameters.ToArray());
    }


    public DataTable LeerPacientes()
    {
        string query = @"
        SELECT 
            paciente_id, 
            nombre, 
            apellidos, 
            dni, 
            fecha_nacimiento, 
            sesiones, 
            ultima_sesion, 
            proxima_sesion, 
            comentario 
        FROM Pacientes";
        return ExecuteQuery(query);
    }


    /* public void ActualizarPaciente(int pacienteId, string nombre, string apellidos, string dni, DateTime fechaNacimiento, string comentario)
     {
         string query = "UPDATE Pacientes SET nombre = @nombre, apellidos = @apellidos, dni = @dni, fecha_nacimiento = @fechaNacimiento, comentario = @comentario WHERE paciente_id = @pacienteId";
         ExecuteNonQuery(query, new MySqlParameter[]
         {
         new MySqlParameter("@pacienteId", pacienteId),
         new MySqlParameter("@nombre", nombre),
         new MySqlParameter("@apellidos", apellidos),
         new MySqlParameter("@dni", dni),
         new MySqlParameter("@fechaNacimiento", fechaNacimiento),
         new MySqlParameter("@comentario", comentario)
         });
     }*/
    public void ActualizarPaciente(int pacienteId, string nombre, string apellidos, string dni, DateTime fechaNacimiento, int sesiones, DateTime? ultimaSesion, DateTime? proximaSesion, string comentario)
    {
        string query = "UPDATE Pacientes SET nombre = @nombre, apellidos = @apellidos, dni = @dni, fecha_nacimiento = @fechaNacimiento, sesiones = @sesiones, ultima_sesion = @ultimaSesion, proxima_sesion = @proximaSesion, comentario = @comentario WHERE paciente_id = @pacienteId";

        List<MySqlParameter> parameters = new List<MySqlParameter>
    {
        new MySqlParameter("@pacienteId", pacienteId),
        new MySqlParameter("@nombre", nombre),
        new MySqlParameter("@apellidos", apellidos),
        new MySqlParameter("@dni", dni),
        new MySqlParameter("@fechaNacimiento", fechaNacimiento),
        new MySqlParameter("@sesiones", sesiones),
        new MySqlParameter("@comentario", comentario),
        new MySqlParameter("@ultimaSesion", (object)ultimaSesion ?? DBNull.Value),
        new MySqlParameter("@proximaSesion", (object)proximaSesion ?? DBNull.Value)
    };

        ExecuteNonQuery(query, parameters.ToArray());
    }

    public void EliminarPaciente(int pacienteId)
    {
        string query = "DELETE FROM Pacientes WHERE paciente_id = @pacienteId";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId)
        });
    }



    // Métodos CRUD para UsuariosPrograma
    public void CrearUsuario(string username, string password)
    {
        string query = "INSERT INTO UsuariosPrograma (username, password) VALUES (@username, @password)";
        ExecuteNonQuery(query, new MySqlParameter[] {
            new MySqlParameter("@username", username),
            new MySqlParameter("@password", password)
        });
    }

    public DataTable LeerUsuario(string usuario)
    {
        string query = "SELECT username FROM UsuariosPrograma WHERE username = @usuario";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@usuario", usuario)
        };
        return ExecuteQuery(query, parameters);
    }

    public DataTable LeerPasswordDeUsuario(string username)
    {
        string query = "SELECT password FROM UsuariosPrograma WHERE username = @username";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@username", username)
        };
        return ExecuteQuery(query, parameters);
    }


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


    //METODOS DE SESIONES

    public void CrearSesion(int pacienteId, DateTime fechaSesion, string comentario, int anxietyScore)
    {
        string query = @"
        INSERT INTO Sesion (paciente_id, fecha_sesion, comentario, anxiety_score) 
        VALUES (@pacienteId, @fechaSesion, @comentario, @anxietyScore)";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId),
        new MySqlParameter("@fechaSesion", fechaSesion),
        new MySqlParameter("@comentario", comentario),
        new MySqlParameter("@anxietyScore", anxietyScore)
        };

        ExecuteNonQuery(query, parameters);
    }
    public DataTable LeerSesionPorId(int sesionId)
    {
        string query = @"
    SELECT 
        paciente_id, 
        fecha_sesion, 
        comentario, 
        anxiety_score 
    FROM Sesion 
    WHERE sesion_id = @sesionId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@sesionId", sesionId)
        };

        return ExecuteQuery(query, parameters);
    }


    public DataTable LeerSesionesPorPacienteId(int pacienteId)
    {
        string query = @"
        SELECT sesion_id, fecha_sesion, comentario, anxiety_score
        FROM Sesion
        WHERE paciente_id = @pacienteId
        ORDER BY fecha_sesion DESC"; // Ordena las sesiones por fecha

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId)
        };

        return ExecuteQuery(query, parameters);
    }

    public void ActualizarSesion(int sesionId, DateTime fechaSesion, string comentario, int anxietyScore)
    {
        string query = @"
        UPDATE Sesion
        SET fecha_sesion = @fechaSesion, comentario = @comentario, anxiety_score = @anxietyScore
        WHERE sesion_id = @sesionId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@sesionId", sesionId),
        new MySqlParameter("@fechaSesion", fechaSesion),
        new MySqlParameter("@comentario", comentario),
        new MySqlParameter("@anxietyScore", anxietyScore)
        };

        ExecuteNonQuery(query, parameters);
    }


    public void EliminarSesion(int sesionId)
    {
        string query = "DELETE FROM Sesion WHERE sesion_id = @sesionId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@sesionId", sesionId)
        };

        ExecuteNonQuery(query, parameters);
    }

    //METODO PARA OBTENER DATOS PARA EL CHART
    public List<Tuple<DateTime, int>> ObtenerDatosSesionesPorPaciente(int pacienteId)
    {
        List<Tuple<DateTime, int>> datosSesiones = new List<Tuple<DateTime, int>>();

        string query = @"
    SELECT fecha_sesion, anxiety_score
    FROM Sesion
    WHERE paciente_id = @pacienteId
    ORDER BY fecha_sesion ASC"; // Asegúrate de ordenar por fecha para que el gráfico muestre una línea de tiempo coherente

        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@pacienteId", pacienteId)
        };

        DataTable dataTable = ExecuteQuery(query, parameters);

        foreach (DataRow row in dataTable.Rows)
        {
            DateTime fechaSesion = Convert.ToDateTime(row["fecha_sesion"]);
            int anxietyScore = Convert.ToInt32(row["anxiety_score"]);
            datosSesiones.Add(Tuple.Create(fechaSesion, anxietyScore));
        }

        return datosSesiones;
    }





    //VIDEOS
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

    public DataTable ObtenerVideosPorCategoria(string categoria)
    {
        string query = "SELECT * FROM Videos WHERE categoria = @categoria";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
        new MySqlParameter("@categoria", categoria)
        };

        return ExecuteQuery(query, parameters);
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
