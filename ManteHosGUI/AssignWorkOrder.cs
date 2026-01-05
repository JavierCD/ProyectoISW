using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public class AssignWorkOrder : Form
    {
        private readonly IManteHosService service;

        private Panel panelFormulario;
        private Label lblTitulo;
        private Button btnRegresar;
        private Button btnAsignar;

        private DataGridView dgvIncidentes;
        private List<Incident> incidentes;
        private Incident inc;

        public AssignWorkOrder(IManteHosService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));

            this.BackColor = ColorTranslator.FromHtml("#192959");
            this.WindowState = FormWindowState.Maximized;

            CrearPanelFormulario();
            ConfigurarBotonAsignar();

            this.Resize += (s, e) => CentrarPanel();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadIncidentes();
        }

        private void LoadIncidentes()
        {
            incidentes = service.getAllAcceptedIncidents()?.ToList()
                         ?? new List<Incident>();

            dgvIncidentes.DataSource = incidentes
                .Select(i => new
                {
                    Id = i.Id,
                    Fecha = i.ReportDate.ToString("dd/MM/yyyy"),
                    Empleado = i.Reporter.FullName,
                    Prioridad = i.Priority.ToString(),
                    Estado = i.Status.ToString()
                })
                .ToList();

            dgvIncidentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidentes.RowHeadersVisible = false;
            dgvIncidentes.ReadOnly = true;
            dgvIncidentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvIncidentes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una incidencia");
                return;
            }

            int idIncidente =
                (int)dgvIncidentes.CurrentRow.Cells["Id"].Value;

            inc = incidentes.FirstOrDefault(i => i.Id == idIncidente);

            try
            {
                service.asignarIncidente(inc);

                if (inc.WorkOrder == null)
                {
                    var res = MessageBox.Show(
                        "¿Desea crear una orden de trabajo?",
                        "Crear orden de trabajo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (res == DialogResult.Yes)
                        service.createWorkOrder(inc);
                    else
                        return;
                }

                InfoInc info = new InfoInc(service);
                info.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= UI =================

        private void CrearPanelFormulario()
        {
            panelFormulario = new Panel
            {
                Size = new Size(900, 600),
                BackColor = Color.White
            };

            this.Controls.Add(panelFormulario);
            panelFormulario.BringToFront();

            // ---------- BOTÓN REGRESAR ----------
            btnRegresar = new Button
            {
                Size = new Size(60, 60),
                Location = new Point(15, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.BackgroundImage = CargarImagen("iconoRegresar.png");
            btnRegresar.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegresar.Click += (s, e) => this.Close();

            this.Controls.Add(btnRegresar);
            btnRegresar.BringToFront();

            // ---------- TÍTULO ----------
            lblTitulo = new Label
            {
                Text = "ASIGNAR ORDEN DE TRABAJO",
                Font = new Font("Lucida Sans Unicode", 24, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(200, 40)
            };

            panelFormulario.Controls.Add(lblTitulo);

            // ---------- TABLA INCIDENTES ----------
            dgvIncidentes = new DataGridView
            {
                Location = new Point(40, 120),
                Size = new Size(820, 300),
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            panelFormulario.Controls.Add(dgvIncidentes);

            // ---------- BOTÓN ASIGNAR ----------
            btnAsignar = new Button
            {
                Location = new Point(
                    panelFormulario.Width / 2 - 60,
                    460),
                Size = new Size(120, 60)
            };

            btnAsignar.Click += btnAsignar_Click;
            panelFormulario.Controls.Add(btnAsignar);

            CentrarPanel();
        }

        private void CentrarPanel()
        {
            panelFormulario.Left =
                (this.ClientSize.Width - panelFormulario.Width) / 2;
            panelFormulario.Top =
                (this.ClientSize.Height - panelFormulario.Height) / 2 - 30;
        }

        private void ConfigurarBotonAsignar()
        {
            btnAsignar.Text = "";
            btnAsignar.FlatStyle = FlatStyle.Flat;
            btnAsignar.FlatAppearance.BorderSize = 0;
            btnAsignar.BackColor = Color.Transparent;
            btnAsignar.Cursor = Cursors.Hand;
            btnAsignar.BackgroundImage =
                CargarImagen("iconoCerrarOrden.png");
            btnAsignar.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private Image CargarImagen(string nombreArchivo)
        {
            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                nombreArchivo);

            return System.IO.File.Exists(path)
                ? Image.FromFile(path)
                : null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AssignWorkOrder
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "AssignWorkOrder";
            this.Load += new System.EventHandler(this.AssignWorkOrder_Load);
            this.ResumeLayout(false);

        }

        private void AssignWorkOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
