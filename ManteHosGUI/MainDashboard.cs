using ManteHos.Entities;
using ManteHos.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ManteHosGUI
{
    public partial class MainDashboard : BaseForm
    {
        private readonly Employee currentUser;
        private readonly IManteHosService service;

        private Panel panelIzquierdo;
        private Panel panelDerecho;

        // Panel izquierdo
        private PictureBox logo;
        private Label lblBienvenidos;
        private Label lblServicio;

        public MainDashboard(Employee user, IManteHosService manteHosService)
        {
            InitializeComponent();

            currentUser = user;
            service = manteHosService;

            this.Load += MainDashboard_Load;
        }

        private void MainDashboard_Load(object sender, EventArgs e)
        {
            CrearRectanguloIzquierdo();
            CrearPanelDerecho();

            ConfigureUIBasedOnRole();
            ConfigurarBotonLogout();
        }

        // ===============================
        // CONFIGURACIÓN POR ROL
        // ===============================
        private void ConfigureUIBasedOnRole()
        {
            lblWelcome.Text = $"Bienvenido, {currentUser.FullName}";

            btnReportIncident.Visible = true;
            btnReviewIncidents.Visible = false;
            btnAssignWorkOrders.Visible = false;
            btnCloseWorkOrders.Visible = false;

            if (currentUser is Operator)
                btnCloseWorkOrders.Visible = true;
            else if (currentUser is Master)
                btnAssignWorkOrders.Visible = true;
            else if (currentUser is Head)
                btnReviewIncidents.Visible = true;
        }

        // ===============================
        // PANEL DERECHO (CONTENIDO)
        // ===============================
        private void CrearPanelDerecho()
        {
            panelDerecho = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            this.Controls.Add(panelDerecho);
            panelDerecho.BringToFront();

            MoverControlesAlPanelDerecho();
            CentrarContenidoDerecho();

            this.Resize += (s, e) => CentrarContenidoDerecho();
        }

        private void MoverControlesAlPanelDerecho()
        {
            panelDerecho.Controls.Add(lblWelcome);
            panelDerecho.Controls.Add(label1);
            panelDerecho.Controls.Add(btnReportIncident);
            panelDerecho.Controls.Add(btnReviewIncidents);
            panelDerecho.Controls.Add(btnAssignWorkOrders);
            panelDerecho.Controls.Add(btnCloseWorkOrders);
        }

        private void CentrarContenidoDerecho()
        {
            int centerX = panelDerecho.Width / 2;
            int y = panelDerecho.Height / 2 - 150;

            lblWelcome.Location = new Point(centerX - lblWelcome.Width / 2, y);
            y += lblWelcome.Height + 10;

            label1.Location = new Point(centerX - label1.Width / 2, y);
            y += label1.Height + 30;

            Button[] botones =
            {
                btnReportIncident,
                btnReviewIncidents,
                btnAssignWorkOrders,
                btnCloseWorkOrders
            };

            foreach (Button btn in botones)
            {
                if (!btn.Visible) continue;

                btn.Location = new Point(centerX - btn.Width / 2, y);
                y += btn.Height + 15;
            }
        }

        // ===============================
        // PANEL AZUL IZQUIERDO
        // ===============================
        private void CrearRectanguloIzquierdo()
        {
            panelIzquierdo = new Panel
            {
                Dock = DockStyle.Left,
                Width = this.ClientSize.Width / 2,
                BackColor = ColorTranslator.FromHtml("#192959")
            };

            this.Controls.Add(panelIzquierdo);
            panelIzquierdo.SendToBack();

            CrearContenidoIzquierdo();

            this.Resize += MainDashboard_Resize;
        }

        private void MainDashboard_Resize(object sender, EventArgs e)
        {
            panelIzquierdo.Width = this.ClientSize.Width / 2;
            CentrarContenidoIzquierdo();
        }

        private void CrearContenidoIzquierdo()
        {
            logo = new PictureBox
            {
                Image = CargarImagen("ManteHosApp.png"),
                Size = new Size(200, 200),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };

            lblBienvenidos = new Label
            {
                Text = "¡MANTEHOS, TU\nMEJOR OPCIÓN!",
                ForeColor = Color.White,
                Font = new Font("Tahoma", 30, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            lblServicio = new Label
            {
                Text = "Servicio de Mantenimiento",
                ForeColor = Color.Gainsboro,
                Font = new Font("Lucida Sans Unicode", 12),
                AutoSize = true
            };

            panelIzquierdo.Controls.Add(logo);
            panelIzquierdo.Controls.Add(lblBienvenidos);
            panelIzquierdo.Controls.Add(lblServicio);

            CentrarContenidoIzquierdo();
        }

        private void CentrarContenidoIzquierdo()
        {
            int centerX = panelIzquierdo.Width / 2;

            logo.Location = new Point(centerX - logo.Width / 2, panelIzquierdo.Height / 2 - 160);
            lblBienvenidos.Location = new Point(centerX - lblBienvenidos.Width / 2, logo.Bottom + 15);
            lblServicio.Location = new Point(centerX - lblServicio.Width / 2, lblBienvenidos.Bottom + 5);
        }

        // ===============================
        // BOTÓN LOGOUT (PANEL AZUL)
        // ===============================
        private void ConfigurarBotonLogout()
        {
            btnLogout.Text = "";

            btnLogout.BackgroundImage = CargarImagen("iconoLogout.png");
            btnLogout.BackgroundImageLayout = ImageLayout.Zoom;

            btnLogout.Size = new Size(40, 40);

            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnLogout.BackColor = Color.Transparent;
            btnLogout.Cursor = Cursors.Hand;

            // CLAVE para que no se mueva
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            panelIzquierdo.Controls.Add(btnLogout);
            btnLogout.BringToFront();

            btnLogout.Location = new Point(15, 15);
        }

        // ===============================
        // UTILIDAD CARGAR IMÁGENES
        // ===============================
        private Image CargarImagen(string nombreArchivo)
        {
            string path = System.IO.Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                nombreArchivo
            );

            if (!System.IO.File.Exists(path))
            {
                MessageBox.Show(
                    $"No se encontró la imagen:\n{path}",
                    "Error de recursos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return null;
            }

            return Image.FromFile(path);
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Está seguro de que desea cerrar sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();

                ManteHosApp loginForm = new ManteHosApp(service);
                loginForm.Show();
            }
        }


        private void btnAssignWorkOrders_Click(object sender, EventArgs e) {
            
            AssignWorkOrder Awo = new AssignWorkOrder(service);
            Awo.Show();
        }
        private void btnCloseWorkOrders_Click(object sender, EventArgs e)
        {
            FormCloseWorkOrder form =
                new FormCloseWorkOrder(service);

            form.ShowDialog();
        }
        private void btnReviewIncidents_Click(object sender, EventArgs e)
        {
            FormReviewIncidents form = new FormReviewIncidents(service, (Head)currentUser);
            form.ShowDialog();
        }

        private void btnReportIncident_Click(object sender, EventArgs e)
        {
            new FormReportIncident(service, currentUser).ShowDialog();
        }

        private void MainDashboard_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.DBInitialization();
        }
    }
}
