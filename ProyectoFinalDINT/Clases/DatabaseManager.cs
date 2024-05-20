using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

/// <summary>
/// Maneja las operaciones de base de datos para la aplicación, incluyendo conexiones y ejecución de consultas.
/// </summary>
public class DatabaseManager
{
    private MySqlConnection connection;
    private MySqlConnectionStringBuilder builder;

    /// <summary>
    /// Inicializa una nueva instancia de DatabaseManager con parámetros específicos para la conexión.
    /// </summary>
    /// <param name="server">El servidor de la base de datos.</param>
    /// <param name="database">El nombre de la base de datos.</param>
    /// <param name="userId">El ID de usuario para la conexión.</param>
    /// <param name="password">La contraseña para la conexión.</param>
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

    /// <summary>
    /// Inicializa una nueva instancia de DatabaseManager con valores predeterminados.
    /// </summary>
    public DatabaseManager()
    {
        builder = new MySqlConnectionStringBuilder();
        builder.Server = "localhost";
        builder.UserID = "root";
        builder.Password = "";
        builder.Database = "mindfieldvr";
        connection = new MySqlConnection(builder.ToString());
    }

    /// <summary>
    /// Filtra y devuelve pacientes sin sesiones registradas.
    /// </summary>
    /// <returns>DataTable con los pacientes filtrados.</returns>
    public DataTable FiltrarPacientesSinSesiones()
    {
        string query = @"
        SELECT * 
        FROM Pacientes 
        WHERE paciente_id NOT IN 
            (SELECT DISTINCT paciente_id FROM Sesion)";
        return ExecuteQuery(query);
    }

    /// <summary>
    /// Filtra y devuelve pacientes con sesiones programadas para mañana.
    /// </summary>
    /// <returns>DataTable con los pacientes filtrados.</returns>
    public DataTable FiltrarPacientesConSesionManana()
    {
        DateTime manana = DateTime.Now.AddDays(1);
        string formattedDate = manana.ToString("yyyy-MM-dd");

        string query = $@"
        SELECT * 
        FROM Pacientes 
        WHERE paciente_id IN 
            (SELECT DISTINCT paciente_id 
             FROM Sesion 
             WHERE proxima_sesion >= '{formattedDate}' 
             AND proxima_sesion < DATE_ADD('{formattedDate}', INTERVAL 1 DAY))";

        return ExecuteQuery(query);
    }

    /// <summary>
    /// Filtra y devuelve pacientes con sesiones programadas para la próxima semana.
    /// </summary>
    /// <returns>DataTable con los pacientes filtrados.</returns>
    public DataTable FiltrarPacientesConSesionProximaSemana()
    {
        DateTime inicioSemana = DateTime.Now.AddDays(1);
        DateTime finSemana = DateTime.Now.AddDays(7);
        string formattedInicioSemana = inicioSemana.ToString("yyyy-MM-dd");
        string formattedFinSemana = finSemana.ToString("yyyy-MM-dd");

        string query = $@"
        SELECT * 
        FROM Pacientes 
        WHERE paciente_id IN 
            (SELECT DISTINCT paciente_id 
             FROM Sesion 
             WHERE proxima_sesion >= '{formattedInicioSemana}' 
             AND proxima_sesion < DATE_ADD('{formattedFinSemana}', INTERVAL 1 DAY))";

        return ExecuteQuery(query);
    }

