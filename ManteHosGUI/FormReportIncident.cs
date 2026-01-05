using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class FormReportIncident : BaseForm
    {
        private readonly IManteHosService service;
        private readonly Employee currentUser;

        private Panel panelFormulario;
        private Label lblTitulo;
        private Button btnRegresar; 

        public FormReportIncident(IManteHosService manteHosService, Employee user)
        {
            InitializeComponent();

            service = manteHosService;
            currentUser = user;

            dtpDate.Value = DateTime.Now;
            this.BackColor = ColorTranslator.FromHtml("#192959");

            ConfigurarBotonSubmit();
            CrearPanelFormulario();
            this.Resize += (s, e) => CentrarPanelFormulario();
        }

        private void CrearPanelFormulario()
        {
            // ---------- PANEL ----------
            panelFormulario = new Panel
            {
                Size = new Size(800, 700),
                BackColor = Color.White
            };

            panelFormulario.Paint += (s, e) =>
            {
                e.Graphics.DrawRectangle(
                    Pens.White,
                    0, 0,
                    panelFormulario.Width - 1,
                    panelFormulario.Height - 1
                );
            };

            this.Controls.Add(panelFormulario);
            panelFormulario.BringToFront();

            // ---------- BOTÓN REGRESAR (FUERA DEL PANEL) ----------
            btnRegresar = new Button
            {
                Size = new Size(60, 60),
                Location = new Point(15, 15),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnRegresar.FlatAppearance.MouseDownBackColor = Color.Transparent;

            btnRegresar.BackgroundImage = CargarImagen("iconoRegresar.png");
            btnRegresar.BackgroundImageLayout = ImageLayout.Zoom;
            btnRegresar.Click += (s, e) => this.Close();

            this.Controls.Add(btnRegresar);
            btnRegresar.BringToFront();

            // ---------- TÍTULO ----------
            lblTitulo = new Label
            {
                Text = "REPORTAR INCIDENCIA",
                Font = new Font("Lucida Sans Unicode", 30, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Black
            };

            lblTitulo.Location = new Point(160, 80);
            panelFormulario.Controls.Add(lblTitulo);

            // ---------- CONTROLES ----------
            lblDepartment.Parent = panelFormulario;
            txtDepartment.Parent = panelFormulario;

            lblDescription.Parent = panelFormulario;
            txtDescription.Parent = panelFormulario;

            lblDate.Parent = panelFormulario;
            dtpDate.Parent = panelFormulario;

            int xLabel = 40;
            int xInput = 180;
            int y = 250;

            lblDepartment.Location = new Point(xLabel + 120, y);
            txtDepartment.Location = new Point(xInput + 160, y - 3);
            txtDepartment.Size = new Size(300, 22);

            y += 80;

            lblDescription.Location = new Point(xLabel + 120, y);
            txtDescription.Location = new Point(xInput + 160, y - 3);
            txtDescription.Size = new Size(300, 120);
            txtDescription.Multiline = true;

            y += 180;

            lblDate.Location = new Point(xLabel + 120, y);
            dtpDate.Location = new Point(xInput + 160, y - 4);
        }


        private void CentrarPanelFormulario()
        {
            panelFormulario.Left =
                (this.ClientSize.Width - panelFormulario.Width) / 2;

            panelFormulario.Top =
                (this.ClientSize.Height - panelFormulario.Height) / 2 - 40;

            BtnSubmit.Location = new Point(
                panelFormulario.Left +
                panelFormulario.Width / 2 -
                BtnSubmit.Width / 2,
                panelFormulario.Bottom + 20
            );
        }

        private void ConfigurarBotonSubmit()
        {
            BtnSubmit.Text = "";
            BtnSubmit.Size = new Size(120, 60);

            BtnSubmit.FlatStyle = FlatStyle.Flat;
            BtnSubmit.FlatAppearance.BorderSize = 0;
            BtnSubmit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSubmit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSubmit.BackColor = Color.Transparent;
            BtnSubmit.Cursor = Cursors.Hand;

            BtnSubmit.BackgroundImage = CargarImagen("iconoReportar.png");
            BtnSubmit.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("Por favor ingrese el departamento");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Por favor ingrese la descripción");
                return;
            }

            try
            {
                service.AddIncident(
                                txtDepartment.Text,
                                txtDescription.Text,
                                dtpDate.Value,
                                currentUser
                            );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            

            MessageBox.Show("Incidencia reportada exitosamente");
            this.Close();
        }

        private Image CargarImagen(string nombreArchivo)
        {
            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                nombreArchivo
            );

            return System.IO.File.Exists(path)
                ? Image.FromFile(path)
                : null;
        }

        private void FormReportIncident_Load(object sender, EventArgs e)
        {

        }
    }
}
