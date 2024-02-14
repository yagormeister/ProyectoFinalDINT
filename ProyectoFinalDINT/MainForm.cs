using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProyectoFinalDINT
{
    public partial class MainForm : Form
    {
        DatabaseManager db = new DatabaseManager();

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {


            //carga del flowchart
            // Lista de categorías y sus imágenes
            var categorias = new List<Tuple<string, Image>>()
                {
                    new Tuple<string, Image>("Conducir", Properties.Resources.conducir),
                    new Tuple<string, Image>("Altura", Properties.Resources.alturas),
                    new Tuple<string, Image>("Hablar", Properties.Resources.hablar),
                    new Tuple<string, Image>("Annimales", Properties.Resources.animales),
                    new Tuple<string, Image>("Volar", Properties.Resources.avion),
                    new Tuple<string, Image>("Payasos", Properties.Resources.payaso),
                    // Añade más categorías según sea necesario
                };

            foreach (var categoria in categorias)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = categoria.Item2,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Width = 100,
                    Height = 100,
                    Tag = categoria.Item1 // Usamos el tag para almacenar el nombre de la categoría
                };
                pictureBox.Click += PictureBox_Click; // Evento click para cada PictureBox
                flowLayoutPanel1.Controls.Add(pictureBox); // Asume que tu FlowLayoutPanel se llama flowLayoutPanel1
            }


            int id_paciente = int.Parse(lbPatientNumberRecovered.Text);

            ActualizarChart();            

            //CARGA DEL GRAFICO

            // Configura los nombres de las series
            progressChart.Series.Clear(); // Limpia las series anteriores si las hubiera
            progressChart.Series.Add("Anxiety Score");

            // Configura el eje X
            progressChart.ChartAreas[0].AxisX.Title = "Fechas de Sesiones";
            progressChart.ChartAreas[0].AxisX.Interval = 1; // Dependiendo de la cantidad de datos, puedes ajustar el intervalo
            progressChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days; // Ajusta según tus datos
            progressChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM-yyyy"; // Formato de fecha

            // Configura el eje Y
            progressChart.ChartAreas[0].AxisY.Title = "Anxiety Score";
            progressChart.ChartAreas[0].AxisY.Minimum = 0; // Ajusta según tus datos

            CargarDatosEnProgressChart(id_paciente);

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                string categoriaSeleccionada = pictureBox.Tag.ToString(); // Recuperamos el nombre de la categoría desde el Tag
                MostrarVideosDeCategoria(categoriaSeleccionada); // Método para mostrar videos de la categoría seleccionada
            }
        }

        private void MostrarVideosDeCategoria(string categoria)
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable videos = db.ObtenerVideosPorCategoria(categoria);

            foreach (DataRow video in videos.Rows)
            {
                Panel videoPanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 20, // Adjust the width
                    Height = 100, // Adjust the height
                    Padding = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = video["titulo"].ToString() // Store the video title for later
                };
                videoPanel.Click += PictureBoxVideo_Click; // Click event for the panel

                Label titleLabel = new Label
                {
                    Text = video["titulo"].ToString(),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };
                videoPanel.Controls.Add(titleLabel);

                Label durationLabel = new Label
                {
                    Text = $"Duration: {video["duracion"].ToString()}",
                    AutoSize = true,
                    Font = new Font("Arial", 8)
                };
                videoPanel.Controls.Add(durationLabel);

                Label descriptionLabel = new Label
                {
                    Text = video["descripcion"].ToString(),
                    AutoSize = true,
                    Font = new Font("Arial", 8)
                };
                videoPanel.Controls.Add(descriptionLabel);

                flowLayoutPanel1.Controls.Add(videoPanel);
            }
        }
        private Image ObtenerMiniaturaDeVideo(string rutaMiniatura)
        {
            try
            {
                return Image.FromFile("img\\alturas.jpg");
            }
            catch
            {
                // Manejo de errores, por ejemplo, retornar una imagen predeterminada en caso de error
                return Properties.Resources.alturas; // Asegúrate de tener esta imagen en tus recursos
            }
        }

        private async void PictureBoxVideo_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                string videoTitle = panel.Tag.ToString();
                string videoPath = $"file:///storage/emulated/0/movies/{videoTitle}.MP4";

                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "powershell",
                        Arguments = $"-Command \"Start-Process 'adb' -ArgumentList 'shell am start -a android.intent.action.VIEW -d \"{videoPath}\" -t \"video/mp4\"'\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    };

                    using (Process process = new Process { StartInfo = psi })
                    {
                        process.Start();
                        process.WaitForExit();
                        // Handle output and errors if needed
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error launching video: {ex.Message}");
                }
            }
        }






        private void chart1_Click(object sender, EventArgs e)
        {
            PatientProgressForm p = new PatientProgressForm();
            p.PatientID = lbPatientNumberRecovered.Text;
            p.ShowDialog();
            ActualizarChart();

        }

        private void dgvSessions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientProgressForm p = new PatientProgressForm();
            p.PatientID = lbPatientNumberRecovered.Text;
            p.ShowDialog();
            ActualizarChart();

        }

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    // Usar /C para que cmd ejecute el comando y luego se cierre
                    Arguments = "/C \"C:\\Android\\sdk\\platform-tools\\adb\" shell am start -a android.intent.action.VIEW -d \"file:///storage/emulated/0/movies/SAM_0112.MP4\" -t \"video/mp4\"",
                    UseShellExecute = false,
                    CreateNoWindow = true, // Esto previene que se muestre la ventana de cmd
                    RedirectStandardOutput = true, // Permite leer la salida
                    RedirectStandardError = true // Permite leer los errores
                };

                Process adbProcess = new Process { StartInfo = psi };
                adbProcess.Start();

                // Opcional: Leer la salida
                string output = adbProcess.StandardOutput.ReadToEnd();
                string error = adbProcess.StandardError.ReadToEnd();

                adbProcess.WaitForExit(); // Esperar a que el comando adb finalice

                // Opcional: Mostrar la salida o manejar errores
                Console.WriteLine(output);
                if (!string.IsNullOrEmpty(error))
                {
                    Console.WriteLine("Error: " + error);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones, como errores al ejecutar el comando adb
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        //METODO PARA OBTENER LOS DATOS PARA LA TABLA
        private void CargarDatosEnProgressChart(int pacienteId)
        {
            // Asume que tienes una instancia de DatabaseManager llamada dbManager
            List<Tuple<DateTime, int>> datosSesiones = db.ObtenerDatosSesionesPorPaciente(pacienteId);

            // Configura la serie de datos
            progressChart.Series["Anxiety Score"].Points.Clear();
            foreach (var sesion in datosSesiones)
            {
                progressChart.Series["Anxiety Score"].Points.AddXY(sesion.Item1, sesion.Item2);
            }
        }

        private void ActualizarChart()
        {
            //CARGA DE LOS DATOS DEL PACIENTE SELECCIONADO

            int id_paciente = int.Parse(lbPatientNumberRecovered.Text);

            db.Connect();
            DataTable paciente = db.LeerPacientePorId(id_paciente);
            DataTable sesiones = db.LeerSesionesPorPacienteId(id_paciente);

            db.Disconnect();
            if (paciente.Rows.Count > 0)
            {
                DataRow row = paciente.Rows[0]; // Obtener la primera fila

                // Poblar los Labels
                lbNameRecovered.Text = row["nombre"].ToString();
                lbSurnameRecovered.Text = row["apellidos"].ToString();
                lbDNIRecovered.Text = row["dni"].ToString();
                lbDNIRecovered.Text = Convert.ToDateTime(row["fecha_nacimiento"]).ToString("dd/MM/yyyy"); // Formatear la fecha según sea necesario
                                                                                                          // Continúa para los demás Labels que necesites poblar
            }
            else
            {
                MessageBox.Show("Error al leer el paciente!");
            }
            dgvSessions.DataSource = sesiones;
        }

    }
}
