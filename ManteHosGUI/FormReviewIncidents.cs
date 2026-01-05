using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class FormReviewIncidents : Form
    {
        private readonly IManteHosService service;
        private readonly Head currentUser;
        private Incident selectedIncident;

        private Panel panelFormulario;
        private Label lblTitulo;
        private Panel panelAceptar;
        private Panel panelRechazar;
        private Button btnRegresar;

        public FormReviewIncidents(IManteHosService manteHosService, Head user)
        {
            InitializeComponent();
            service = manteHosService;
            currentUser = user;

            this.BackColor = ColorTranslator.FromHtml("#192959");
            this.WindowState = FormWindowState.Maximized;

            CrearPanelFormulario();
            ConfigurarBotones();

            cmbPriority.SelectedIndex = 1;
            LoadIncidents();
            LoadAreas();

            this.Resize += (s, e) => CentrarPanel();
        }

        private void CrearPanelFormulario()
        {
            panelFormulario = new Panel
            {
                Size = new Size(1200, 700),
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
                Text = "REVISIÓN DE INCIDENCIAS",
                Font = new Font("Lucida Sans Unicode", 24, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(370, 20)
            };
            panelFormulario.Controls.Add(lblTitulo);

            // ================= TABLA =================
            dgvIncidents.Location = new Point(30, 80);
            dgvIncidents.Size = new Size(700, 250);
            dgvIncidents.ReadOnly = true;
            dgvIncidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIncidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIncidents.RowHeadersVisible = false;
            panelFormulario.Controls.Add(dgvIncidents);

            // ================= ACTUALIZAR =================
            btnRefresh.Location = new Point(
                (30 + (700 / 2) - (btnRefresh.Width / 2)) + 30,
                340
            );
            panelFormulario.Controls.Add(btnRefresh);

            // ================= DETALLE INCIDENCIA =================
            gbDetails.Parent = panelFormulario;
            gbDetails.Location = new Point(35, 430);
            gbDetails.Size = new Size(700, 220);
            gbDetails.BringToFront();

            gbDetails.Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold);
            gbDetails.ForeColor = Color.Navy;

            lblIncidentInfo.Dock = DockStyle.Fill;
            lblIncidentInfo.Padding = new Padding(10);

            // ================= ACEPTAR =================
            panelAceptar = new Panel
            {
                Size = new Size(400, 250),
                Location = new Point(760, 80),
                BorderStyle = BorderStyle.FixedSingle
            };
            panelFormulario.Controls.Add(panelAceptar);

            Label lblAceptar = new Label
            {
                Text = "Aceptar incidencia",
                AutoSize = true,
                Location = new Point(10, 10),
                Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold),
                ForeColor = Color.Navy
            };
            panelAceptar.Controls.Add(lblAceptar);

            Label lblArea = new Label
            {
                Text = "Área",
                Location = new Point(20, 60),
                AutoSize = true
            };
            panelAceptar.Controls.Add(lblArea);

            cmbArea.Location = new Point(20, 80);
            cmbArea.Size = new Size(250, 25);
            panelAceptar.Controls.Add(cmbArea);

            Label lblPriority = new Label
            {
                Text = "Prioridad",
                Location = new Point(20, 140),
                AutoSize = true
            };
            panelAceptar.Controls.Add(lblPriority);

            cmbPriority.Location = new Point(20, 160);
            cmbPriority.Size = new Size(250, 25);
            panelAceptar.Controls.Add(cmbPriority);

            btnAccept.Location = new Point(
                panelAceptar.Width - 45,
                panelAceptar.Height - 45
            );
            panelAceptar.Controls.Add(btnAccept);

            // ================= RECHAZAR =================
            panelRechazar = new Panel
            {
                Size = new Size(400, 207),
                Location = new Point(760, 442),
                BorderStyle = BorderStyle.FixedSingle
            };
            panelFormulario.Controls.Add(panelRechazar);

            Label lblRechazar = new Label
            {
                Text = "Rechazar incidencia",
                AutoSize = true,
                Location = new Point(10, 10),
                Font = new Font("Lucida Sans Unicode", 12, FontStyle.Bold),
                ForeColor = Color.Navy
            };
            panelRechazar.Controls.Add(lblRechazar);

            Label lblReason = new Label
            {
                Text = "Motivo",
                Location = new Point(20, 50),
                AutoSize = true
            };
            panelRechazar.Controls.Add(lblReason);

            txtReason.Location = new Point(20, 70);
            txtReason.Size = new Size(360, 70);
            txtReason.Multiline = true;
            panelRechazar.Controls.Add(txtReason);

            btnReject.Location = new Point(
                (panelRechazar.Width - 45) - 10,
                (panelRechazar.Height - 45) - 10
            );
            panelRechazar.Controls.Add(btnReject);

            CentrarPanel();
        }

        private void CentrarPanel()
        {
            panelFormulario.Left =
                (this.ClientSize.Width - panelFormulario.Width) / 2;
            panelFormulario.Top =
                (this.ClientSize.Height - panelFormulario.Height) / 2 - 20;
        }

        private void ConfigurarBotones()
        {
            btnAccept.Size = new Size(35, 35);
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.BackColor = Color.Transparent;
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.BackgroundImage = CargarImagen("iconoCerrarOrden.png");
            btnAccept.BackgroundImageLayout = ImageLayout.Zoom;
            btnAccept.Text = "";

            btnReject.Size = new Size(50, 50);
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.BackColor = Color.Transparent;
            btnReject.Cursor = Cursors.Hand;
            btnReject.BackgroundImage = CargarImagen("iconoRechazar.png");
            btnReject.BackgroundImageLayout = ImageLayout.Zoom;
            btnReject.Text = "";

            btnRefresh.Size = new Size(40, 40);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.BackColor = Color.Transparent;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.BackgroundImage = CargarImagen("iconoActualizar.png");
            btnRefresh.BackgroundImageLayout = ImageLayout.Zoom;
            btnRefresh.Text = "";
        }

        private void LoadIncidents()
        {
            var incidents = service.getAllPendingIncidents();
            dgvIncidents.DataSource = incidents.Select(i => new
            {
                ID = i.Id,
                Departamento = i.Department,
                Descripción = i.Description,
                Fecha = i.ReportDate.ToShortDateString(),
                Estado = i.Status
            }).ToList();
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

        private void LoadAreas()
        {
            var areas = service.getAreaList();
            cmbArea.DataSource = areas;
            cmbArea.DisplayMember = "Name";
            cmbArea.ValueMember = "Id";
        }

        private void dgvIncidents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvIncidents.SelectedRows.Count > 0)
            {
                int incidentId = (int)dgvIncidents.SelectedRows[0].Cells["ID"].Value;
                selectedIncident = service.getAllPendingIncidents()
                    .FirstOrDefault(i => i.Id == incidentId);

                if (selectedIncident != null)
                {
                    lblIncidentInfo.Text =
                        $"Departamento: {selectedIncident.Department}\n\n" +
                        $"Descripción: {selectedIncident.Description}\n\n" +
                        $"Fecha: {selectedIncident.ReportDate.ToShortDateString()}\n" +
                        $"Estado: {selectedIncident.Status}";
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (selectedIncident == null)
            {
                MessageBox.Show("Seleccione una incidencia", "Error");
                return;
            }

            if (cmbArea.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un área", "Error");
                return;
            }

            try
            {
                Area selectedArea = (Area)cmbArea.SelectedItem;
                Priority priority = (Priority)Enum.Parse(typeof(Priority), cmbPriority.SelectedItem.ToString());

                service.acceptedIncident(selectedIncident, selectedArea, priority);
                MessageBox.Show("Incidencia aceptada!", "Éxito");
                LoadIncidents();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedIncident == null || string.IsNullOrWhiteSpace(txtReason.Text))
            {
                MessageBox.Show("Seleccione incidencia e ingrese razón", "Error");
                return;
            }

            service.rejectedIncident(selectedIncident, txtReason.Text);
            MessageBox.Show("Incidencia rechazada", "Éxito");
            LoadIncidents();
            txtReason.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadIncidents();
        }
    }
}
