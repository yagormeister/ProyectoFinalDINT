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
            btAtras.Visible = false; // Asegúrate de inicializar el botón Atrás como no visible
            btAtras.Click += btAtras_Click; // Agrega el manejador de eventos al botón Atrás
            ActualizarChart();
            // Agregar las columnas de botones al final de dgvSessions
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn();
            editButtonColumn.HeaderText = "Editar";
            editButtonColumn.Text = "Editar";
            editButtonColumn.UseColumnTextForButtonValue = true;
            dgvSessions.Columns.Add(editButtonColumn);

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn();
            deleteButtonColumn.HeaderText = "Eliminar";
            deleteButtonColumn.Text = "Eliminar";
            deleteButtonColumn.UseColumnTextForButtonValue = true;
            dgvSessions.Columns.Add(deleteButtonColumn);
            ConfigurarGrafica();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            int id_paciente = int.Parse(lbPatientNumberRecovered.Text);
            ActualizarChart();
            CargarDatosEnProgressChart(id_paciente);

        }


        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                string categoriaSeleccionada = pictureBox.Tag.ToString();
                MostrarVideosDeCategoria(categoriaSeleccionada);
            }
        }

        private void MostrarVideosDeCategoria(string categoria)
        {
            flowLayoutPanel1.Controls.Clear();
            btAtras.Visible = true; // Hace visible el botón Atrás

            DataTable videos = db.ObtenerVideosPorCategoria(categoria);

            foreach (DataRow video in videos.Rows)
            {
                Panel videoPanel = new Panel
                {
                    Width = flowLayoutPanel1.Width - 20,
                    Height = 100,
                    Padding = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = video["titulo"].ToString() // Guarda el título del video para usarlo más tarde
                };
                videoPanel.Click += PictureBoxVideo_Click;
                videoPanel.MouseEnter += (sender, e) => { videoPanel.BackColor = Color.LightGray; };
                videoPanel.MouseLeave += (sender, e) => { videoPanel.BackColor = Color.Transparent; };

                Label titleLabel = new Label
                {
                    Text = video["titulo"].ToString(),
                    AutoSize = true,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Top // Asegura que el título esté en la parte superior del panel
                };
                videoPanel.Controls.Add(titleLabel);

                // Asegúrate de que los campos "duracion" y "descripcion" existen en tu DataTable
                Label durationLabel = new Label
                {
                    Text = $"Duración: {video["duracion"].ToString()}",
                    AutoSize = true,
                    Font = new Font("Arial", 8),
                    Dock = DockStyle.Top // Posiciona la duración debajo del título
                };
                videoPanel.Controls.Add(durationLabel);

                Label descriptionLabel = new Label
                {
                    Text = video["descripcion"].ToString(),
                    AutoSize = true,
                    Font = new Font("Arial", 8),
                    Dock = DockStyle.Fill // Llena el espacio restante con la descripción
                };
                videoPanel.Controls.Add(descriptionLabel);

                flowLayoutPanel1.Controls.Add(videoPanel);
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
                        MessageBox.Show("Video enviado a las gafas VR");
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
            if (e.RowIndex >= 0)
            {
                // Manejar el evento de doble clic en la celda aquí
                // Puedes obtener el ID de la sesión seleccionada usando:
                var sesionId = Convert.ToInt32(dgvSessions.Rows[e.RowIndex].Cells["sesion_id"].Value);
                // Luego puedes realizar las acciones necesarias al hacer doble clic en la sesión
                // Por ejemplo, abrir un formulario de detalles pasando el sesionId.
                PatientProgressForm p = new PatientProgressForm(sesionId);
                p.PatientID = lbPatientNumberRecovered.Text;
                p.ShowDialog();
                ActualizarChart();
            }
        }
        private void dgvSessions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvSessions.Columns["Editar"].Index)
            {
                // Manejar el evento de clic en el botón "Editar" aquí
                // Puedes obtener el ID de la sesión seleccionada usando:
                var sesionId = Convert.ToInt32(dgvSessions.Rows[e.RowIndex].Cells["sesion_id"].Value);
                // Luego puedes realizar las acciones necesarias para editar la sesión
                // Por ejemplo, abrir un formulario de edición pasando el sesionId.
                PatientProgressForm p = new PatientProgressForm(sesionId);
                p.PatientID = lbPatientNumberRecovered.Text;
                p.ShowDialog();
                ActualizarChart();
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dgvSessions.Columns["Eliminar"].Index)
            {
                // Manejar el evento de clic en el botón "Eliminar" aquí
                // Puedes obtener el ID de la sesión seleccionada usando:
                var sesionId = Convert.ToInt32(dgvSessions.Rows[e.RowIndex].Cells["sesion_id"].Value);
                // Luego puedes realizar las acciones necesarias para eliminar la sesión
                // Por ejemplo, mostrar un cuadro de diálogo de confirmación y eliminar la sesión si es confirmado.
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar esta sesión?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Agrega el código para eliminar la sesión
                    // Por ejemplo, db.EliminarSesion(sesionId);
                    ActualizarChart(); // Actualiza el gráfico después de eliminar la sesión
                }
            }
        }



        //METODO PARA OBTENER LOS DATOS PARA LA TABLA
        private void CargarDatosEnProgressChart(int pacienteId)
        {
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
                lbDOBRecovered.Text = Convert.ToDateTime(row["fecha_nacimiento"]).ToString("dd/MM/yyyy"); // Formatear la fecha según sea necesario
                                                                                                          // Continúa para los demás Labels que necesites poblar
            }
            else
            {
                MessageBox.Show("Error al leer el paciente!");
            }
            dgvSessions.DataSource = sesiones;

        }

        private void btAtras_Click(object sender, EventArgs e)
        {
            CargarCategorias(); // Función que vuelve a cargar las categorías originales
            btAtras.Visible = false; // Oculta el botón Atrás
        }
        private void CargarCategorias()
        {
            flowLayoutPanel1.Controls.Clear();
            btAtras.Visible = false; // Asegura que el botón Atrás esté oculto cuando se muestren las categorías

            var categorias = new List<Tuple<string, Image>>()
    {
        new Tuple<string, Image>("Conducir", Properties.Resources.conducir),
        new Tuple<string, Image>("Altura", Properties.Resources.alturas),
        new Tuple<string, Image>("Hablar", Properties.Resources.hablar),
        new Tuple<string, Image>("Animales", Properties.Resources.animales),
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
                flowLayoutPanel1.Controls.Add(pictureBox);
            }
        }
        private Panel CreateVideoPanel(DataRow video)
        {
            Panel videoPanel = new Panel
            {
                Width = flowLayoutPanel1.Width - 20,
                Height = 100,
                Padding = new Padding(5),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = video["titulo"].ToString()
            };

            videoPanel.Click += PictureBoxVideo_Click;
            videoPanel.MouseEnter += (sender, e) => videoPanel.BackColor = Color.LightGray;
            videoPanel.MouseLeave += (sender, e) => videoPanel.BackColor = Color.Transparent;

            Label titleLabel = new Label { Text = video["titulo"].ToString(), AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold) };
            Label durationLabel = new Label { Text = $"Duración: {video["duracion"].ToString()}", AutoSize = true, Font = new Font("Arial", 8) };
            Label descriptionLabel = new Label { Text = video["descripcion"].ToString(), AutoSize = true, Font = new Font("Arial", 8) };

            videoPanel.Controls.Add(titleLabel);
            videoPanel.Controls.Add(durationLabel);
            videoPanel.Controls.Add(descriptionLabel);

            return videoPanel;
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            // Navigates back to the PatientsForm, which lists all patients
            this.Hide(); // Hide the current MainForm
            PatientsForm patientsForm = new PatientsForm();
            patientsForm.ShowDialog();
            this.Close(); // Close the MainForm after returning to the PatientsForm
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            // Exits to the LoginForm, the initial login screen of your application
            this.Hide(); // Hide the current MainForm
            Login loginForm = new Login();
            loginForm.ShowDialog();
            this.Close(); // Close the MainForm after the LoginForm is closed
        }
        private void ConfigurarGrafica()
        {
            progressChart.Series.Clear(); // Limpia series existentes
            var series = new Series("Anxiety Score")
            {
                ChartType = SeriesChartType.Line, // O el tipo que necesites
                XValueType = ChartValueType.DateTime // Si usas fechas en el eje X
            };
            progressChart.Series.Add(series);
        }

        private void btNuevaCita_Click(object sender, EventArgs e)
        {
            controlCitas1.Visible = true;
            controlCitas1.Enabled = true;
            var pacienteId = int.Parse(lbPatientNumberRecovered.Text); 
            //ControlCitas controlCitas = new ControlCitas();
            controlCitas1.PacienteId = pacienteId;


        }
    }
}
