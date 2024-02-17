using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalDINT
{

    public partial class PatientProgressForm : Form
    {
        /// <summary>
        /// Formulario para visualizar y registrar el progreso de un paciente.
        /// </summary>
        /// <summary>
        /// Establece el ID del paciente para el formulario.
        /// </summary>
        public string PatientID { set { lbPatient_id.Text = value; } }
        /// <summary>
        /// Opcional: ID de la sesión para cargar datos existentes.
        /// </summary>
        public int? SesionID { get; set; } // Añade esta línea

        /// <summary>
        /// Constructor por defecto que inicializa el formulario y sus componentes.
        /// </summary>
        public PatientProgressForm()
        {
            // Establece el estilo de borde del formulario para evitar el redimensionamiento
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Deshabilita el botón de maximizar
            this.MaximizeBox = false;
            InitializeComponent();
            // Initialize event handlers for the ComboBoxes
           comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
           comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            SesionID = SesionID;
            if (SesionID.HasValue)
            {
                CargarDatosSesion(SesionID.Value);
                EstablecerModoSoloLectura();
            }
            lbScore.Hide();

        }
        //CONSTRUCTOR EXTRA
        /// <summary>
        /// Constructor que acepta un ID de sesión para cargar datos de una sesión existente.
        /// </summary>
        /// <param name="sesionId">El ID de la sesión a cargar.</param>
        public PatientProgressForm(int sesionId)
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            CargarDatosSesion(sesionId);
            EstablecerModoSoloLectura();
        }
        /// <summary>
        /// Carga los datos de la sesión especificada por ID.
        /// </summary>
        /// <param name="sesionId">ID de la sesión a cargar.</param>
        private void CargarDatosSesion(int sesionId)
        {
            DatabaseManager db = new DatabaseManager();
            db.Connect();

            DataTable sesionData = db.LeerSesionPorId(sesionId);

            if (sesionData.Rows.Count > 0)
            {
                DataRow row = sesionData.Rows[0];
                tbComment.Text = row["comentario"].ToString();
                tbComment.Text += "\n---------------------------------------------------------\nAnxiety Score: ";
                tbComment.Text += row["anxiety_score"].ToString();
                lbScore.Text = row["anxiety_score"].ToString();
            }

            db.Disconnect();
        }
        /// <summary>
        /// Establece el formulario en modo de solo lectura, deshabilitando la edición.
        /// </summary>
        private void EstablecerModoSoloLectura()
        {
            tbComment.ReadOnly = true; // Hace que tbComment sea de solo lectura
             btSave.Enabled = false;
        }


        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int patientId = int.Parse(lbPatient_id.Text);
            int anxietyScore = CalculateAnxietyScore();
            DatabaseManager db = new DatabaseManager();
            db.Connect();
            db.CrearSesion(patientId, DateTime.Today, tbComment.Text, anxietyScore);
            db.ActualizarUltimaSesion(patientId, DateTime.Today);
            db.Disconnect();
            MessageBox.Show("Nota clinica guardada!");
            this.Close();
        }
        /// <summary>
        /// Calcula el puntaje de ansiedad basado en las selecciones de los ComboBox.
        /// </summary>
        /// <returns>Puntaje de ansiedad calculado.</returns>
        private int CalculateAnxietyScore()
        {
            int score = 0;
            lbScore.Hide();
            
            switch (comboBox1.Text)
            {
                case "0 - Ninguna": score += 0;
                    break;
                case "2 - Baja": score += 2;
                    break;                
                case "5 - Media": score +=5;
                    break;
                case "10 - Alta":
                    score += 10;
                    break;
            }
            lbScore.Text += score;

            switch (comboBox2.Text)
            {
                case "0 - Ninguna":
                    score += 0;
                    break;
                case "1 - Sudor en la frente":
                    score += 1;
                    break;
                case "3 - Sudor en las palmas de la mano":
                    score += 3;
                    break;
                case "4 - Sudorarcion significativa":
                    score += 4;
                    break;
                case "10 - Sudoración profusa":
                    score += 10;
                    break;
            }
            lbScore.Text += score;

            switch (comboBox3.Text)
            {
                case "0 - 60-80 bmp":
                    score += 0;
                    break;
                case "3 - 81-90 bpm":
                    score += 3;
                    break;
                case "5 - 91 - 120 bpm":
                    score += 5;
                    break;
                case "10 - >121 bpm":
                    score += 10;
                    break;
            }
            lbScore.Text += score;

            return score;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int totalScore = 0;

            // Calculate score from ansiedad
            if (comboBox1.SelectedItem is string anxietySelection && int.TryParse(anxietySelection.Split('-').Last().Trim(), out int anxietyScore))
            {
                totalScore += anxietyScore;
            }

            // Calculate score from sudoracion
            if (comboBox2.SelectedItem is string sweatSelection && int.TryParse(sweatSelection.Split('-').Last().Trim(), out int sweatScore))
            {
                totalScore += sweatScore;
            }

            // Calculate score from frecuencia cardiaca
            if (comboBox3.SelectedItem is string heartRateSelection && int.TryParse(heartRateSelection.Split('-').Last().Trim(), out int heartRateScore))
            {
                totalScore += heartRateScore;
            }

            // Display the total score
            lbScore.Text = $"Total Anxiety Score: {totalScore}";
        }
    }
}