    /// <summary>
    /// Establece una conexión con la base de datos.
    /// </summary>
    public Boolean Connect()
    {
        try
        {
            connection.Open();
            Console.WriteLine("Conexión a la base de datos establecida.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
            MessageBox.Show("Error en la base de datos!!");
            throw new Exception("Error");
            return false;
        }
    }

    /// <summary>
    /// Cierra la conexión con la base de datos si está abierta.
    /// </summary>
    public void Disconnect()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
            Console.WriteLine("Conexión a la base de datos cerrada.");
        }
    }

    /// <summary>
    /// Ejecuta una consulta no selectiva (INSERT, UPDATE, DELETE).
    /// </summary>
    /// <param name="query">La consulta SQL a ejecutar.</param>
    /// <param name="parameters">Los parámetros para la consulta SQL.</param>
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

    /// <summary>
    /// Ejecuta una consulta selectiva y devuelve los resultados en un DataTable.
    /// </summary>
    /// <param name="query">La consulta SQL a ejecutar.</param>
    /// <param name="parameters">Los parámetros para la consulta SQL.</param>
    /// <returns>DataTable con los resultados de la consulta.</returns>
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

    /// <summary>
    /// Selecciona el primer resultado de un DataTable.
    /// </summary>
    /// <param name="dataTable">El DataTable del cual obtener el primer resultado.</param>
    /// <returns>El primer resultado como string, o null si el DataTable está vacío.</returns>
    public string SeleccionarPrimerResultado(DataTable dataTable)
    {
        if (dataTable.Rows.Count > 0)
        {
            return dataTable.Rows[0][0].ToString();
        }

        return null;
    }

    /// <summary>
    /// Lee y devuelve la información de un paciente por su ID.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente a leer.</param>
    /// <returns>DataTable con la información del paciente.</returns>
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

    /// <summary>
    /// Crea un nuevo paciente en la base de datos.
    /// </summary>
    /// <param name="nombre">El nombre del paciente.</param>
    /// <param name="apellidos">Los apellidos del paciente.</param>
    /// <param name="dni">El DNI del paciente.</param>
    /// <param name="fechaNacimiento">La fecha de nacimiento del paciente.</param>
    /// <param name="sesiones">El número de sesiones del paciente.</param>
    /// <param name="ultimaSesion">La fecha de la última sesión del paciente.</param>
    /// <param name="proximaSesion">La fecha de la próxima sesión del paciente.</param>
    /// <param name="comentario">Un comentario sobre el paciente.</param>
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

        parameters.Add(ultimaSesion.HasValue ? new MySqlParameter("@ultimaSesion", ultimaSesion.Value) : new MySqlParameter("@ultimaSesion", DBNull.Value));
        parameters.Add(proximaSesion.HasValue ? new MySqlParameter("@proximaSesion", proximaSesion.Value) : new MySqlParameter("@proximaSesion", DBNull.Value));

        ExecuteNonQuery(query, parameters.ToArray());
    }

    /// <summary>
    /// Lee y devuelve todos los pacientes registrados en la base de datos.
    /// </summary>
    /// <returns>DataTable con la información de todos los pacientes.</returns>
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

    /// <summary>
    /// Actualiza la información de un paciente en la base de datos.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente a actualizar.</param>
    /// <param name="nombre">El nuevo nombre del paciente.</param>
    /// <param name="apellidos">Los nuevos apellidos del paciente.</param>
    /// <param name="dni">El nuevo DNI del paciente.</param>
    /// <param name="fechaNacimiento">La nueva fecha de nacimiento del paciente.</param>
    /// <param name="ultimaSesion">La nueva fecha de la última sesión del paciente.</param>
    /// <param name="proximaSesion">La nueva fecha de la próxima sesión del paciente.</param>
    /// <param name="comentario">Un nuevo comentario sobre el paciente.</param>
    public void ActualizarPaciente(int pacienteId, string nombre, string apellidos, string dni, DateTime fechaNacimiento, DateTime? ultimaSesion, DateTime? proximaSesion, string comentario)
    {
        string query = "UPDATE Pacientes SET nombre = @nombre, apellidos = @apellidos, dni = @dni, fecha_nacimiento = @fechaNacimiento, ultima_sesion = @ultimaSesion, proxima_sesion = @proximaSesion, comentario = @comentario WHERE paciente_id = @pacienteId";

        List<MySqlParameter> parameters = new List<MySqlParameter>
        {
            new MySqlParameter("@pacienteId", pacienteId),
            new MySqlParameter("@nombre", nombre),
            new MySqlParameter("@apellidos", apellidos),
            new MySqlParameter("@dni", dni),
            new MySqlParameter("@fechaNacimiento", fechaNacimiento),
            new MySqlParameter("@comentario", comentario),
            new MySqlParameter("@ultimaSesion", (object)ultimaSesion ?? DBNull.Value),
            new MySqlParameter("@proximaSesion", (object)proximaSesion ?? DBNull.Value)
        };

        ExecuteNonQuery(query, parameters.ToArray());
    }

    /// <summary>
    /// Elimina un paciente de la base de datos por su ID.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente a eliminar.</param>
    public void EliminarPaciente(int pacienteId)
    {
        string query = "DELETE FROM Pacientes WHERE paciente_id = @pacienteId";
        ExecuteNonQuery(query, new MySqlParameter[]
        {
            new MySqlParameter("@pacienteId", pacienteId)
        });
    }

    /// <summary>
    /// Crea un nuevo usuario en la base de datos.
    /// </summary>
    /// <param name="username">El nombre de usuario.</param>
    /// <param name="password">La contraseña del usuario.</param>
    public void CrearUsuario(string username, string password)
    {
        string query = "INSERT INTO UsuariosPrograma (username, password) VALUES (@username, @password)";
        ExecuteNonQuery(query, new MySqlParameter[] {
            new MySqlParameter("@username", username),
            new MySqlParameter("@password", password)
        });
    }

    /// <summary>
    /// Lee y devuelve la información de un usuario por su nombre de usuario.
    /// </summary>
    /// <param name="usuario">El nombre de usuario a buscar.</param>
    /// <returns>DataTable con la información del usuario.</returns>
    public DataTable LeerUsuario(string usuario)
    {
        string query = "SELECT username FROM UsuariosPrograma WHERE username = @usuario";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@usuario", usuario)
        };
        return ExecuteQuery(query, parameters);
    }

    /// <summary>
    /// Lee y devuelve la contraseña de un usuario por su nombre de usuario.
    /// </summary>
    /// <param name="username">El nombre de usuario cuya contraseña se busca.</param>
    /// <returns>DataTable con la contraseña del usuario.</returns>
    public DataTable LeerPasswordDeUsuario(string username)
    {
        string query = "SELECT password FROM UsuariosPrograma WHERE username = @username";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@username", username)
        };
        return ExecuteQuery(query, parameters);
    }

    /// <summary>
    /// Crea una nueva sesión para un paciente en la base de datos.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente para la sesión.</param>
    /// <param name="fechaSesion">La fecha de la sesión.</param>
    /// <param name="comentario">Un comentario sobre la sesión.</param>
    /// <param name="anxietyScore">La puntuación de ansiedad de la sesión.</param>
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
        string queryUpdate = @"
        UPDATE Pacientes
        SET sesiones = sesiones + 1
        WHERE paciente_id = @pacienteId";

        MySqlParameter[] parametersUpdate = new MySqlParameter[]
        {
            new MySqlParameter("@pacienteId", pacienteId)
        };

        ExecuteNonQuery(queryUpdate, parametersUpdate);
    }

    /// <summary>
    /// Lee y devuelve la información de una sesión por su ID.
    /// </summary>
    /// <param name="sesionId">El ID de la sesión a leer.</param>
    /// <returns>DataTable con la información de la sesión.</returns>
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

    /// <summary>
    /// Lee y devuelve todas las sesiones de un paciente por su ID.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente cuyas sesiones se quieren leer.</param>
    /// <returns>DataTable con las sesiones del paciente.</returns>
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

    /// <summary>
    /// Actualiza la fecha de la última sesión de un paciente en la base de datos.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente a actualizar.</param>
    /// <param name="fechaUltimaSesion">La nueva fecha de la última sesión.</param>
    public void ActualizarUltimaSesion(int pacienteId, DateTime fechaUltimaSesion)
    {
        string query = @"
        UPDATE Pacientes 
        SET ultima_sesion = @fechaUltimaSesion
        WHERE paciente_id = @pacienteId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@pacienteId", pacienteId),
            new MySqlParameter("@fechaUltimaSesion", fechaUltimaSesion)
        };

        ExecuteNonQuery(query, parameters);
    }

    /// <summary>
    /// Elimina una sesión de la base de datos por su ID.
    /// </summary>
    /// <param name="sesionId">El ID de la sesión a eliminar.</param>
    public void EliminarSesion(int sesionId)
    {
        string query = "DELETE FROM Sesion WHERE sesion_id = @sesionId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@sesionId", sesionId)
        };
        Console.WriteLine("Sesion eliminada");

        ExecuteNonQuery(query, parameters);
    }

    /// <summary>
    /// Actualiza la fecha de la próxima cita de un paciente en la base de datos.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente a actualizar.</param>
    /// <param name="proximaCita">La nueva fecha de la próxima cita.</param>
    public void ActualizarProximaCita(int pacienteId, DateTime proximaCita)
    {
        string query = @"
        UPDATE Pacientes
        SET proxima_sesion = @proximaCita
        WHERE paciente_id = @pacienteId";

        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@pacienteId", pacienteId),
            new MySqlParameter("@proximaCita", proximaCita)
        };

        ExecuteNonQuery(query, parameters);
    }

    /// <summary>
    /// Obtiene y devuelve los datos de sesiones para un paciente, útil para generar gráficos.
    /// </summary>
    /// <param name="pacienteId">El ID del paciente cuyos datos de sesiones se quieren obtener.</param>
    /// <returns>Lista de tuplas con la fecha de la sesión y la puntuación de ansiedad.</returns>
    public List<Tuple<DateTime, int>> ObtenerDatosSesionesPorPaciente(int pacienteId)
    {
        List<Tuple<DateTime, int>> datosSesiones = new List<Tuple<DateTime, int>>();

        string query = @"
        SELECT fecha_sesion, anxiety_score
        FROM Sesion
        WHERE paciente_id = @pacienteId
        ORDER BY fecha_sesion ASC";

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

    /// <summary>
    /// Obtiene y devuelve los videos de una categoría específica.
    /// </summary>
    /// <param name="categoria">La categoría de los videos a obtener.</param>
    /// <returns>DataTable con los videos de la categoría especificada.</returns>
    public DataTable ObtenerVideosPorCategoria(string categoria)
    {
        string query = "SELECT * FROM Videos WHERE categoria = @categoria";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@categoria", categoria)
        };

        return ExecuteQuery(query, parameters);
    }
}
