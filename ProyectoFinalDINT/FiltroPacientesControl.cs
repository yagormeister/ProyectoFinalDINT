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
    public partial class FiltroPacientesControl : UserControl
    {
        public event EventHandler FilterChanged;
        public bool SinConsultaChecked => checkBox1.Checked;
        public bool ConsultaMananaChecked => checkBox2.Checked;
        public bool ConsultaProximaSemanaChecked => checkBox3.Checked;

        public FiltroPacientesControl()
        {
            InitializeComponent();
            // Asignar el mismo manejador de eventos a todos los CheckBoxes
            checkBox1.CheckedChanged += CheckBoxes_CheckedChanged;
            checkBox2.CheckedChanged += CheckBoxes_CheckedChanged;
            checkBox3.CheckedChanged += CheckBoxes_CheckedChanged;
        }
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }
        protected virtual void OnFilterChanged()
        {
            // Invoke the FilterChanged event; passing this as the sender and EventArgs.Empty since we're not sending any additional data
            FilterChanged?.Invoke(this, EventArgs.Empty);
        }


    }
}
